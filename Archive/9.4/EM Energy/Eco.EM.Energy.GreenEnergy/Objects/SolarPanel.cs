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
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Math;
using Eco.EM.Framework.Helpers;
using Eco.Gameplay.Housing.PropertyValues;

namespace Eco.EM.Energy.GreenEnergy
{

    public partial class GreenEnergyTest : IChatCommandHandler
    {
        [ChatCommand("")]
        public static void TestDaylight(User user)
        {
            int time = (int)TimeUtil.SecondsToHours(((WorldTime.Seconds * Singleton<EcoSim>.Obj.EcoDef.TimeOfDayScale) + 28800.0) % 86400.0);
            if (DaylightSensorHelper.IsDayLight())
            {
                user.Player.OkBox(Localizer.DoStr($"The Time is: {time}:00 Which Means It is Day time!"));
            }
            else
                user.Player.OkBox(Localizer.DoStr($"The Time is: {time}:00 Which MeansIt is Night time!"));
        }
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerGeneratorComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(OnOffComponent))]
    [PowerGenerator(typeof(ElectricPower))]
    public partial class SolarPanelObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Solar Panel");

        static SolarPanelObject()
        {
            AddOccupancy<SolarPanelObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(WorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, -1), typeof(WorldObjectBlock)),
            });
        }

        protected override void Initialize()
        {
            GetComponent<PowerGridComponent>().Initialize(30, new ElectricPower());
            GetComponent<PowerGeneratorComponent>().Initialize(250);
        }

        public override void Tick()
        {
            this.GetComponent<OnOffComponent>().On = DaylightSensorHelper.IsDayLight();
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [LocDisplayName("Solar Panel")]
    [MaxStackSize(10)]
    public partial class SolarPanelItem : WorldObjectItem<SolarPanelObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Solar Panel used to store energy from the sun");

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        public static HomeFurnishingValue HousingVal = new()
        {
            Category = HomeFurnishingValue.RoomCategory.Industrial,
            TypeForRoomLimit = Localizer.DoStr("Power"),
        };

        [Tooltip(8)] public static LocString PowerProductionTooltip => Localizer.Do($"Produces: {Text.Info(250)}w of {new ElectricPower().Name} power");

    }

    [RequiresSkill(typeof(ElectronicsSkill), 4)]
    public partial class SolarPanelRecipe : RecipeFamily
    {
        public SolarPanelRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Solar Panel",
                    Localizer.DoStr("Solar Panel"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(PlasticItem), 20, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(IronBarItem), 8, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(BasicCircuitItem), 16, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(GlassItem), 10, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(CopperWiringItem), 15, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    },
                    new CraftingElement<SolarPanelItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(ElectronicsSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(SolarPanelRecipe), 5, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Solar Panel"), typeof(SolarPanelRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}