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

    [RepairRequiresSkill(typeof(SmeltingSkill), 1)] 
    public partial class IronMacheteRecipe :
        RecipeFamily
    {
        public IronMacheteRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "IronMachete",
                    Localizer.DoStr("Iron Machete"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(IronMacheteHeadItem), 1, true),
               new IngredientElement(typeof(BasicWoodHandleItem), 1, true),
                    },
                new CraftingElement<IronMacheteItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250); 
            this.CraftMinutes = CreateCraftTimeValue(0.5f);    
            this.Initialize(Localizer.DoStr("Iron Machete"), typeof(IronMacheteRecipe));
            CraftingComponent.AddRecipe(typeof(ToolBenchObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Iron Machete")]
    [Tier(2)] 
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    public partial class IronMacheteItem : MacheteItem
    {
        // Static values
        private static IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(IronMacheteItem), typeof(GatheringToolEfficiencyTalent)), CreateCalorieValue(17, typeof(GatheringSkill), typeof(IronMacheteItem)));
        private static IDynamicValue exp = new ConstantValue(0.1f);
        private static IDynamicValue tier = new MultiDynamicValue(MultiDynamicOps.Sum, new ConstantValue(2), new TalentModifiedValue(typeof(IronMacheteItem), typeof(GatheringToolStrengthTalent), 0));
        private static IDynamicValue skilledRepairCost = new ConstantValue(1);


        // Tool overrides
        public override LocString DisplayDescription    => Localizer.DoStr("A machete used to quickly clear plants.");    
        public override IDynamicValue CaloriesBurn      => caloriesBurn;
        public override Type ExperienceSkill            => typeof(GatheringSkill);
        public override IDynamicValue ExperienceRate    => exp;
        public override IDynamicValue Tier              => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate            => DurabilityMax / 500f;
        public override Item RepairItem => RandomUtil.CoinToss() ? Get<IronMacheteHeadItem>() : Get<BasicWoodHandleItem>();
        public override int FullRepairAmount => 1;
    }
}
