using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.World;
using Eco.World.Blocks;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [Weight(1000)]
    [Category("Tool")]
    [Tier(3)]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [LocDisplayName("Modern Big Shovel")]
    public partial class ModernBigShovelItem : BigShovelItem
    {
        // Static values
        private static IDynamicValue        caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(ModernBigShovelItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(10, typeof(SelfImprovementSkill), typeof(ModernBigShovelItem)));
        private static IDynamicValue        tier = new ConstantValue(4);
        private static SkillModifiedValue   skilledRepairCost = new(15, AdvancedSmeltingSkill.MultiplicativeStrategy, typeof(AdvancedSmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);

        // Tool overrides
        public override IDynamicValue       CaloriesBurn => caloriesBurn;
        public override IDynamicValue       Tier => tier;
        public override IDynamicValue       SkilledRepairCost => skilledRepairCost;
        public override float               DurabilityRate => DurabilityMax / 2000f;
        public override Item                RepairItem => Item.Get<SteelBarItem>();
        public override int                 FullRepairAmount => 15;

        //Set this to the desired value you would like the shovels to pick up
        public override int MaxTake => 10;

        public ModernBigShovelItem() { }
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 2)]
    [RepairRequiresSkill(typeof(AdvancedSmeltingSkill), 2)]
    public partial class ModernBigShovelRecipe : RecipeFamily
    {
        public ModernBigShovelRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ModernBigShovel",
                    Localizer.DoStr("Modern Big Shovel"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(FiberglassItem), 15, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),
               new IngredientElement(typeof(SteelBarItem), 20, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),
                    },
                new CraftingElement<ModernBigShovelItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernBigShovelRecipe), 0.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Modern Big Shovel"), typeof(ModernBigShovelRecipe));
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
}