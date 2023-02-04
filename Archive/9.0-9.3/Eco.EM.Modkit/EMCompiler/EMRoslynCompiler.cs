// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using Eco.ModKit;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Eco.EM.Modkit
{
    public class EMRoslynCompiler
    {     
        static readonly LanguageVersion LanguageVersion = LanguageVersion.Default;
        const string subPath = "Compiled";

        static readonly string[] DependentSystemAssemblies = new[]
        {
            "netstandard",
#if NETFRAMEWORK
            "mscorlib",
            "System",
            "System.Core",
            "System.Runtime.Serialization",
#else
            "System.Collections",
            "System.ComponentModel.Primitives",
            "System.Linq",
            "System.ObjectModel",
            "System.Private.CoreLib",
            "System.Runtime",
            "System.Runtime.Extensions",
#endif
            "System.Collections.Immutable",
        };

        static readonly string[] DependentAssemblies = {
            "Eco.Core.dll",
            "Eco.Gameplay.dll",
            "Eco.ModKit.dll",
            "Eco.Mods.dll",
            "Eco.Shared.dll",
            "Eco.Simulation.dll",
            "Eco.World.dll",
            "Eco.Stats.dll",
            "Eco.WorldGenerator.dll",
            "LiteDB.dll",
            "Priority Queue.dll",
        };
         
        public EMRoslynCompiler() { }

        public Assembly CompileMod(string modPath, string Name, List<Assembly> injectedAssemblies)
        {
            var scriptsPath = Path.Combine(modPath, "scripts");

            if (!Directory.Exists(scriptsPath))
                return null;
            
            Assembly assembly = null;

            var syntaxTrees = this.GetSyntaxTrees(scriptsPath);  // Read cs files and add the syntax trees
            var references = this.GetSystemMetadataReferences(); // Adds system references
            var optimizationLevel = OptimizationLevel.Release;   
            var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, moduleName: Name, optimizationLevel: optimizationLevel);
            
            var compilation = CSharpCompilation.Create(Name, syntaxTrees, references, options);
            compilation = compilation.AddReferences(this.GetMetadataReferences());
            compilation = compilation.AddReferences(this.GetInjectedMetadataReferences(injectedAssemblies));

            EmitResult emitResult;

            using (var assemblyStream = new MemoryStream())
            using (var symbolsStream = new MemoryStream())
            {
                emitResult = compilation.Emit(assemblyStream, symbolsStream);

                if (emitResult.Success)
                {
                    var assemblyBytes = assemblyStream.ToArray();
                    var symbolsBytes = symbolsStream.ToArray();

                    if (!string.IsNullOrEmpty(modPath))
                    {
                        if (!Directory.Exists(Path.Combine(modPath, subPath)))
                            Directory.CreateDirectory(Path.Combine(modPath, subPath));
                        
                        var fileName = Path.Combine(modPath, subPath, Name + ".dll");
                        File.WriteAllBytes(fileName, assemblyBytes);
                    }

                    var currentDomain = AppDomain.CurrentDomain;
                    assembly = currentDomain.Load(assemblyBytes, symbolsBytes);
                }            
            }

            this.HandleCompilerWarning(emitResult.Diagnostics);
            this.HandleCompilerError(emitResult.Diagnostics);

            return assembly;
        }

        public List<SyntaxTree> GetSyntaxTrees(string scriptsPath)
        {
            string[] filepaths = Directory.GetFiles(scriptsPath, "*.cs", SearchOption.AllDirectories);

            var parseOptions = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion);

            var syntaxTrees = new List<SyntaxTree>();
            foreach (var fileName in filepaths)
            {    
                var source = File.ReadAllText(fileName);
                var syntaxTree = CSharpSyntaxTree.ParseText(source, parseOptions, fileName, Encoding.UTF8);
                syntaxTrees.Add(syntaxTree);
            }
            return syntaxTrees;
        }

        public List<MetadataReference> GetSystemMetadataReferences()
        {
            //var trustedAssembliesPaths = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")).Split(Path.PathSeparator);

            var currentDomain = AppDomain.CurrentDomain;
            var loadedAssemblies = ReflectionUtils.GetFilteredAssemblies();

            var references = new List<MetadataReference>();
            foreach (var name in DependentSystemAssemblies)
            {
                var loaded = loadedAssemblies.SingleOrDefault(a => a.GetName().Name == name) ?? currentDomain.Load(name);
                references.Add(AssemblyMetadata.CreateFromFile(loaded.Location).GetReference());
            }
            return references;
        }

        public List<MetadataReference> GetMetadataReferences()
        {
            var exe = Assembly.GetEntryAssembly();
            var compressedDlls = exe != null;
            var domainBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var references = new List<MetadataReference>();
            foreach (var name in DependentAssemblies)
            {
                var stream = compressedDlls ? exe.GetManifestResourceStream($"costura.{name.ToLower()}.compressed") : null;
                if (stream != null)
                {
                    using (var compressStream = new DeflateStream(stream, CompressionMode.Decompress))
                    using (var memoryStream = new MemoryStream())
                    {
                        // this is really dumb, but I can't get it to work when loading directly from a stream
                        compressStream.CopyTo(memoryStream);
                        var data = memoryStream.ToArray();
                        var assemblyMetadata = AssemblyMetadata.CreateFromImage(data);
                        references.Add(assemblyMetadata.GetReference());
                    }
                }
                else
                {
                    string assemblyLocation;
                    if (name == "Eco.Mods.dll")
                        assemblyLocation = Path.Combine(Directory.GetCurrentDirectory(), "Eco.Mods.dll", name);
                    else                     
                        assemblyLocation = Path.Combine(domainBaseDirectory, name);

                    if (!File.Exists(assemblyLocation))
                    {
                        assemblyLocation = AppDomain.CurrentDomain.Load(Path.GetFileNameWithoutExtension(name)).Location;
                    }
                    references.Add(AssemblyMetadata.CreateFromFile(assemblyLocation).GetReference());
                }
            }
            return references;
        }

        private List<MetadataReference> GetInjectedMetadataReferences(List<Assembly> injectedAssemblies)
        {
            var references = new List<MetadataReference>();
            foreach (var asm in injectedAssemblies)
            {
                references.Add(MetadataReference.CreateFromFile(asm.Location));
            }

            return references;
        }

        private void HandleCompilerError(ImmutableArray<Diagnostic> diagnostics)
        {
            var errors = diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error);

            if (errors.Any())
            {
                this.HasError = true;

                Log.WriteLine(Localizer.DoStr("Mods recompiled with errors."));

                foreach (var error in errors)
                {
                    var fileLine = error.Location.GetLineSpan();
                    var fileName = Path.GetFileName(fileLine.Path);
                    Log.WriteLine(new LocString(error.ToString()));
                }

                throw new Exception(errors.First().ToString());
            }
        }

        private static string[] warningsWhiteList = new string[]
        {
            "CS0672", // Member 'member1' overrides obsolete member 'member2'.
            "CS0618", // 'member' is obsolete
        };

        public bool HasError { get; private set; }

        private void HandleCompilerWarning(ImmutableArray<Diagnostic> diagnostics)
        {
            var warnings = diagnostics.Where(d => d.Severity == DiagnosticSeverity.Warning);

            if (warnings.Any())
            {
                Log.WriteLine(Localizer.DoStr("Mods recompiled with warnings."));

                foreach (var warning in warnings)
                {
                    if (warningsWhiteList.Contains(warning.Descriptor.Id))
                    {
                        var fileLine = warning.Location.GetLineSpan();
                        var fileName = Path.GetFileName(fileLine.Path);

                        Log.WriteLine(new LocString(warning.ToString()));
                    }
                }
            }
        }
    }
}
