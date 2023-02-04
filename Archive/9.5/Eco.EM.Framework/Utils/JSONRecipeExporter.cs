﻿using Eco.Core.Plugins.Interfaces;
using Eco.EM.Framework;
using Eco.EM.Framework.FileManager;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Eco.EM.Framework.Utils
{
    [LocDisplayName("EM Vanilla Recipe Export")]
    public class JSONRecipeExporter : IModKitPlugin, ICommandablePlugin
    {
        class RecipeData
        {
            public List<string> CraftStation { get; set; } = new List<string>();
            public List<SkillData> SkillsNeeded { get; set; } = new List<SkillData>();
            public List<string> ModulesNeeded { get; set; } = new List<string>();
            public string BaseCraftTime { get; set; } = "nil";
            public string BaseLaborCost { get; set; } = "nil";
            public string BaseXPGain { get; set; } = "nil";
            public List<IngredientData> Ingredients { get; set; } = new List<IngredientData>();
            public List<ProductData> Products { get; set; } = new List<ProductData>();
        }

        class SkillData
        {
            public string Skill = "nil";
            public string Level = "nil";
        }

        class IngredientData
        {
            public string Type = "nil";
            public string DisplayName = "nil";
            public string Quantity = "nil";
            public string isStatic = "nil";
        }

        class ProductData
        {
            public string DisplayName = "nil";
            public string Quantity = "nil";
        }

        private const string _exportFile = "VanillaRecipes.json";
        private const string _subPath = "/EM/RecipeExport/";
        readonly List<Recipe> VanillaRecipes = new();
        readonly Dictionary<string, RecipeData> ExportData = new();

        // error tracking
        string CurrentRecipe { get; set; }
        string CurrentProperty { get; set; }

        public string GetStatus() => Localizer.DoStr($"EM Recipe Exporter");

        public override string ToString() => "EM Recipe Exporter";

        public void GetCommands(Dictionary<string, Action> nameToFunction)
        {
            nameToFunction.Add(Localizer.DoStr("Export Recipes"), () => ExportRecipes());
        }

        public void ExportRecipes()
        {
            try
            {
                BuildRecipeList();
                CheckPaths();
                BuildData();
                ExportJSON();
            }
            catch (Exception e)
            {
                if (CurrentRecipe != null && CurrentProperty != null)
                    Log.WriteErrorLine(Localizer.DoStr($"There was an error trying to handle {CurrentProperty} in the recipe {CurrentRecipe}"));
                Log.WriteErrorLine(Localizer.DoStr(e.Message));
            }
        }

        private void ExportJSON()
        {
            FileManager<Dictionary<string,RecipeData>>.WriteTypeHandledToFile(ExportData,Defaults.SaveLocation + _subPath, _exportFile);
        }

        private void BuildData()
        {
            foreach (Recipe r in VanillaRecipes)
            {
                if (ExportData.ContainsKey(r.DisplayName)) continue;
                var recipe = r.DisplayName;

                ExportData.Add(recipe, new RecipeData());

                UpdateErrorPosition(recipe, "CraftStation"); 
                // Crafting Station
                foreach (Type type in CraftingComponent.TablesForRecipe(r.Family.GetType()))
                {
                    WorldObjectItem creatingItem = WorldObjectItem.GetCreatingItemTemplateFromType(type);
                    if (!ExportData[recipe].CraftStation.Contains(creatingItem.DisplayName))
                        ExportData[recipe].CraftStation.Add(creatingItem.DisplayName);
                }

                UpdateErrorPosition(recipe, "SkillsNeeded");
                // Skills required
                foreach (RequiresSkillAttribute req in r.Family.RequiredSkills)
                {
                    var skill = new SkillData()
                    {
                        Skill = req.SkillItem.DisplayName.ToString(),
                        Level = req.Level.ToString(),
                    };
                    ExportData[recipe].SkillsNeeded.Add(skill);
                }

                UpdateErrorPosition(recipe, "ModulesNeeded");
                // Modules Required
                foreach (var module in r.Family.RequiredModules)
                {
                    ExportData[recipe].ModulesNeeded.Add(module.ModuleName);
                }

                // Base craft time, Labor, XP
                UpdateErrorPosition(recipe, "BaseCraftTime"); ExportData[recipe].BaseCraftTime = (r.Family.CraftMinutes != null) ? r.Family.CraftMinutes.GetBaseValue.ToString() : "'0'";
                UpdateErrorPosition(recipe, "BaseLaborCost"); ExportData[recipe].BaseLaborCost = r.Family.Labor.ToString();
                UpdateErrorPosition(recipe, "BaseXPGain"); ExportData[recipe].BaseXPGain = r.Family.ExperienceOnCraft.ToString();

                UpdateErrorPosition(recipe, "Ingredients");
                // Ingredients required
                foreach (var e in r.Ingredients)
                {
                    var ingredient = new IngredientData();

                    LocString element;

                    // is ingredient an ITEM or TAG
                    if (e.IsSpecificItem)
                    {
                        ingredient.Type = "ITEM";
                        element = e.Item.DisplayName;
                    }
                    else
                    {
                        ingredient.Type = "TAG";
                        element = Localizer.DoStr(SplitName(e.Tag.DisplayName));
                    }

                    ingredient.isStatic = e.Quantity is ConstantValue ? "true" : "false";
                    ingredient.DisplayName = element;
                    ingredient.Quantity = e.Quantity.GetBaseValue.ToString();

                    ExportData[recipe].Ingredients.Add(ingredient);
                }

                UpdateErrorPosition(recipe, "Products");
                // Products recieved
                foreach (var e in r.Items)
                {
                    var product = new ProductData()
                    {
                        DisplayName = e.Item.DisplayName,
                        Quantity = e.Quantity.GetBaseValue.ToString(),
                    };
                    ExportData[recipe].Products.Add(product);
                }
            }
        }

        private void UpdateErrorPosition(LocString recipe, string property)
        {
            if (CurrentRecipe != recipe) CurrentRecipe = recipe;
            CurrentProperty = property;
        }

        private void BuildRecipeList()
        {
            var all = RecipeFamily.AllRecipes;
            foreach (var family in all)
            {
                family.Recipes.ForEach(r => { if (!VanillaRecipes.Contains(r)) VanillaRecipes.Add(r); });
            }
        }

        private static void CheckPaths()
        {
            if (!Directory.Exists(Path.Combine(Defaults.SaveLocation + _subPath)))
                Directory.CreateDirectory(Path.Combine(Defaults.SaveLocation + _subPath));

            if (!File.Exists(Path.Combine(Defaults.SaveLocation + _subPath, _exportFile)))
                File.Create(Path.Combine(Defaults.SaveLocation + _subPath, _exportFile));
        }

        public static string SplitName(string name)
        {
            string[] NameSplit = Regex.Split(name, @"(?<!(^|[A-Z0-9]))(?=[A-Z0-9])|(?<!(^|[^A-Z]))(?=[0-9])|(?<!(^|[^0-9]))(?=[A-Za-z])|(?<!^)(?=[A-Z][a-z])");
            int count = 0;
            var sb = new StringBuilder();
            foreach (string str in NameSplit)
            {
                sb.Append(str);
                count++;
                if (count != NameSplit.Length)
                    sb.Append(' ');
            }

            return sb.ToString();
        }

    }
}