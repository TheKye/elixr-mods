using System.Collections.Generic;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Components;
using Eco.Gameplay.Systems.Chat;
using Eco.Gameplay.Players;
using Eco.Shared.Utils;
using Eco.Simulation.Time;
using Eco.Simulation;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Math;
using Eco.EM.Framework.Helpers;
using Eco.Gameplay.Housing.PropertyValues;

namespace Eco.EM.Energy.GreenEnergy
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerGeneratorComponent))]
    [RequireComponent(typeof(OnOffComponent))]
    [PowerGenerator(typeof(ElectricPower))]
    public partial class LargeSolarPanelObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Large Solar Panel");

        static LargeSolarPanelObject()
        {
            AddOccupancy<LargeSolarPanelObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(WorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, -1), typeof(WorldObjectBlock)),
            });
        }

        protected override void Initialize()
        {
            GetComponent<PowerGridComponent>().Initialize(30, new ElectricPower());
            GetComponent<PowerGeneratorComponent>().Initialize(1500);
        }

        public override void Tick()
        {
            this.GetComponent<OnOffComponent>().On = DaylightSensorHelper.IsDayLight();
        }

    }

    [Serialized]
    [LocDisplayName("Large Solar Panel")]
    [MaxStackSize(10)]
    public partial class LargeSolarPanelItem : WorldObjectItem<LargeSolarPanelObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Large Solar Panel used to store energy from the sun, Great For Making Solar Farms");

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        public static HomeFurnishingValue HousingVal = new()
        {
            Category = HousingConfig.GetRoomCategory("Industrial"),
            TypeForRoomLimit = Localizer.DoStr("Power"),
        };

        [Tooltip(8)] public static LocString PowerProductionTooltip => Localizer.Do($"Produces: {Text.Info(1500)}w of {new ElectricPower().Name} power");

    }

    [RequiresSkill(typeof(ElectronicsSkill), 4)]
    public partial class LargeSolarPanelRecipe : RecipeFamily
    {
        public LargeSolarPanelRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Large Solar Panel",
                    Localizer.DoStr("Large Solar  Panel"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(PlasticItem), 40, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(IronBarItem), 16, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(BasicCircuitItem), 32, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(GlassItem), 20, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(CopperWiringItem), 30, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    },
                    new CraftingElement<LargeSolarPanelItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(ElectronicsSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(LargeSolarPanelRecipe), 5, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Large Solar Panel"), typeof(LargeSolarPanelRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}