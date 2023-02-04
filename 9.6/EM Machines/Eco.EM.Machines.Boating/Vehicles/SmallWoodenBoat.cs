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
    [LocDisplayName("Small Canoe")]
    public partial class SmallBoatItem : WorldObjectItem<SmallBoatObject>
    {
        public float InteractDistance => DefaultInteractDistance.WaterPlacement;
        public override LocString DisplayDescription => Localizer.DoStr("Great for travelling on water, faster than a barge but a small storage capacity.");
    }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(AirPollutionComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    public partial class SmallBoatObject : PhysicsWorldObject, IRepresentsItem
    {
        static SmallBoatObject()
        {
            AddOccupancy<SmallBoatObject>(new List<BlockOccupancy>(0));
        }

        public override LocString DisplayName => Localizer.DoStr("Small Canoe");
        public Type RepresentedItemType => typeof(SmallBoatItem);

        private Player Driver => GetComponent<VehicleComponent>().Driver;

        private SmallBoatObject() { }

        protected override void Initialize()
        {
            base.Initialize();

            GetComponent<PublicStorageComponent>().Initialize(24, 140000000);
            GetComponent<VehicleComponent>().HumanPowered(3f);
            GetComponent<VehicleComponent>().Initialize(60, 2, 1);
        }
    }

    [RequiresSkill(typeof(ShipwrightSkill), 1)]
    public partial class SmallWoodenBoatRecipe : RecipeFamily
    {
        public SmallWoodenBoatRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "SmallCanoe",  //noloc
                Localizer.DoStr("Small Canoe"),
                new List<IngredientElement>
                {
                    new IngredientElement("HewnLog", 40, typeof(CarpentrySkill)),
                    new IngredientElement(typeof(BoardItem), 16, typeof(CarpentrySkill)),
                    new IngredientElement("Wood", 24),
                    new IngredientElement(typeof(WaterwheelItem), 2),
                    new IngredientElement(typeof(BasicUpgradeLvl1Item), 1, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<SmallBoatItem>()
                });
            Recipes = new List<Recipe> { recipe };
            ExperienceOnCraft = 3;
            LaborInCalories = CreateLaborInCaloriesValue(500, typeof(ShipwrightSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(SmallWoodenBoatRecipe), 20, typeof(ShipwrightSkill));
            ModsPreInitialize();
            Initialize(Localizer.DoStr("Small Canoe"), typeof(SmallWoodenBoatRecipe));
            ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(IronShipyardObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

}