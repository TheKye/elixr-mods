﻿using System;
using System.Collections.Generic;
using System.Text;

// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.EM.Food.Farming
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
    [LocDisplayName("Fried Egg")]
    [Weight(300)]
    //[Tag("BakedVegetable", 1)]
    //[Tag("BakedFood", 1)]
    [Ecopedia("Food", "Charred Food", createAsSubPage: true)]
    public partial class FriedEggFoodItem : FoodItem
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Fried Egg");
        public override LocString DisplayDescription => Localizer.DoStr("Egg fried with oil.");

        public override float Calories => 196;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 0.8f, Fat = 1.0f, Protein = 1.3f, Vitamins = 0.2f };

        protected override int BaseShelfLife => throw new NotImplementedException();
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 1)]
    public partial class FriedEggFoodRecipe : RecipeFamily
    {
        public FriedEggFoodRecipe()
        {
            var product = new Recipe(
                "Fried Egg",
                Localizer.DoStr("Fried Egg"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(EggItem), 1, typeof(CampfireCookingSkill)),
                },
                new CraftingElement<FriedEggFoodItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FriedEggFoodRecipe), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Fried Egg"), typeof(FriedEggFoodRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
