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

namespace Eco.EM.Energy.Sensors
{
    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LightSwitchObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Light Switch");

        static LightSwitchObject()
        {
            AddOccupancy<LightSwitchObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f))
            });
        }

        public override void Tick()
        {
            Framework.Helpers.Sensors.LightsSensor(this);
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(200)]
    [LocDisplayName("Light Switch")]
    public partial class LightSwitchItem : Item
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Light Switches");
        public override LocString DisplayDescription => Localizer.DoStr("A Light Switch for turning on or off all lights in a room at the same time.");
    }

    public partial class LightSwitchRecipe : RecipeFamily
    {

    }
}
