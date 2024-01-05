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
    [LocDisplayName("Wooden Barge")]
    public partial class BargeItem : WorldObjectItem<BargeObject>
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
    public partial class BargeObject : PhysicsWorldObject, IRepresentsItem
    {
        static BargeObject()
        {
            AddOccupancy<BargeObject>(new List<BlockOccupancy>(0));
        }

        public override LocString DisplayName => Localizer.DoStr("Wooden Barge");
        public Type RepresentedItemType => typeof(BargeItem);

        private Player Driver => GetComponent<VehicleComponent>().Driver;

        private BargeObject() { }

        protected override void Initialize()
        {
            base.Initialize();

            GetComponent<PublicStorageComponent>().Initialize(120, 140000000);
            GetComponent<VehicleComponent>().HumanPowered(3f);
            GetComponent<VehicleComponent>().Initialize(20, 2, 4);
        }
    }

    [RequiresSkill(typeof(ShipwrightSkill), 1)]
    public partial class WoodenBargeRecipe : RecipeFamily
    {
        public WoodenBargeRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Barge",  //noloc
                Localizer.DoStr("Wooden Barge"),
                new List<IngredientElement>
                {
                    new IngredientElement("HewnLog", 24),
                    new IngredientElement(typeof(BoardItem), 64),
                    new IngredientElement(typeof(PaperItem), 100),
                    new IngredientElement(typeof(TallowItem), 20),
                    new IngredientElement(typeof(NailItem), 30),
                    new IngredientElement(typeof(IronBarItem), 20),
                    new IngredientElement(typeof(BasicUpgradeLvl3Item), 1, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<BargeItem>()
                });

            Recipes = new List<Recipe> { recipe };
            ExperienceOnCraft = 5;
            LaborInCalories = CreateLaborInCaloriesValue(500, typeof(ShipwrightSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(WoodenBargeRecipe), 35, typeof(ShipwrightSkill));
            ModsPreInitialize();
            Initialize(Localizer.DoStr("Wooden Barge"), typeof(WoodenBargeRecipe));
            ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(IronShipyardObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

}