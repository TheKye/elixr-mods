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

    [RepairRequiresSkill(typeof(AdvancedSmeltingSkill), 2)] 
    public partial class SteelMacheteRecipe :
        RecipeFamily
    {
        public SteelMacheteRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "SteelMachete",
                    Localizer.DoStr("Steel Machete"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(SteelMacheteHeadItem), 1, true),
               new IngredientElement(typeof(ModernWoodHandleItem), 1, true),
                    },
                new CraftingElement<SteelMacheteItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250); 
            this.CraftMinutes = CreateCraftTimeValue(0.5f);    
            this.Initialize(Localizer.DoStr("Steel Machete"), typeof(SteelMacheteRecipe));
            CraftingComponent.AddRecipe(typeof(ToolBenchObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Steel Machete")]
    [Tier(3)] 
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true)]                    
    public partial class SteelMacheteItem : MacheteItem
    {
        // Static values
        private static IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(SteelMacheteItem), typeof(GatheringToolEfficiencyTalent)), CreateCalorieValue(15, typeof(GatheringSkill), typeof(SteelMacheteItem)));
        private static IDynamicValue exp = new ConstantValue(0.1f);
        private static IDynamicValue tier = new MultiDynamicValue(MultiDynamicOps.Sum, new ConstantValue(3), new TalentModifiedValue(typeof(SteelMacheteItem), typeof(GatheringToolStrengthTalent), 0));
        private static IDynamicValue skilledRepairCost = new ConstantValue(1);

        private static Vector2i[] areaBlocks = new Vector2i[]
        {
        new Vector2i(-1, 0), 
        new Vector2i(0, 1), 
        new Vector2i(1, 0), 
        };

        // Tool overrides

        public override LocString DisplayDescription    => Localizer.DoStr("A machete used to quickly clear plants.");    
        public override IDynamicValue CaloriesBurn      => caloriesBurn;
        public override Type ExperienceSkill            => typeof(GatheringSkill);
        public override IDynamicValue ExperienceRate    => exp;
        public override IDynamicValue Tier              => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate            => DurabilityMax / 1000f;
        public override Item RepairItem => RandomUtil.CoinToss() ? Get<SteelMacheteHeadItem>() : Get<ModernWoodHandleItem>();
        public override int FullRepairAmount => 1;
        public override Vector2i[] AreaBlocks           => areaBlocks;
    }
}
