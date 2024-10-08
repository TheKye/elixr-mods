﻿using Eco.EM.Energy.Sensors.Components;
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
    #region Ceiling Mountable
    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class ProximitySensorCeilingObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Proximity Sensor (Ceiling)"); } }
        public float Range = 20f;

        static ProximitySensorCeilingObject()
        {
            AddOccupancy<ProximitySensorCeilingObject>(new List<BlockOccupancy>(){
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
            Framework.Helpers.Sensors.ProximitySensor(this, Range);
            Helpers.toggleProxim(this);
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(200)]
    [LocDisplayName("Proximity Sensor - Ceiling")]
    public partial class ProximitySensorCeilingItem : WorldObjectItem<ProximitySensorCeilingObject>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Proximity Sensors"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A sensor that detects when players are close by."); } }

    }

    [RequiresSkill(typeof(ElectronicsSkill), 4)]
    public partial class ProximitySensorCeilingRecipe : RecipeFamily
    {
        public ProximitySensorCeilingRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Proximity Sensor - Ceiling",
                    Localizer.DoStr("Proximity Sensor - Ceiling"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(PlasticItem), 4, typeof(ElectronicsSkill)),
                    new IngredientElement(typeof(IronBarItem), 1, typeof(ElectronicsSkill)),
                    new IngredientElement(typeof(BasicCircuitItem), 1, typeof(ElectronicsSkill))
                    },
                    new CraftingElement<ProximitySensorCeilingItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(ElectronicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ProximitySensorCeilingRecipe), 1, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Proximity Sensor (Ceiling)"), typeof(ProximitySensorCeilingRecipe));
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
