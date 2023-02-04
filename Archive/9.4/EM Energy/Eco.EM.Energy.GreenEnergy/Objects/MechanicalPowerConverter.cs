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
using Eco.Core.Controller;
using System.Collections.Generic;
using Eco.Gameplay.Housing.PropertyValues;
using Eco.EM.Energy.GreenEnergy.Components;

namespace Eco.EM.Energy.GreenEnergy
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerGeneratorComponent))]
    [RequireComponent(typeof(PowerConverterComponent))]
    [RequireComponent(typeof(MechPowerConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class PowerConverterObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Mechanical Power Converter");

        protected override void Initialize()
        {
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
            this.GetComponent<MechPowerConsumptionComponent>().Initialize(600);
            this.GetComponent<PowerConverterComponent>().Initialize(10, new MechanicalPower());
            this.GetComponent<PowerGeneratorComponent>().Initialize(450);
            this.GetComponent<HousingComponent>().HomeValue = PowerConverterItem.HousingVal;
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [LocDisplayName("Mechanical Power Converter")]
    public partial class PowerConverterItem :WorldObjectItem<PowerConverterObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Converts Mechanical Power to Electric Power.");

        static PowerConverterItem() {}

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren] public static HomeFurnishingValue HousingVal => new() { Category = HomeFurnishingValue.RoomCategory.Industrial, TypeForRoomLimit = Localizer.DoStr("")};
    }

    [RequiresSkill(typeof(MechanicsSkill), 3)]
    public partial class PowerConverterRecipe : RecipeFamily
    {
        public PowerConverterRecipe()
        {
            var product = new Recipe(
                    "Power Converter",
                    Localizer.DoStr("Power Converter"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(IronBarItem), 20 ,typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                        new IngredientElement("WoodBoard", 10 ,typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                        new IngredientElement(typeof(CopperBarItem), 20 ,typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent))
                    },

                    new CraftingElement<PowerConverterItem>(1f)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(300f, typeof(BasicEngineeringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PowerConverterRecipe), 30f, typeof(BasicEngineeringSkill), typeof(BasicEngineeringParallelSpeedTalent), typeof(BasicEngineeringFocusedSpeedTalent));

            this.Initialize(Localizer.DoStr("Power Converter"), typeof(PowerConverterRecipe));
            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }
    }
}