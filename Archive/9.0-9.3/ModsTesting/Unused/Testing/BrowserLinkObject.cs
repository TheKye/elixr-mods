using Eco.Core.Utils;
using Eco.Gameplay.Components;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Plugins.Networking;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;

namespace Eco.EM.Framework
{
    [Serialized]
    [RequireComponent(typeof(StatusComponent))]
    public partial class BrowserLinkObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Browser Linker"); 

        public override TableTextureMode TableTexture => TableTextureMode.Wood;

        public virtual Type RepresentedItemType { get { return typeof(BrowserLinkItem); } }

        static BrowserLinkObject() 
        {
            AddOccupancy<BrowserLinkObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            });
        }

        [RPC] public void OpenBrowser(InteractionContext x, string url)
        {
            this.RPC("OpenBrowser", x.Player.Client, url);
            Log.WriteLine(Localizer.DoStr($"Open Browser"));
        }

        public override InteractResult OnActRight(InteractionContext context)
        {
            OpenBrowser(context, NetworkManager.Config.DiscordAddress);
            return InteractResult.Success;
        }

        protected override void Initialize()
        {
            
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized]
    [LocDisplayName("Browser Link item")]
    public partial class BrowserLinkItem : WorldObjectItem<BrowserLinkObject>, IPersistentData
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Browser Linker Item"); } }

        static BrowserLinkItem()
        {

        }

        [Serialized, TooltipChildren] public object PersistentData { get; set; }
    }
}
