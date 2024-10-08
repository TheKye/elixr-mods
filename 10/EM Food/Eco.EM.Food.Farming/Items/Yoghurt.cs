﻿using System;
using System.Collections.Generic;
using System.Text;

// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.PlanetChefMod
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    [Serialized]
    [LocDisplayName("Yoghurt")]
    [Weight(300)]
    //[Tag("BakedVegetable", 1)]
    //[Tag("BakedFood", 1)]
    [Ecopedia("Food", "Baking", createAsSubPage: true)]
    public partial class YoghurtFoodItem : FoodItem
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Yoghurt");
        public override LocString DisplayDescription => Localizer.DoStr("Milk with bacteria.");

        public override float Calories => 100;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 0.3f, Fat = 3, Protein = 5, Vitamins = 8 };

        protected override float BaseShelfLife => throw new NotImplementedException();
    }

    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class YoghurtFoodRecipe : RecipeFamily
    {
        public YoghurtFoodRecipe()
        {
            var product = new Recipe(
                "Yoghurt",
                Localizer.DoStr("Yoghurt"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(YeastItem), 1, typeof(CookingSkill)),
                },
                new CraftingElement<YoghurtFoodItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(35, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(YoghurtFoodRecipe), 1, typeof(CookingSkill), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Yoghurt"), typeof(YoghurtFoodRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
