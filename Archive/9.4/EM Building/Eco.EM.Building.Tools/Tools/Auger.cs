using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.ComponentModel;

namespace Eco.EM.Building.Tools.Tools
{
    [Serialized, Weight(20000)]
    [LocDisplayName("Auger")]
    [RepairRequiresSkill(typeof(AdvancedSmeltingSkill), 0)]
    [Tier(4), Category("Tool"), Tag("Tool", 1)]
    [Currency, Tag("Currency")]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class AugerItem : ShovelItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Better than a shovel..");
        static AugerItem() { }

        // Static values
        private static readonly IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(AugerItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(10, typeof(SelfImprovementSkill), typeof(AugerItem), new AugerItem().UILink()));
        private static readonly IDynamicValue exp = new ConstantValue(0.1f);
        private static readonly IDynamicValue tier = new MultiDynamicValue(MultiDynamicOps.Sum, new ConstantValue(4), new TalentModifiedValue(typeof(AugerItem), typeof(ToolStrengthTalent), 0));
        private static readonly SkillModifiedValue skilledRepairCost = new(5, AdvancedSmeltingSkill.MultiplicativeStrategy, typeof(AdvancedSmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);

        // Tool overrides

        public override int MaxTake => 50;
        public override IDynamicValue CaloriesBurn => caloriesBurn;
        public override Type ExperienceSkill => typeof(SelfImprovementSkill);
        public override IDynamicValue ExperienceRate => exp;
        public override IDynamicValue Tier => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate => DurabilityMax / 2500f;
        public override Item RepairItem => Item.Get<GasolineItem>();
        public override int FullRepairAmount => 5;
    }

    // Skill requirements
    [RequiresSkill(typeof(AdvancedSmeltingSkill), 0)]
    public partial class AugerRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(AugerRecipe).Name,
            Assembly = typeof(AugerRecipe).AssemblyQualifiedName,
            HiddenName = "Auger",
            LocalizableName = Localizer.DoStr("Auger"),
            IngredientList = new()
            {
                new EMIngredient(item: "FiberglassItem", isTag: false, amount: 10, isStatic: false),
                new EMIngredient(item: "SteelBarItem", isTag: false, amount: 4, isStatic: false),
                new EMIngredient(item: "CombustionEngineItem", isTag: false, amount: 1, isStatic: true),
            },
            ProductList = new()
            {
                new EMCraftable(item: "AugerItem", amount: 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "AssemblyLineItem",
            RequiredSkillType = typeof(AdvancedSmeltingSkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(AdvancedSmeltingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent) },
        };

        static AugerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AugerRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

}
