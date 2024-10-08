﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Shared.Math;

    public partial class StoneHammerRecipe :
        RecipeFamily
    {
        public StoneHammerRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "StoneHammer",
                    Localizer.DoStr("Stone Hammer"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(StoneHammerHeadItem), 1, true),
               new IngredientElement(typeof(PrimitiveWoodHandleItem), 1, true),
                    },
                new CraftingElement<StoneHammerItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(10); 
            this.CraftMinutes = CreateCraftTimeValue(0.5f);
            this.Initialize(Localizer.DoStr("Stone Hammer"), typeof(StoneHammerRecipe));
            CraftingComponent.AddRecipe(typeof(ToolBenchObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Stone Hammer")]
    [Tier(1)] 
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true)]                    
    public partial class StoneHammerItem : HammerItem
    {
        // Static values
        private static IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(StoneHammerItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(10, typeof(SelfImprovementSkill), typeof(StoneHammerItem)));
        private static IDynamicValue tier = new ConstantValue(1);
        private static IDynamicValue skilledRepairCost = new ConstantValue(1);


        // Tool overrides

        public override IDynamicValue CaloriesBurn      => caloriesBurn;
        public override IDynamicValue Tier              => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate            => DurabilityMax / 250f;
        public override Item RepairItem => RandomUtil.CoinToss() ? Get<StoneHammerHeadItem>() : Get<PrimitiveWoodHandleItem>();
        public override int FullRepairAmount => 1;
    }
}
