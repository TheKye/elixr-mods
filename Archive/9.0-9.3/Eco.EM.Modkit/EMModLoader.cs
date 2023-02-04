using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.ModKit;
using Eco.Server;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

/*
 * What we need this to do:
 * 1 Be loaded by the SLG modkit and have the constructor called (IModkitPlugin)
 * 2 Have a known simple directory structure that can be traversed to load in mods (server/EMModLoader/Modname/.. ) ? Perhaps sub for cs files also?
 * 3 Load Mod dll(s) and then then compile the .cs sub-directory and load the compiled dll
 * 4 
 * 
 * 
 * Optional: Do we provide an interface with a Mod Priority Property? How would that look?
 */

namespace Eco.EM.Modkit
{
    public class EMModLoader : IModKitPlugin
    {
        public string GetStatus() => "EM-Modloader Active";

        public static EMRoslynCompiler Compiler { get; private set; }

        // Base Directory
        public static readonly string LoadedModsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "LoadableMods");

        // Mod Assembly
        private static List<string> modPaths;
        private static List<Assembly> modAssemblies;

        static EMModLoader() 
        {
            var task = LoadEMKit();
            task.Wait();
        }

        private static Task LoadEMKit()
        {
            if (!Directory.Exists(LoadedModsDirectory))
                Directory.CreateDirectory(LoadedModsDirectory);

            modAssemblies = new List<Assembly>();

            // install resolver for mods
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;

            modPaths = Directory.EnumerateDirectories(LoadedModsDirectory).ToList();
            Compiler = new EMRoslynCompiler();

            using (new TimedTask(Localizer.DoStr("Loading priority compatible mods.."), true))
            {
                LoadModDlls(LoadedModsDirectory); // Load Top level first.               

                foreach (var modPath in modPaths)
                {
                    // Create Dynamic Assembly Name
                    var mod = Directory.CreateDirectory(modPath);
                    var modName = mod.Name + ".Compiled";

                    // Create List of pre-compiled dlls in modPath
                    var modAsm = LoadModDlls(modPath);

                    // Inject into compilation of cs files and load the created dll. 
                    var compiledAsm = Compiler.CompileMod(modPath, modName, modAsm);
                    modAssemblies.Add(compiledAsm);
                }
            }

            return Task.CompletedTask;
        }

        private static List<Assembly> LoadModDlls(string modPath)
        {
            string[] filepaths = Directory.GetFiles(modPath, "*.dll", SearchOption.TopDirectoryOnly);

            var asm = new List<Assembly>();

            // load each assembly first
            foreach (var file in filepaths)
            {
                var loadName = Localizer.DoStr(Path.GetFileNameWithoutExtension(file));
                Log.WriteLine(Localizer.Do($"Loading {loadName}..."));

                Assembly assembly = Assembly.LoadFile(file);

                asm.Add(assembly);
                modAssemblies.Add(assembly);
            }

            // initialize the server plugin static constructors, this may trigger assembly resolve events
            foreach (var assembly in asm)
            {
                var types = assembly.GetTypes();
                var iServerPlugins = types.Where(t => typeof(IServerPlugin).IsAssignableFrom(t));

                // static constructor init
                foreach (Type serverPluginType in iServerPlugins)
                {
                    System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(serverPluginType.TypeHandle);
                }
            }

            return asm;
        }

        /// <summary> Function to resolve mod dll dependencies. </summary>
        private static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        {
            // if a mod dll, resolve without version
            if (modAssemblies.Any(assembly => assembly == args.RequestingAssembly))
            {
                var assemblyName = new AssemblyName(args.Name);
                return modAssemblies.SingleOrDefault(assembly => assembly.GetName().Name == assemblyName.Name);
            }
            return null;
        }
    }
}
