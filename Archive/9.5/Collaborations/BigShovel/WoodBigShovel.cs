using System;
using System.Collections.Generic;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System.ComponentModel;
using Eco.Shared.Items;
using Eco.World;
using Eco.World.Blocks;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Components;
using Eco.Core.Items;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [Tier(1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [LocDisplayName("Wooden Big Shovel")]
    public partial class WoodenBigShovelItem : BigShovelItem
    {
        // Static values
        private static IDynamicValue    caloriesBurn        = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(WoodenBigShovelItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(20, typeof(SelfImprovementSkill), typeof(WoodenBigShovelItem)));
        private static IDynamicValue    tier                = new ConstantValue(1);
        private static IDynamicValue    skilledRepairCost   = new ConstantValue(5);

        // Tool overrides
        public override IDynamicValue   CaloriesBurn        => caloriesBurn;
        public override IDynamicValue   Tier                => tier;
        public override IDynamicValue   SkilledRepairCost   => skilledRepairCost;
        public override float           DurabilityRate      => DurabilityMax / 100f;
        public override Item            RepairItem          => Item.Get<Item>();
        public override Tag             RepairTag           => TagManager.Tag("Wood");
        public override int             FullRepairAmount    => 5;

        //Set this to the desired value you would like the shovels to pick up
        public override int MaxTake => 10;

        public WoodenBigShovelItem() { }
    }

    public partial class WoodenBigShovelRecipe : RecipeFamily
    {
        public WoodenBigShovelRecipe()
        {         
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "WoodenBigShovel",
                    Localizer.DoStr("Wooden Big Shovel"),
                    new IngredientElement[]
                    {
               new IngredientElement("Wood", 30),   
                    },
                new CraftingElement<WoodenBigShovelItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(10); 
            this.CraftMinutes = CreateCraftTimeValue(0.5f);
            this.Initialize(Localizer.DoStr("Wooden Big Shovel"), typeof(WoodenBigShovelRecipe));
            CraftingComponent.AddRecipe(typeof(ToolBenchObject), this);
        }
    }
}
