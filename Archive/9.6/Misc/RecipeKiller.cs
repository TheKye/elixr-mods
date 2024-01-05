using Eco.Core.Plugins.Interfaces;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eco.Mods.TechTree
{
    public class RecipeKiller : Singleton<RecipeKiller>, IModKitPlugin, IModInit
    {
        //pass (OldRecipeType, ItemType, OldTableType (tabletype can be null if not removing))
        public static List<(Type, Type, Type)> recipeTypesToKill = new();

        public static void PostInitialize()
        {
            foreach (var kill in recipeTypesToKill)
            {
                var cache = RequiresSkillAttribute.Cache;
                Dictionary<Type, RequiresSkillAttribute[]> cachedAttributes = (Dictionary<Type, RequiresSkillAttribute[]>)cache.GetType().GetField("cachedAttributes", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(cache);
                if (cachedAttributes.ContainsKey(kill.Item1))
                {
                    cachedAttributes[kill.Item1] = new RequiresSkillAttribute[0];
                }

                Dictionary<Type, IEnumerable<RecipeFamily>> skillToRecipes = (Dictionary<Type, IEnumerable<RecipeFamily>>)typeof(RecipeFamily).GetField("skillToRecipes", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null);
                foreach (var skill in RecipeFamily.Get(kill.Item1).RequiredSkills)
                {
                    if (skillToRecipes.ContainsKey(skill.SkillType))
                    {
                        List<RecipeFamily> newEnumerable = new();
                        foreach (var recipe in skillToRecipes[skill.SkillType])
                            if (recipe != RecipeFamily.Get(kill.Item1))
                                newEnumerable.Add(recipe);

                        skillToRecipes[skill.SkillType] = newEnumerable.AsEnumerable();
                    }
                }

                Dictionary<Type, RecipeFamily[]> staticRecipes = (Dictionary<Type, RecipeFamily[]>)typeof(CraftingComponent).GetField("staticRecipes", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null);
                if (kill.Item3 != null && staticRecipes.ContainsKey(kill.Item3))
                {
                    List<RecipeFamily> newList = new();
                    staticRecipes[kill.Item3].ForEach((x) =>
                    {
                        var recipeName = x.GetType().Name;
                        if (recipeName != kill.Item1.Name)
                            newList.Add(x);
                    });
                    staticRecipes[kill.Item3] = newList.ToArray();
                }

                Dictionary<Type, List<Type>> recipeToTable = (Dictionary<Type, List<Type>>)typeof(CraftingComponent).GetField("recipeToTable", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null);
                if (kill.Item3 != null)
                {
                    List<Type> newList = new();
                    recipeToTable[kill.Item1].ForEach((x) =>
                    {
                        var tableName = x.Name;
                        if (tableName != kill.Item3.Name)
                            newList.Add(x);
                    });
                    recipeToTable[kill.Item1] = newList;
                }


                Dictionary<Type, List<RecipeFamily>> itemToRecipe = (Dictionary<Type, List<RecipeFamily>>)typeof(CraftingComponent).GetField("itemToRecipe", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null);
                if (itemToRecipe.ContainsKey(kill.Item2))
                {
                    List<RecipeFamily> newList = new();
                    itemToRecipe[kill.Item2].ForEach((x) =>
                    {
                        var recipeName = x.GetType().Name;
                        if (recipeName != kill.Item1.Name)
                            newList.Add(x);
                    });
                    itemToRecipe[kill.Item2] = newList;
                }


                Dictionary<Type, IEnumerable<RecipeFamily>> itemToRecipesWithProduct = (Dictionary<Type, IEnumerable<RecipeFamily>>)typeof(RecipeFamily).GetField("itemToRecipesWithProduct", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null);
                if (itemToRecipesWithProduct.ContainsKey(kill.Item2))
                {
                    List<RecipeFamily> newEnumerable = new();
                    foreach (var recipe in itemToRecipesWithProduct[kill.Item2])
                        if (recipe != RecipeFamily.Get(kill.Item1))
                            newEnumerable.Add(recipe);

                    itemToRecipesWithProduct[kill.Item2] = newEnumerable.AsEnumerable();
                }

                Dictionary<Tag, IEnumerable<RecipeFamily>> itemToRecipesWithTag = (Dictionary<Tag, IEnumerable<RecipeFamily>>)typeof(RecipeFamily).GetField("itemToRecipesWithTag", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null);
                foreach (var tag in kill.Item2.Tags())
                {
                    if (itemToRecipesWithTag.ContainsKey(tag))
                    {
                        List<RecipeFamily> newEnumerable = new();
                        foreach (var recipe in itemToRecipesWithTag[tag])
                            if (recipe != RecipeFamily.Get(kill.Item1))
                                newEnumerable.Add(recipe);

                        itemToRecipesWithTag[tag] = newEnumerable.AsEnumerable();
                    }
                }

                RecipeFamily.AllRecipes.RemoveAll(x => x.GetType() == kill.Item1);

                Dictionary<string, RecipeFamily> typenameToRecipe = (Dictionary<string, RecipeFamily>)typeof(RecipeFamily).GetField("typenameToRecipe", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null);
                if (typenameToRecipe.ContainsKey(kill.Item1.Name))
                    typenameToRecipe.Remove(kill.Item1.Name);

                Dictionary<Type, RecipeFamily> typeToRecipe = (Dictionary<Type, RecipeFamily>)typeof(RecipeFamily).GetField("typeToRecipe", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null);
                if (typeToRecipe.ContainsKey(kill.Item1))
                    typeToRecipe.Remove(kill.Item1);
            }
        }

        public string GetCategory() => "";

        public string GetStatus() => "Recipe Killer";
    }
}
