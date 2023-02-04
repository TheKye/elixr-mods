namespace Eco.EM.Components
{
    using Eco.Em.Interfaces;
    using Eco.EM.GreenEnergy;
    using Eco.Gameplay.Audio;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
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
    using Eco.EM.Items;
    using Eco.Core.Plugins.Interfaces;
    using System.IO;
    using Eco.EM;

    public class AutoDoors : IChatCommandHandler /*IModKitPlugin*/
    {
        public const string appName = "<color=purple>[Elixr Mods]:</color> ";
        private static bool loaded = false;

        private static AutoDoorConfig config = new AutoDoorConfig();
        private static string Filename = "AutoDoor.EM";

        private static void Load()
        {
            if (!File.Exists(Filename))
            {
                File.Create(Filename);
            }

            if (!loaded)
            {
                try
                {
                    config = FileManager<AutoDoorConfig>.ReadFromFile(Base.SaveLocation, Filename);
                    loaded = true;
                }
                catch
                {
                    throw new System.NotImplementedException();
                }
            }
        }

        private static void Save()
        {
            FileManager<AutoDoorConfig>.WriteToFile(config, Base.SaveLocation, Filename);
        }


        [ChatCommand("Enables autodoors", "autodoors-on",  ChatAuthorizationLevel.Admin)]
        public static void EnableAutoDoors(User user)
        {
            if (!config.Enable) return;

            Load();

                ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "Auto Doors have been enabled!"), user)));
                config.AutoDoorOn = true;
                Save();


        }
        [ChatCommand("Disables autodoors", "autodoors-off",  ChatAuthorizationLevel.Admin)]
        public static void DisableAutoDoors(User user)
        {
            if (!config.Enable) return;

            Load();

            ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "Auto Doors have been disabled!"), user)));
            config.AutoDoorOn = false;
            Save();
        }

        [ChatCommand("autodoor-distance", "Set the detection range for the auto doors", ChatAuthorizationLevel.Admin)]
        public static void AutoDoorDistance(User user, int door)
        {
            if (!config.Enable) return;

            Load();
            if (door >= 1)
            {
                config.DoorSensor = door;
                ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "Auto Door Detection Range Changed to: {0}"), door), user));

            }
            if (string.IsNullOrEmpty(door.ToString()) || door == 0)
            {
                ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "Please input a number for the detection range (each number is classed as 1 block)"), user)));
            }

            Save();
        }

        [ChatCommand("largeautodoor-distance", "Set the detection range for the large auto doors", ChatAuthorizationLevel.Admin)]
        public static void LargeAutoDoorDistance(User user, int ldoor)
        {
            if (!config.Enable) return;

            Load();
            if (ldoor >= 1)
            {
                config.LdoorSensor = ldoor;
                ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "Large Auto Door Detection Range Changed to: {0}"), ldoor), user));
                Save();
            }
            if (ldoor == 0 || string.IsNullOrWhiteSpace(ldoor.ToString()))
            {
                ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "Please input a number for the detection range (each number is classed as 1 block)"), user)));
            }

        }

        public string GetStatus()
        {
            throw new System.NotImplementedException();
        }

        [RequireComponent(typeof(OnOffComponent))]
        public partial class AutoDoor : WorldObject, IAutoDoor, INetObject, IWireContainer
        {
            [Serialized] public bool OpensOut { get; set; }
            [Serialized] public bool Open { get; private set; }

            public AutoDoor() { }

            public void SetState(bool State)
            {
                if (State)
                    SetOpen();
                else
                    SetClosed();
            }

            public void SetOpen()
            {
                if (Open) return;
                AudioManager.PlayAudio("Doors/DoorOpenSfx", Position);
                SetAnimatedState("Enabled", false);
                Open = true;

                RPCManager.Call("Open", netEntity, null);

                SetDirty();
            }

            public void SetClosed()
            {
                if (!Open) return;

                AudioManager.PlayAudio("Doors/DoorCloseSfx", Position);
                SetAnimatedState("Enabled", true);
                Open = false;

                RPCManager.Call("Close", netEntity, null);

                SetDirty();
            }

            public void ToggleOpen()
            {
                if (Open)
                    SetClosed();
                else
                    SetOpen();
            }

            public override void Tick()
            {
                if(config.AutoDoorOn) { 
                Sensors.AuthorizedProximitySensor(this, config.DoorSensor);
                }
            }

            WireInput input;
            IEnumerable<WireConnection> IWireContainer.Wires { get { return input.SingleItemAsEnumerable(); } }

            public override InteractResult OnActRight(InteractionContext context)
            {
                if (!config.AutoDoorOn)
                {
                    ToggleOpen();
                    return InteractResult.NoOp;
                }
                else if (!GetComponent<OnOffComponent>().On && config.AutoDoorOn)
                {
                    ToggleOpen();
                    return InteractResult.NoOp;
                }
                else
                    return InteractResult.Success;
            }

            protected override void OnCreate(User creator)
            {
                base.OnCreate(creator);
                // determine open direction
                var placerPos = creator.Position;
                var toDoor = placerPos - Position;
                var facing = Rotation.RotateVector(Vector3.Forward);
                OpensOut = Vector3.Dot(toDoor, facing) < 0;
            }

            protected override void PostInitialize()
            {
                input = WireInput.CreateSignalInput(this, "Open Door", v => SetState(v == 0f ? false : true));
                base.Initialize();
            }

            public override void SendInitialState(BSONObject bsonObj, INetObjectViewer viewer)
            {
                base.SendInitialState(bsonObj, viewer);
                bsonObj["Closed"] = !Open;
                bsonObj["OpensOut"] = OpensOut;
            }
        }
        [RequireComponent(typeof(OnOffComponent))]
        public partial class LAutoDoor : WorldObject, IAutoDoor, INetObject, IWireContainer
        {
            [Serialized] public bool OpensOut { get; set; }
            [Serialized] public bool Open { get; private set; }

            public LAutoDoor() { }

            public void SetState(bool State)
            {
                if (State)
                    SetOpen();
                else
                    SetClosed();
            }

            public void SetOpen()
            {
                if (Open) return;
                AudioManager.PlayAudio("Doors/DoorOpenSfx", Position);
                SetAnimatedState("Enabled", false);
                Open = true;

                RPCManager.Call("Open", netEntity, null);

                SetDirty();
            }

            public void SetClosed()
            {
                if (!Open) return;

                AudioManager.PlayAudio("Doors/DoorCloseSfx", Position);
                SetAnimatedState("Enabled", true);
                Open = false;

                RPCManager.Call("Close", netEntity, null);

                SetDirty();
            }

            public void ToggleOpen()
            {
                if (Open)
                    SetClosed();
                else
                    SetOpen();
            }

            public override void Tick()
            {
                if (config.AutoDoorOn)
                {
                    Sensors.AAuthorizedProximitySensor(this, config.LdoorSensor);
                }
                
            }

            WireInput input;
            IEnumerable<WireConnection> IWireContainer.Wires { get { return input.SingleItemAsEnumerable(); } }

            public override InteractResult OnActRight(InteractionContext context)
            {

                if (!config.AutoDoorOn)
                {
                    ToggleOpen();
                    return InteractResult.NoOp;
                }
                else if (!GetComponent<OnOffComponent>().On && config.AutoDoorOn)
                {
                    ToggleOpen();
                    return InteractResult.NoOp;
                }
                else
                    return InteractResult.Success;
            }

            protected override void OnCreate(User creator)
            {
                base.OnCreate(creator);
                // determine open direction
                var placerPos = creator.Position;
                var toDoor = placerPos - Position;
                var facing = Rotation.RotateVector(Vector3.Forward);
                OpensOut = Vector3.Dot(toDoor, facing) < 0;
            }

            protected override void PostInitialize()
            {
                input = WireInput.CreateSignalInput(this, "Open Door", v => SetState(v == 0f ? false : true));
                base.Initialize();
            }

            public override void SendInitialState(BSONObject bsonObj, INetObjectViewer viewer)
            {
                base.SendInitialState(bsonObj, viewer);
                bsonObj["Closed"] = !Open;
                bsonObj["OpensOut"] = OpensOut;
            }
        }
    }
}
