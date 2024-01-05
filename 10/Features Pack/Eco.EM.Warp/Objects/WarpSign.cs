using System;
using System.Linq;
using Eco.Core.Systems.Registrar;
using Eco.Core.Utils;
using Eco.Gameplay.Civics.Demographics;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.GameActions;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Interactions.Interactors;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Utils;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Shared.SharedTypes;

namespace Eco.EM.Warp
{
    [Serialized]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class WarpSignObject : WorldObject, IRepresentsItem, IHasInteractions
    {
        public override LocString DisplayName => Localizer.DoStr("Warp Sign");
        public virtual Type RepresentedItemType => typeof(WarpSignItem);

        protected override void Initialize()
        {
            GetComponent<CustomTextComponent>().Initialize(700);
            GetComponent<AuthComponent>().Owners.

        }

        [Interaction(InteractionTrigger.RightClick, "Warp", flags: InteractionFlags.BlocksOtherInteraction)]
        public void Warp(Player context, InteractionTriggerInfo triggerInfo, InteractionTarget target)
        {
            var text = GetComponent<CustomTextComponent>().TextData.Text;

            if (!string.IsNullOrWhiteSpace(text) && text.ToLower().Contains("warp to "))
            {

                var ltrimd = text.Remove(0, text.IndexOf("warp to ") + 8);

                if (string.IsNullOrWhiteSpace(ltrimd))
                    return;

                var rtrimd = text.Remove(text.IndexOf(" "));

                if (string.IsNullOrWhiteSpace(rtrimd))
                    return;
                if (ltrimd.EndsWith(",") || ltrimd.EndsWith("."))
                    ltrimd.Remove(ltrimd.Length - 1);

                WarpCommands.SignWarpto(context.User, ltrimd);
            }
            else
                context.ErrorLocStr("No Warp point has been connected to this warp sign..");
        }


        [Interaction(InteractionTrigger.InteractKey, "Use", flags: InteractionFlags.BlocksOtherInteraction)]
        public void Used(Player player, InteractionTriggerInfo triggerInfo, InteractionTarget target)
        {
            if (!player.User.IsAdmin)
            {
                player.ErrorLocStr("Only an admin may change the content on this object.");
                return;
            }
            base.Use(player, target, triggerInfo);
        }
    }

    [Serialized]
    [LocDisplayName("Warp Sign")]
    [MaxStackSize(100)]
    [LocDescription("A large sign For Warp Points!")]
    public partial class WarpSignItem :
    WorldObjectItem<WarpSignObject>
    {
        static WarpSignItem() { }
    }
}