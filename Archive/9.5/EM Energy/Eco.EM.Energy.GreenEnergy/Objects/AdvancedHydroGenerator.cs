using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Mods.TechTree;
using Eco.Gameplay.Housing.PropertyValues;

namespace Eco.EM.Energy.GreenEnergy
{
    //Todo:
    // Force the Hydro Generator to use Rivers to generate power
    // This should also be a cheap alternative to other power sources but not be a better source
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerGeneratorComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class AdvancedHydroGeneratorObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Advanced Hydro Generator");

        protected override void Initialize()
        {
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
            this.GetComponent<PowerGeneratorComponent>().Initialize(800);
            this.GetComponent<HousingComponent>().HomeValue = AdvancedHydroGeneratorItem.HousingVal;
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [LocDisplayName("Advanced Hydro Generator")]
    public partial class AdvancedHydroGeneratorItem : WorldObjectItem<AdvancedHydroGeneratorObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("The Advanced Hydro Generator is used to generate electrical power from water");

        static AdvancedHydroGeneratorItem() { }

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren] public static HomeFurnishingValue HousingVal => new() { Category = HomeFurnishingValue.RoomCategory.Industrial, TypeForRoomLimit = Localizer.DoStr("")};
    }

    //Todo:
    // Adjust Recipe to suit the gameplay level.
    [RequiresSkill(typeof(MechanicsSkill), 3)]
    public partial class AdvancedHydroGeneratorRecipe : RecipeFamily
    {
        public AdvancedHydroGeneratorRecipe()
        {
            var product = new Recipe(
                    "Advanced Hydro Generator",
                    Localizer.DoStr("Advanced Hydro Generator"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(IronBarItem), 20 ,typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                        new IngredientElement("WoodBoard", 10 ,typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                        new IngredientElement(typeof(CopperBarItem), 20 ,typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent))
                    },

                    new CraftingElement<AdvancedHydroGeneratorItem>(1f)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(300f, typeof(BasicEngineeringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AdvancedHydroGeneratorRecipe), 30f, typeof(BasicEngineeringSkill), typeof(BasicEngineeringParallelSpeedTalent), typeof(BasicEngineeringFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Advanced Hydro Generator"), typeof(AdvancedHydroGeneratorRecipe));
            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }
    }
}
