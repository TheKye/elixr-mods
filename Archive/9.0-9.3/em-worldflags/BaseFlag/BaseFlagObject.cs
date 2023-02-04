using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.Flags
{
    // The base flag for concrete flags to inherit from. 
    // The animation and room checking are set here so other flags don't need to implement them.
    [Serialized]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public abstract class BaseFlagObject : WorldObject
    {
        public bool Outside => SetOutside();

        public BaseFlagObject()
        {
            this.RoomChanged.Add(CheckRoom);
            CheckRoom();
        }

        private bool SetOutside() { return this.Room == Gameplay.Rooms.Room.Global; }

        public void CheckRoom() => this.SetAnimatedState("Enabled", Outside);

        protected override void PostInitialize()
        {
            base.PostInitialize();
            CheckRoom();
        }
    }
}