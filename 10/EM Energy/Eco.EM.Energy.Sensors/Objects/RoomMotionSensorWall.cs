using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System.Collections.Generic;

namespace Eco.EM.Energy.Sensors
{
    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class MotionSensorWallObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Motion Sensor (Wall)");
        public float Range = 20f;

        static MotionSensorWallObject()
        {
            AddOccupancy<MotionSensorWallObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f))
            });

        }

        protected override void Initialize()
        {
            base.Initialize();
            GetComponent<PropertyAuthComponent>().Initialize();
        }
        public override void Tick()
        {
            Framework.Helpers.Sensors.MotionSensor(this, Range);
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(200)]
    [LocDisplayName("Motion Sensor - Wall")]
    public partial class MotionSensorWallItem : WorldObjectItem<MotionSensorWallObject>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Motion Sensors");
        public override LocString DisplayDescription => Localizer.DoStr("A sensor that detects when players are in the room.");
    }

    [RequiresSkill(typeof(ElectronicsSkill), 4)]
    public partial class MotionSensorWallRecipe : RecipeFamily
    {
        public MotionSensorWallRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Motion Sensor - Wall",
                    Localizer.DoStr("Motion Sensor - Wall"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(PlasticItem), 20, typeof(ElectronicsSkill)),
                    new IngredientElement(typeof(IronBarItem), 8, typeof(ElectronicsSkill)),
                    new IngredientElement(typeof(BasicCircuitItem), 16, typeof(ElectronicsSkill))
                    },
                    new CraftingElement<MotionSensorWallItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(ElectronicsSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(MotionSensorWallRecipe), 1, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Motion Sensor (Wall)"), typeof(MotionSensorWallRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
