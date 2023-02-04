using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Shared.Items;
using Eco.Mods.TechTree;

namespace Eco.EM.Energy.NuclearEnergy
{
    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerGeneratorComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [PowerGenerator(typeof(ElectricPower))]
    public partial class NuclearReactorObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Nuclear Reactor");

        public override TableTextureMode TableTexture => TableTextureMode.Metal;

        public virtual Type RepresentedItemType => typeof(NuclearReactorItem);

        private static readonly string[] fuelTagList = new string[] { "Nuclear Fuel Cell" };

        protected override void Initialize()
        {
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(10000);
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
            this.GetComponent<PowerGeneratorComponent>().Initialize(25000);
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [LocDisplayName("Nuclear Reactor")]
    [Ecopedia("Crafted Objects", "Power Generation", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class NuclearReactorItem : WorldObjectItem<NuclearReactorObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("This advanced piece of machinery generates vast amounts of power using the power of nuclear fission");

        static NuclearReactorItem() { }

        [Tooltip(7)] public LocString PowerConsumptionTooltip => new(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(10000)));
        [Tooltip(8)] public LocString PowerProductionTooltip => new(string.Format(Localizer.DoStr("Produces: {0}w"), Text.Info(25000)));
    }

    [Serialized]
    [RequiresModule(typeof(ComputerLabObject))]
    [RequiresSkill(typeof(NuclearTechnitionSkill), 1)]
    public class NuclearReactorItemRecipe : RecipeFamily
    {
        public NuclearReactorItemRecipe()
        {
            var product = new Recipe(
                "Nuclear Reactor",
                Localizer.DoStr("Nuclear Reactor"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(ReinforcedConcreteItem), 1000f, typeof(NuclearTechnitionSkill)),
               new IngredientElement(typeof(SteelPlateItem), 500f, typeof(NuclearTechnitionSkill)),
               new IngredientElement(typeof(BasicCircuitItem), 100f, typeof(NuclearTechnitionSkill)),
               new IngredientElement(typeof(ServoItem), 50f, typeof(NuclearTechnitionSkill)),
               new IngredientElement(typeof(HeatSinkItem), 50f, typeof(NuclearTechnitionSkill)),
                },
               new CraftingElement<NuclearReactorItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(1000, typeof(NuclearTechnitionSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(NuclearReactorItemRecipe), 120f, typeof(NuclearTechnitionSkill));
            this.Initialize(Localizer.DoStr("Nuclear Reactor"), typeof(NuclearReactorItemRecipe));
            CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
        }
    }
}
