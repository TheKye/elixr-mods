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

    public partial class WoodenBowRecipe :
        RecipeFamily
    {
        public WoodenBowRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "StringWoodenBow",
                    Localizer.DoStr("String Wooden Bow"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(WoodBowFrameItem), 1, true),
               new IngredientElement(typeof(BasicBowStringItem), 1, true),
                    },
                new CraftingElement<WoodenBowItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(10); 
            this.CraftMinutes = CreateCraftTimeValue(0.5f);
            this.Initialize(Localizer.DoStr("String Wooden Bow"), typeof(WoodenBowRecipe));
            CraftingComponent.AddRecipe(typeof(ToolBenchObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Wooden Bow")]
    [Tier(1)] 
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true)]                    
    public partial class WoodenBowItem : BowItem
    {
        // Static values
        private static IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(WoodenBowItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(20, typeof(HuntingSkill), typeof(WoodenBowItem)));
        private static IDynamicValue damage = CreateDamageValue(1, typeof(HuntingSkill), typeof(WoodenBowItem)); 
        private static IDynamicValue exp = new ConstantValue(1);
        private static IDynamicValue tier = new ConstantValue(1);
        private static IDynamicValue skilledRepairCost = new ConstantValue(1);  
        

        // Tool overrides

        public override LocString DisplayDescription    => Localizer.DoStr("A primitive ranged weapon for hunting. Requires arrows to fire.");    
        public override IDynamicValue CaloriesBurn      => caloriesBurn;
        public override IDynamicValue Damage            => damage; 
        public override Type ExperienceSkill            => typeof(HuntingSkill);
        public override IDynamicValue ExperienceRate    => exp;
        public override IDynamicValue Tier              => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate            => DurabilityMax / 100f;
        public override Item RepairItem => RandomUtil.CoinToss() ? Get<WoodBowFrameItem>() : Get<BasicBowStringItem>();
        public override int FullRepairAmount => 1;
    }
}