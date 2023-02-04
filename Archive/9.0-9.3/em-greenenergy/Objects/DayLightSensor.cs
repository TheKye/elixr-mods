using Eco.EM.Framework.Helpers;
using Eco.EM.GreenEnergy.Components;
using Eco.EM.ModTools.RecipeResolver;
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

namespace Eco.EM.GreenEnergy
{
    #region Wall Mountable
    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class DaylightSensorWallObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Daylight Sensor (Wall)"); } }
        public float Range = 20f;

        static DaylightSensorWallObject()
        {
            AddOccupancy<DaylightSensorWallObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f))
            });
        }

        public override void Tick()
        {
            Sensors.DaylightSensor(this, Range);
            Helpers.toggleDaylight(this);
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(200)]
    [LocDisplayName("Daylight Sensor - Wall")]
    public partial class DaylightSensorWallItem : WorldObjectItem<DaylightSensorWallObject>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Daylight Sensors"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A sensor that detects when it's day."); } }
    }

    [RequiresSkill(typeof(ElectronicsSkill), 0)]
    public partial class DaylightSensorWallRecipe : RecipeFamily
    {
        public DaylightSensorWallRecipe()
        {
            this.Recipes = EMRecipeResolve.Obj.ResolveRecipe(GetType()) ?? new List<Recipe>
            {
                new Recipe(
                    "Daylight Sensor - Wall",
                    Localizer.DoStr("Daylight Sensor - Wall"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(PlasticItem), 15, typeof(ElectronicsSkill)),
                    new IngredientElement(typeof(GoldBarItem), 8, typeof(ElectronicsSkill)),
                    new IngredientElement(typeof(BasicCircuitItem), 7, typeof(ElectronicsSkill))
                    },
                    new CraftingElement<DaylightSensorWallItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(ElectronicsSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(DaylightSensorWallRecipe), 1, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Daylight Sensor (Wall)"), typeof(DaylightSensorWallRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion

    #region Floor Placed
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(OnOffComponent))]
    public partial class DaylightSensorFloorObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Daylight Sensor (Floor)"); } }
        public float Range = 20f;

        static DaylightSensorFloorObject()
        {
            AddOccupancy<DaylightSensorFloorObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f))
            });
        }

        public override void Tick()
        {
            Sensors.DaylightSensor(this, Range);
            Helpers.toggleDaylight(this);
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(200)]
    [LocDisplayName("Daylight Sensor - Floor")]
    public partial class DaylightSensorFloorItem : WorldObjectItem<DaylightSensorFloorObject>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Daylight Sensors"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A sensor that detects when it's day."); } }
    }

    [RequiresSkill(typeof(ElectronicsSkill), 0)]
    public partial class DaylightSensorFloorRecipe : RecipeFamily
    {
        public DaylightSensorFloorRecipe()
        {
            this.Recipes = EMRecipeResolve.Obj.ResolveRecipe(GetType()) ?? new List<Recipe>
            {
                new Recipe(
                    "Daylight Sensor - Floor",
                    Localizer.DoStr("Daylight Sensor - Floor"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(PlasticItem), 15, typeof(ElectronicsSkill)),
                    new IngredientElement(typeof(GoldBarItem), 8, typeof(ElectronicsSkill)),
                    new IngredientElement(typeof(BasicCircuitItem), 7, typeof(ElectronicsSkill))
                    },
                    new CraftingElement<DaylightSensorFloorItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(ElectronicsSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(DaylightSensorFloorRecipe), 1, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent));
            this.ModsPreInitialize();
            Initialize(Localizer.DoStr("Daylight Sensor (Floor)"), typeof(DaylightSensorFloorRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion

}
