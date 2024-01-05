using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Items;
using Eco.Mods.TechTree;

namespace Eco.EM.Machines.Boating
{
    [Tag("Boat")]
    [WaterPlaceable]
    [Serialized, Category("Visible")]
    [Ecopedia("Crafted Objects", "Vehicles", createAsSubPage: true)]
    [LocDisplayName("Fishing Boat")]
    public partial class FishingBoatItem : WorldObjectItem<FishingBoatObject>
    {
        public float InteractDistance => DefaultInteractDistance.WaterPlacement;
        public override LocString DisplayDescription => Localizer.DoStr("Fast, huge capacity, what more could you want?");
    }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(AirPollutionComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(AirPollutionComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    public partial class FishingBoatObject : PhysicsWorldObject, IRepresentsItem
    {
        static FishingBoatObject()
        {
            WorldObject.AddOccupancy<FishingBoatObject>(new List<BlockOccupancy>(0));
        }

        public override LocString DisplayName => Localizer.DoStr("Fishing Boat");
        public Type RepresentedItemType => typeof(FishingBoatItem);

        private static string[] fuelTagList = new string[]
        {
            "Liquid Fuel",
        };

        private Player Driver => this.GetComponent<VehicleComponent>().Driver;

        private FishingBoatObject() { }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<VehicleComponent>().Initialize(30, 2, 1);
            this.GetComponent<PublicStorageComponent>().Initialize(60, 140000000);
			this.GetComponent<FuelSupplyComponent>().Initialize(6, fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(25);
            this.GetComponent<AirPollutionComponent>().Initialize(0.5f);
        }
    }
	
	[RequiresSkill(typeof(ShipwrightSkill), 2)]
    public partial class FishingBoatRecipe : RecipeFamily
    {
        public FishingBoatRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "FishingBoat",  //noloc
                Localizer.DoStr("Fishing Boat"),
                new List<IngredientElement>
                {
                    new IngredientElement("Lumber", 24, typeof(CarpentrySkill)), //noloc
                    new IngredientElement(typeof(SyntheticRubberItem), 40, typeof(AdvancedSmeltingSkill)),
                    new IngredientElement(typeof(SteelGearboxItem), 4, typeof(AdvancedSmeltingSkill)),
                    new IngredientElement(typeof(SteelPipeItem), 12, typeof(AdvancedSmeltingSkill)),
                    new IngredientElement(typeof(SteelPlateItem), 100, typeof(BasicEngineeringSkill)),
                    new IngredientElement(typeof(CombustionEngineItem), 1, true),
                    new IngredientElement(typeof(ModernUpgradeLvl2Item), 1, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<FishingBoatItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 3;
            this.LaborInCalories = CreateLaborInCaloriesValue(1000, typeof(ShipwrightSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FishingBoatRecipe), 50, typeof(ShipwrightSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Fishing Boat"), typeof(FishingBoatRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(IronShipyardObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

}