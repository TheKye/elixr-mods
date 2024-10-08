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
    [LocDisplayName("Pizza")]
    [Weight(300)]
    //[Tag("BakedVegetable", 1)]
    //[Tag("BakedFood", 1)]
    [Ecopedia("Food", "Baking", createAsSubPage: true)]
    public partial class PizzaFoodItem : FoodItem
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Pizza");
        public override LocString DisplayDescription => Localizer.DoStr("Plain Pizza.");

        public override float Calories => 250;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 20, Fat = 10, Protein = 10, Vitamins = 0 };

        protected override int BaseShelfLife => throw new NotImplementedException();
    }

    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class PizzaFoodRecipe : RecipeFamily
    {
        public PizzaFoodRecipe()
        {
            var product = new Recipe(
                "Pizza",
                Localizer.DoStr("Pizza"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(LeavenedDoughItem), 1, typeof(CookingSkill)),
                    new IngredientElement(typeof(TomatoItem), 1, typeof(CookingSkill)),
                },
                new CraftingElement<PizzaFoodItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(55, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PizzaFoodRecipe), 1, typeof(CookingSkill), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Pizza"), typeof(PizzaFoodRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
