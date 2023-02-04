namespace Eco.EM.Artistry.Components
{
    using Eco.Core.Controller;
    using Eco.Core.IoC;
    using Eco.Core.Utils;
    using Eco.Gameplay.Aliases;
    using Eco.Gameplay.Auth;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Shared.Networking;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Gameplay.Utils;
    using Eco.Shared.Items;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Localization;

    [Serialized]
    public class ImageLoader : IController
    {
        #region IController
        private int controllerID;
        ref int IController.ControllerID => ref this.controllerID;
        #endregion
        [Serialized, SyncToView] public string url { get; set; }
    }

    [Serialized]
    public class CustomTextComponent : WorldObjectComponent, IPersistentData
    {
        public override WorldObjectComponentClientAvailability Availability => WorldObjectComponentClientAvailability.Always;

        [SyncToView] int MaxStringLength { get; set; }
        [Serialized, SyncToView, TooltipChildren] public ImageLoader img { get; set; } = new ImageLoader();

        object IPersistentData.PersistentData { get => this.img; set => this.img = value as ImageLoader ?? new ImageLoader(); }

        public void Initialize(int maxLength)
        {
            this.MaxStringLength = maxLength;
        }

        [OnDeserialized]
        public void OnDeserialized()
        {
            this.img = this.img;
        }

        [RPC]
        public bool LoadFromUrl(Player player, string url)
        {
            if (ServiceHolder<IAuthManager>.Obj.IsAuthorized(this.Parent, player?.User, AccessType.ConsumerAccess, null).Notify(player))
            {
                this.img.Changed(nameof(this.img));
                this.Parent.SetDirty();

                return true;
            }
            else
                return false;
        }
    }
}
