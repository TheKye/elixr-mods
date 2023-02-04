using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Mods.TechTree;
using Eco.Core.Controller;
using System.Collections.Generic;

namespace Eco.EM.Industry
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
        public override LocString DisplayName { get { return Localizer.DoStr("Mechanical Power Converter"); } }

        protected override void Initialize()
        {
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
            this.GetComponent<MechPowerConsumptionComponent>().Initialize(600);
            this.GetComponent<PowerConverterComponent>().Initialize(10, new MechanicalPower());
            this.GetComponent<PowerGeneratorComponent>().Initialize(450);
            this.GetComponent<HousingComponent>().Set(PowerConverterItem.HousingVal);
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [LocDisplayName("Mechanical Power Converter")]
    public partial class PowerConverterItem :WorldObjectItem<PowerConverterObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Converts Mechanical Power to Electric Power."); } }

        static PowerConverterItem() {}

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal => new HousingValue() { Category = HousingValue.RoomCategory.Industrial, TypeForRoomLimit = "", };
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

    [Serialized]
    public class PowerConverterComponent : PowerGridComponent { }

    [Serialized]
    [RequireComponent(typeof(PowerConverterComponent))]
    public class MechPowerConsumptionComponent : WorldObjectComponent
    {
        [SyncToView]
        public float JoulesPerSecond { get; private set; }

        public MechPowerConsumptionComponent() { }
        public MechPowerConsumptionComponent(float joulesPerSecond)
        {
            this.Initialize(joulesPerSecond);
        }

        public void Initialize(float watts) => this.JoulesPerSecond = watts;
        public override void Initialize() => this.Parent.GetComponents<PowerConverterComponent>().ForEach(component =>
        {
            if (component.EnergyType.Name == "Mechanical")
                component.EnergyDemand += this.JoulesPerSecond;
        });
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerGeneratorComponent))]
    [RequireComponent(typeof(PowerConverterElecComponent))]
    [RequireComponent(typeof(PowerConsumptionElecComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class PowerConverterElecObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Power Converter"); } }

        protected override void Initialize()
        {
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
            this.GetComponent<PowerGeneratorComponent>().Initialize(500);
            this.GetComponent<PowerConverterElecComponent>().Initialize(10, new MechanicalPower());
            this.GetComponent<PowerConsumptionElecComponent>().Initialize(600);
            this.GetComponent<HousingComponent>().Set(PowerConverterItem.HousingVal);
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [LocDisplayName("Electrical Power Converter")]
    public partial class PowerConverterElecItem : WorldObjectItem<PowerConverterElecObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Converts Electric Power To Mechanical Power."); } }

        static PowerConverterElecItem() { }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal => new HousingValue() { Category = HousingValue.RoomCategory.Industrial, TypeForRoomLimit = "", };
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

    [Serialized]
    public class PowerConverterElecComponent : PowerGridComponent { }

    [Serialized]
    [RequireComponent(typeof(PowerConverterElecComponent))]
    public class PowerConsumptionElecComponent : WorldObjectComponent
    {
        [SyncToView]
        public float JoulesPerSecond { get; private set; }

        public PowerConsumptionElecComponent() { }
        public PowerConsumptionElecComponent(float joulesPerSecond)
        {
            this.Initialize(joulesPerSecond);
        }

        public void Initialize(float watts) => this.JoulesPerSecond = watts;
        public override void Initialize() => this.Parent.GetComponents<PowerConverterElecComponent>().ForEach(component =>
        {
            if (component.EnergyType.Name == "Electric")
                component.EnergyDemand += this.JoulesPerSecond;
        });
    }
}