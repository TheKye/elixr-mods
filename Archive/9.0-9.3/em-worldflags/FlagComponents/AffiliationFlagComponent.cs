using Eco.Shared.Networking;
using Eco.Core.Controller;
using Eco.Shared.Localization;
using Eco.Gameplay.Players;
using Eco.Shared.Serialization;

namespace Eco.EM.Flags
{
    [Eco]
    public enum AffiliationFlag
    {
        // Modders
        ElixrMods,
        
        // Civil
        Cornwall,

        // Requested specials
        UnitedFederationOfPlanets,
    }

    [Serialized, AutogenClass, LocDisplayName("Affiliates Flag Selection")]
    public partial class AffiliationFlagComponent : FlagComponent
    {
        [Eco, ClientInterfaceProperty, GuestHidden] public AffiliationFlag FlagOption { get; set; }

        [RPC, Autogen, GuestHidden]
        public void SetFlag(Player player)
        {
            this.Parent.SetAnimatedState("FlagChange", FlagOption.GetName());
        }

        public override void Initialize()
        {
            base.Initialize();
            this.Parent.SetAnimatedState("FlagChange", FlagOption.GetName());
        }
    }
}