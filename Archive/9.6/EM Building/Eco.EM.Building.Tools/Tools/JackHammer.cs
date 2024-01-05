using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.ComponentModel;

namespace Eco.EM.Building.Tools
{
    [Serialized, Weight(20000)]
    [LocDisplayName("Gas Powered Pickaxe")]
    [RepairRequiresSkill(typeof(AdvancedSmeltingSkill), 0)]
    [Tier(4), Category("Tool"), Tag("Tool", 1)]
    [Currency, Tag("Currency")]
    [Ecopedia("Items", "Tools", createAsSubPage: true)]
    public partial class JackHammerItem : PickaxeItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Dude just call it what it is, A Jackhammer..");
        static JackHammerItem() { }

        // Static values
        private static readonly IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(JackHammerItem), typeof(MiningToolEfficiencyTalent)), CreateCalorieValue(10, typeof(MiningSkill), typeof(JackHammerItem)));
        private static readonly IDynamicValue exp = new ConstantValue(0.1f);
        private static readonly IDynamicValue tier = new MultiDynamicValue(MultiDynamicOps.Sum, new ConstantValue(4), new TalentModifiedValue(typeof(JackHammerItem), typeof(MiningToolStrengthTalent), 0));
        private static readonly SkillModifiedValue skilledRepairCost = new(5, AdvancedSmeltingSkill.MultiplicativeStrategy, typeof(AdvancedSmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);

        // Tool overrides

        public override IDynamicValue CaloriesBurn => caloriesBurn;
        public override Type ExperienceSkill => typeof(MiningSkill);
        public override IDynamicValue ExperienceRate => exp;
        public override IDynamicValue Tier => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate => DurabilityMax / 2500f;
        public override Item RepairItem => Item.Get<GasolineItem>();
        public override int FullRepairAmount => 5;

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (this.Durability == 0)
                return InteractResult.Failure(Localizer.DoStr("The Jackhammer.. i mean, Gas Powered Pickaxe has run out of gas, it needs to be refuled.."));

            return base.OnActLeft(context);
        }
    }

    // Skill requirements
    [RequiresSkill(typeof(AdvancedSmeltingSkill), 0)]
    public partial class JackHammerRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(JackHammerRecipe).Name,
            Assembly = typeof(JackHammerRecipe).AssemblyQualifiedName,
            HiddenName = "Gas Powered Pickaxe",
            LocalizableName = Localizer.DoStr("Gas Powered Pickaxe"),
            IngredientList = new()
            {
                new EMIngredient(item: "FiberglassItem", isTag: false, amount: 10, isStatic: false),
                new EMIngredient(item: "SteelBarItem", isTag: false, amount: 4, isStatic: false),
                new EMIngredient(item: "CombustionEngineItem", isTag: false, amount: 1, isStatic: true),
            },
            ProductList = new()
            {
                new EMCraftable(item: "JackHammerItem", amount: 1),
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

        static JackHammerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public JackHammerRecipe()
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