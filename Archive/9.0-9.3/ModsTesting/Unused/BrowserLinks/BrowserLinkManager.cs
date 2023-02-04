using Eco.Core.Controller;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using System;

namespace Eco.EM.Framework.BrowserLinks
{
    public class BrowserLinkManager : INetObject, IController, IModKitPlugin, IInitializablePlugin
    {
        private NetObject netObject;

        // Singleton Access
        public static BrowserLinkManager Obj { get; private set; }

        public int ID => netObject.ID;
        public bool Active { get => this.netObject.Active; private set => this.netObject.Active = value; }
        public double NetObjectCreationRealtime { get; set; } = TimeUtil.Seconds;

        public string GetStatus() => "EM Browser Links - Active";

        public override string ToString()
        {
            return Localizer.DoStr("EM - Browser Links");
        }

        public BrowserLinkManager()
        {
            this.netObject = new NetObject(this);
            this.Active = true;
            this.netObject.Create();
        }

        public void Initialize(TimedTask timer)
        {
            Obj = this;
        }

        [RPC] public void OpenBrowser(TooltipContext context, string url)
        {
            this.RPC("OpenBrowser", context.Player.Client, url);
        }

        public void SendInitialState(BSONObject bsonObj, INetObjectViewer viewer)
        {
            bsonObj["view"] = ControllerManager.PackageController(this, viewer.Client);
            bsonObj["id"] = this.ID;
            bsonObj["active"] = this.Active;
            bsonObj["type"] = nameof(BrowserLinkManager);
        }

        // There is no view to update
        public bool IsNotRelevant(INetObjectViewer viewer) => false;
        public bool IsRelevant(INetObjectViewer viewer) => true;
        public bool IsUpdated(INetObjectViewer viewer) => false;
        public void SendUpdate(BSONObject bsonObj, INetObjectViewer viewer) { }

        // If we recieve from client something has gone wrong.
        public void ReceiveInitialState(BSONObject bsonObj) { throw new NotImplementedException(); }
        public void ReceiveUpdate(BSONObject bsonObj) { throw new NotImplementedException(); }

        #region IController
        private int controllerID;
        ref int IController.ControllerID => ref this.controllerID;
        #endregion
    }
}
