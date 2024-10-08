﻿using Eco.EM.Energy.Sensors.Components;
using Eco.EM.Framework.Helpers;
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
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(OnOffComponent))]
    public partial class DaylightSensorFloorObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Daylight Sensor (Floor)");
        public float Range = 20f;

        static DaylightSensorFloorObject()
        {
            AddOccupancy<DaylightSensorFloorObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f))
            });
        }

        public override void Tick()
        {
            Framework.Helpers.Sensors.DaylightSensor(this, Range);

            var daylight = DaylightSensorHelper.IsDayLight();
            if (GetComponent<OnOffComponent>().On)
            {
                SetAnimatedState("IsDaytime", daylight);
                return;
            }
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(200)]
    [LocDisplayName("Daylight Sensor - Floor")]
    public partial class DaylightSensorFloorItem : WorldObjectItem<DaylightSensorFloorObject>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Daylight Sensors");
        public override LocString DisplayDescription => Localizer.DoStr("A sensor that detects when it's day.");
    }

    [RequiresSkill(typeof(ElectronicsSkill), 0)]
    public partial class DaylightSensorFloorRecipe : RecipeFamily
    {
        public DaylightSensorFloorRecipe()
        {
            this.Recipes = new List<Recipe>
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
            Initialize(Localizer.DoStr("Daylight Sensor (Floor)"), typeof(DaylightSensorFloorRecipe));
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }
}
