using Eco.EM.Energy.Sensors.Components;
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
using Eco.EM.Framework.Resolvers;
using System;

namespace Eco.EM.Energy.Sensors
{
    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class DaylightSensorWallObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Daylight Sensor (Wall)");
        public float Range = 20f;

        static DaylightSensorWallObject()
        {
            AddOccupancy<DaylightSensorWallObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f))
            });
        }

        public override void Tick()
        {
            Framework.Helpers.Sensors.DaylightSensor(this, Range);
            Helpers.toggleDaylight(this);
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(200)]
    [LocDisplayName("Daylight Sensor - Wall")]
    public partial class DaylightSensorWallItem : WorldObjectItem<DaylightSensorWallObject>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Daylight Sensors");
        public override LocString DisplayDescription => Localizer.DoStr("A sensor that detects when it's day.");
    }

    [RequiresSkill(typeof(ElectronicsSkill), 0)]
    public partial class DaylightSensorWallRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new ()
        {
            ModelType = typeof(DaylightSensorWallRecipe).Name,
            Assembly = typeof(DaylightSensorWallRecipe).AssemblyQualifiedName,
            HiddenName = "Daylight Sensor - Wall",
            LocalizableName = Localizer.DoStr("Daylight Sensor - Wall"),
            RequiredSkillType = typeof(ElectronicsSkill),
            RequiredSkillLevel = 0,
            SpeedImprovementTalents = new Type[] { typeof(ElectronicsFocusedSpeedTalent), typeof(ElectronicsParallelSpeedTalent) },
            IngredientList = new()
            {
                new EMIngredient("PlasticItem", false, 15),
                new EMIngredient("GoldBarItem", false, 8),
                new EMIngredient("BasicCircuitItem", false, 7)
            },
            ProductList = new()
            {
                new EMCraftable("DaylightSensorWallItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "ElectronicsAssemblyItem",
        };
        static DaylightSensorWallRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public DaylightSensorWallRecipe()
        {
            Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            ModsPreInitialize();
            Initialize(Defaults.LocalizableName, GetType());
            ModsPostInitialize();
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
