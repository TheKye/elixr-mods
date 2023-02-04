using Eco.Core.Plugins.Interfaces;
using Eco.Core.Systems;
using Eco.Gameplay.Items;
using Eco.Shared.Utils;
using System.Reflection;
using System.Collections.Generic;
using System;
using Eco.Shared.Localization;
using System.Linq;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.ModTools.RecipeResolver
{
    /// <summary>
    /// For classes that override an EMRecipeResolver compatible recipe.
    /// OverrideType (Type):        The Recipe Type that is to be overidden.
    /// NewRecipe: (List<Recipe>):  The new default recipe in a list.
    /// </summary>
    public interface IRecipeOverride
    {
        static Type OverrideType { get; }
        static List<Recipe> NewRecipe { get; }
    }

    public class EMRecipeResolve : AutoSingleton<EMRecipeResolve>, IModKitPlugin, IModInit
    {
        private Dictionary<Type, List<Recipe>> RecipeOverrides { get; } = new Dictionary<Type, List<Recipe>>();
        private Dictionary<Type, Type> Conflicts { get; } = new Dictionary<Type, Type>();

        public List<Recipe> ResolveRecipe(Type recipeType) => RecipeOverrides.ContainsKey(recipeType) ? RecipeOverrides[recipeType] : null;        

        private void AddRecipeOverrides()
        {
            foreach (var type in typeof(IRecipeOverride).ConcreteTypes())
            {
                var overrideType = (Type)type.GetProperty("OverrideType").GetValue(type);
                var newRecipe = (List<Recipe>)type.GetProperty("NewRecipe").GetValue(type);

                if (RecipeOverrides.ContainsKey(overrideType))
                {
                    Log.WriteErrorLine(Localizer.DoStr($"{overrideType.Name} can not be overriden by {type.Name} from {type.Assembly} as an override already exists in {Conflicts[overrideType].Assembly}"));
                    continue;
                }

                RecipeOverrides.Add(overrideType, newRecipe);
                Conflicts.Add(overrideType, type);
            }

            Conflicts.Clear();
        }

        public static void Initialize()
        {
            var bindings = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var tagMan = typeof(GeneratedRegistrarWrapper<TagManager>);
            var whenRdy = (WhenReady)tagMan.GetField("whenSetupDone", bindings).GetValue(tagMan);
            whenRdy.Do(() => Obj.AddRecipeOverrides());
        }

        public string GetStatus() => "Resolving Recipes... ";
    }
}
