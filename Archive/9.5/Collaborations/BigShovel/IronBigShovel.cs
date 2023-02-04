using System;
using System.ComponentModel;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.World;
using Eco.World.Blocks;
using Eco.Shared.Serialization;
using Eco.Core.Items;
using Eco.Gameplay.Skills;
using System.Collections.Generic;
using Eco.Gameplay.Components;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [Tier(2)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [LocDisplayName("Iron big Shovel")]
    public partial class IronBigShovelItem : BigShovelItem
    {
        // Static values
        private static IDynamicValue        caloriesBurn        = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(IronBigShovelItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(17, typeof(SelfImprovementSkill), typeof(IronBigShovelItem)));
        private static IDynamicValue        tier                = new ConstantValue(2);
        private static SkillModifiedValue   skilledRepairCost   = new(4, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);

        // Tool overrides
        public override IDynamicValue       CaloriesBurn        => caloriesBurn;
        public override IDynamicValue       Tier                => tier;
        public override IDynamicValue       SkilledRepairCost   => skilledRepairCost;
        public override float               DurabilityRate      => DurabilityMax / 500f;
        public override Item                RepairItem          => Item.Get<IronBarItem>();
        public override int                 FullRepairAmount    => 4;

        //Set this to the desired value you would like the shovels to pick up
        public override int                 MaxTake             => 10;

        public IronBigShovelItem() { }
    }

    [Serialized]
    [RequiresSkill(typeof(SmeltingSkill), 1)]
    [RepairRequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class IronBigShovelRecipe : RecipeFamily
    {
        public IronBigShovelRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "IronBigShovel",
                    Localizer.DoStr("Iron Big Shovel"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(IronBarItem), 8, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
               new IngredientElement("WoodBoard", 8, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                    },
                new CraftingElement<IronBigShovelItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronBigShovelRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Iron Big Shovel"), typeof(IronBigShovelRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}