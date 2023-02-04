namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.EM.Helpers;
    using Eco.EM.Warp;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Serialization;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(CustomTextComponent))]
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

        /*public override InteractResult OnActRight(InteractionContext context)
        {
            var text = GetComponent<CustomTextComponent>().SetText();

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

                EM.Warp.WarpCommands.Warp(context.Player.User, ltrimd);
            }
            return base.OnActRight(context);
            
        }*/
    }

    [Serialized]
    public partial class WarpSignItem :
    WorldObjectItem<WarpSignObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Warp Sign"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A large sign Warp Points!"); } }

        static WarpSignItem()
        {

        }


    }

}