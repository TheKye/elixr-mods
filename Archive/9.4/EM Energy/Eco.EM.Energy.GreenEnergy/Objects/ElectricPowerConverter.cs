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
    [RequireComponent(typeof(PowerConverterElecComponent))]
    [RequireComponent(typeof(PowerConsumptionElecComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class PowerConverterElecObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Power Converter");

        protected override void Initialize()
        {
            this.GetComponent<PowerGridComponent>().Initialize(10, new MechanicalPower());
            this.GetComponent<PowerGeneratorComponent>().Initialize(500);
            this.GetComponent<PowerConverterElecComponent>().Initialize(10, new ElectricPower());
            this.GetComponent<PowerConsumptionElecComponent>().Initialize(600);
            this.GetComponent<HousingComponent>().HomeValue = PowerConverterItem.HousingVal;
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [LocDisplayName("Electrical Power Converter")]
    public partial class PowerConverterElecItem : WorldObjectItem<PowerConverterElecObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Converts Electric Power To Mechanical Power.");

        static PowerConverterElecItem() { }

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren] public static HomeFurnishingValue HousingVal => new() { Category = HomeFurnishingValue.RoomCategory.Industrial, TypeForRoomLimit = Localizer.DoStr("") };
    }

    [RequiresSkill(typeof(MechanicsSkill), 3)]
    public partial class PowerConverterElecRecipe : RecipeFamily
    {
        public PowerConverterElecRecipe()
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

                    new CraftingElement<PowerConverterElecItem>(1f)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(300f, typeof(BasicEngineeringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PowerConverterElecRecipe), 30f, typeof(BasicEngineeringSkill), typeof(BasicEngineeringParallelSpeedTalent), typeof(BasicEngineeringFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Power Converter"), typeof(PowerConverterElecRecipe));
            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }
    }
}
