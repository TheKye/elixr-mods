using System;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

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

        public override void Destroy()
        {
            base.Destroy();
        }

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (!context.Player.User.IsAdmin)
            {
                context.Player.ErrorLocStr("Only an admin may remove this object");
                return InteractResult.Fail;
            }
            return base.OnActLeft(context);
        }

        public override InteractResult OnActInteract(InteractionContext context)
        {
            if (!context.Player.User.IsAdmin)
            {
                context.Player.ErrorLocStr("Only an admin may change the content on this object.");
                return InteractResult.Fail;
            }
            return base.OnActInteract(context);
        }

        public override InteractResult OnActRight(InteractionContext context)
        {
            var text = GetComponent<CustomTextComponent>().TextData.Text;

            if (!string.IsNullOrWhiteSpace(text) && text.ToLower().Contains("warp to "))
            {

                var ltrimd = text.Remove(0, text.IndexOf("warp to ") + 8);

                if (string.IsNullOrWhiteSpace(ltrimd))
                    return base.OnActRight(context);

                var rtrimd = text.Remove(text.IndexOf(" "));

                if (string.IsNullOrWhiteSpace(rtrimd))
                    return base.OnActRight(context);
                if (ltrimd.EndsWith(",") || ltrimd.EndsWith("."))
                    ltrimd.Remove(ltrimd.Length - 1);

                WarpCommands.SignWarpto(context.Player.User, ltrimd);
            }
            return base.OnActRight(context);

        }
    }

    [Serialized]
    [LocDisplayName("Warp Sign")]
    [MaxStackSize(100)]
    public partial class WarpSignItem :
    WorldObjectItem<WarpSignObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A large sign For Warp Points!"); } }

        static WarpSignItem()
        {

        }


    }
}
