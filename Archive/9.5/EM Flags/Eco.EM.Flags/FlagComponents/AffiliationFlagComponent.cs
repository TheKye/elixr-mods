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
        None,
        ElixrMods,
        Cornwall,
        UnitedFederationOfPlanets
    }

    [Serialized, AutogenClass, LocDisplayName("Affiliates Flag Selection")]
    public partial class AffiliationFlagComponent : FlagComponent
    {
        AffiliationFlag flagOption;
        [Eco, ClientInterfaceProperty, GuestHidden] public AffiliationFlag FlagOption 
        {
            get => flagOption;
            set
            {
                if (value == flagOption) return;
                flagOption = value;
                this.Changed(nameof(FlagOption));
            }
        }

        [RPC, Autogen("Set Flag")]
        public void SetFlag(Player player)
        {
            Parent.SetAnimatedState("FlagChange", FlagOption.GetName());
        }

        public override void Initialize()
        {
            base.Initialize();
            Parent.SetAnimatedState("FlagChange", FlagOption.GetName());
        }
    }
}