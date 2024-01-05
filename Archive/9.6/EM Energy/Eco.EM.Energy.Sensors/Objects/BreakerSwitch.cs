using Eco.EM.Energy.Sensors.Components;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Interactions;
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
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerConsumptionComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class BreakerSwitchObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Breaker Switch"); 

        static BreakerSwitchObject()
        {
            AddOccupancy<BreakerSwitchObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f))
            });
        }

        protected override void Initialize()
        {
            GetComponent<PowerGridComponent>().Initialize(1, new ElectricPower());
            GetComponent<PowerConsumptionComponent>().Initialize(1);
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(4);
            storage.Inventory.AddInvRestriction(new SpecificItemTypesRestriction(typeof(FuseItem)));
        }

        public override InteractResult OnActRight(InteractionContext context)
        {
            var IsTurnedOn = !GetComponent<OnOffComponent>().On;

            this.SetAnimatedState("On", IsTurnedOn);
            return base.OnActRight(context);
        }

        public override void Tick()
        {
            var storage = this.GetComponent<PublicStorageComponent>();

            int items = storage.Storage.Stacks.SumQuantites();
            Framework.Helpers.Sensors.PowerSensor(this);
            Helpers.PowerOverloadSwitch(this);
            this.SetAnimatedState("FuseCount", items);
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(200)]
    [LocDisplayName("Breaker Switch")]
    public partial class BreakerSwitchItem : WorldObjectItem<BreakerSwitchObject>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Breaker Switches");
        public override LocString DisplayDescription => Localizer.DoStr("A Power Switch for turning on or off anything that uses power in the same House at the same time to save power. It also has a built in overload switch that will trip if the facility uses more power then what is available.");
    }

    public partial class BreakerSwitchRecipe : RecipeFamily
    {

    }
}
