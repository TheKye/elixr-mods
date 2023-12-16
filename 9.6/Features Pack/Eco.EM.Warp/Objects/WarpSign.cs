using System;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Interactions.Interactors;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.SharedTypes;

namespace Eco.EM.Warp
{
    [Serialized]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class WarpSignObject : WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Warp Sign"); } }
        public virtual Type RepresentedItemType { get { return typeof(WarpSignItem); } }

        protected override void Initialize()
        {
            GetComponent<CustomTextComponent>().Initialize(700);
        }

        public void OnActLeft(Player context)
        {
            if (!context.User.IsAdmin)
            {
                context.ErrorLocStr("Only an admin may remove this object");
                return;
            }
            
        }

        public override void Use(Player player, InteractionTarget target, InteractionTriggerInfo triggerInfo, string ui = "WorldObjectUI")
        {
            if (!player.User.IsAdmin)
            {
                player.ErrorLocStr("Only an admin may change the content on this object.");
                return;
            }

            base.Use(player, target, triggerInfo, ui);
        }

        [Interaction(InteractionTrigger.RightClick, "Warp")]
        public void Warp(Player context, InteractionTarget target, InteractionTriggerInfo triggerInfo)
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
        }
    }

    [Serialized]
    [LocDisplayName("Warp Sign")]
    [MaxStackSize(100)]
    [LocDescription("A large sign For Warp Points!")]
    public partial class WarpSignItem :
    WorldObjectItem<WarpSignObject>
    {
        static WarpSignItem()
        {

        }
    }
}