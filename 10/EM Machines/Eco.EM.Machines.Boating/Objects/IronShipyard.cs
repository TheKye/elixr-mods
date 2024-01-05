using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Gameplay.Housing.PropertyValues;
using static Eco.Gameplay.Housing.PropertyValues.HomeFurnishingValue;
using Eco.Mods.TechTree;

namespace Eco.EM.Machines.Boating
{
    [LocDisplayName("Iron Shipyard")]
    [MaxStackSize(100)]
    [Weight(1)]
    [Serialized, Category("Visible")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true)]
    public partial class IronShipyardItem : WorldObjectItem<IronShipyardObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A place to build boats.");
        
        [TooltipChildren] public static HomeFurnishingValue HousingTooltip => HomeValue;
        public static new readonly HomeFurnishingValue HomeValue = new()
        {
            Category = RoomCategory.Industrial,
            TypeForRoomLimit = Localizer.DoStr(""),
        };

        [Serialized, TooltipChildren] public object PersistentData { get; set; }
    }

    [Serialized, Category("Visible")]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]

    [RequireComponent(typeof(PluginModulesComponent))]
    public partial class IronShipyardObject : PhysicsWorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Iron Shipyard");
        public Type RepresentedItemType => typeof(IronShipyardItem);

        protected override void Initialize()
        {
            base.Initialize();
            GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Crafting"));
        }
    }

    [RequiresSkill(typeof(ShipwrightSkill), 1)]
    public partial class IronShipyardRecipe : RecipeFamily
    {
        public IronShipyardRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "IronShipyard",  //noloc
                Localizer.DoStr("Iron Shipyard"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(HewnLogItem), 48, typeof(ShipwrightSkill)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<IronShipyardItem>()
                });
            Recipes = new List<Recipe> { recipe };
            ExperienceOnCraft = 18;
            LaborInCalories = CreateLaborInCaloriesValue(75, typeof(ShipwrightSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(IronShipyardRecipe), 2, typeof(ShipwrightSkill));
            Initialize(Localizer.DoStr("Iron Shipyard"), typeof(IronShipyardRecipe));
            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }

    }
}