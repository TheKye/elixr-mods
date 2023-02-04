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
    [Tier(3)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [LocDisplayName("Steel Big Shovel")]
    public partial class SteelBigShovelItem : BigShovelItem
    {
        // Static values
        private static IDynamicValue        caloriesBurn        = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(SteelBigShovelItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(15, typeof(SelfImprovementSkill), typeof(SteelBigShovelItem)));
        private static IDynamicValue        tier                = new ConstantValue(3);
        private static SkillModifiedValue   skilledRepairCost   = new(8, AdvancedSmeltingSkill.MultiplicativeStrategy, typeof(AdvancedSmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);

        // Tool overrides

        public override IDynamicValue       CaloriesBurn        => caloriesBurn;
        public override IDynamicValue       Tier                => tier;
        public override IDynamicValue       SkilledRepairCost   => skilledRepairCost;
        public override float               DurabilityRate      => DurabilityMax / 1000f;
        public override Item                RepairItem          => Item.Get<SteelBarItem>();
        public override int                 FullRepairAmount    => 8;

        //Set this to the desired value you would like the shovels to pick up
        public override int                 MaxTake             => 10;

        public SteelBigShovelItem() { }
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 1)]
    [RepairRequiresSkill(typeof(AdvancedSmeltingSkill), 2)]
    public partial class SteelBigShovelRecipe : RecipeFamily
    {
        public SteelBigShovelRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "SteelBigShovel",
                    Localizer.DoStr("Steel Big Shovel"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(SteelBarItem), 15, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),
               new IngredientElement("Lumber", 10, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),
                    },
                new CraftingElement<SteelBigShovelItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelBigShovelRecipe), 0.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Steel Big Shovel"), typeof(SteelBigShovelRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}
