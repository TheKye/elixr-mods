using Eco.Gameplay.Audio;
using Eco.Gameplay.Components;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Gameplay.Wires;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using System.Collections.Generic;
using Eco.Core.Plugins.Interfaces;
using System.IO;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Shared.IoC;
using Eco.Gameplay.Auth;

/// <summary>
/// This is out basic component to add to all our windows for their functionality, This is just so 
/// we don't need to add all these on each window
/// </summary>

namespace Eco.EM.Building.Windows
{
    [Serialized]
    [RequireComponent(typeof(StatusComponent), null)]
    public abstract class WindowObject : WorldObject
    {

        [Serialized] public bool OpensOut { get; set; }
        [Serialized] public bool Open { get; set; }
        [Serialized] public bool HasModule { get; set; }
        [Serialized] public float Range { get; set; }

        public override InteractResult OnActRight(InteractionContext context)
        {
            if (context != null)
            {
                var isAuthorized = ServiceHolder<IAuthManager>.Obj.IsAuthorized(context);
                if (isAuthorized)
                {
                    if (!HasModule)
                    {
                        ToggleOpen();
                        return InteractResult.NoOp;
                    }
                    else
                        return InteractResult.Success;
                }
                else
                {
                    context.Player.ErrorLocStr("You Are Not Authorized To Do That");
                    return InteractResult.Fail;
                }
            }
            else
                return InteractResult.Success;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void PostInitialize()
        {
            SetState(Open);
            base.PostInitialize();
        }

        public override void SendInitialState(BSONObject bsonObj, INetObjectViewer viewer)
        {
            base.SendInitialState(bsonObj, viewer);
            bsonObj["open"] = this.Open;
            bsonObj["opensOut"] = this.OpensOut;
        }

        private void ToggleOpen()
        {
            if (Open)
            {
                SetClosed();
            }
            else
            {
                SetOpen();
            }
            this.SetDirty();
        }

        public void SetState(bool State)
        {
            if (State)
                SetOpen();
            else
                SetClosed();
        }

        public void SetOpen()
        {
            AudioManager.PlayAudio("Doors/DoorOpenSfx", Position);
            SetAnimatedState("Open", true);
            Open = true;
            RPCManager.Call("Open", netEntity, null);
        }

        public void SetClosed()
        {
            AudioManager.PlayAudio("Doors/DoorCloseSfx", Position);
            SetAnimatedState("Open", false);
            Open = false;
            RPCManager.Call("Close", netEntity, null);
        }
    }
}