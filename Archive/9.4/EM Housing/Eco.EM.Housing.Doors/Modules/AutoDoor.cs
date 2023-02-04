namespace Eco.EM.Framework.AutoDoors
{
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
    using Eco.EM.Framework;
    using Eco.EM.Framework.Helpers;
    using Eco.EM.Framework.FileManager;
    using Eco.EM.Framework.ChatBase;
    using Eco.Mods.TechTree;
    using Eco.Core.Utils;
    using Eco.EM.Framework.Console;

    public class AutoDoors : IChatCommandHandler, IModKitPlugin, IInitializablePlugin
    {

        public const string appName = "<color=purple>[Elixr Mods]:</color> ";
        public static AutoDoorConfig config { get; set; }
        private static bool loaded { get; set; }
        private static bool adOn { get; set; }
        private static string Filename = "AutoDoor";
        private const string _subPath = "/EM/AutoDoors";

        public AutoDoors()
        {
            if (!File.Exists(Base.SaveLocation + _subPath + Filename))
            {
                SaveConfig();
            }
            config = LoadConfig();
            SaveConfig();
        }

        public static void adPermissions()
        {

        }

        private static void Load()
        {
            if (!File.Exists(Base.SaveLocation + _subPath + Filename))
            {
                SaveConfig();
            }
            if (!loaded)
            {
                FileManager<AutoDoorConfig>.ReadFromFile(Base.SaveLocation + _subPath, Filename);
                loaded = true;
                adOn = config.AutoDoorOn;
                Save();
            }
            else
            {
                FileManager<AutoDoorConfig>.ReadFromFile(Base.SaveLocation + _subPath, Filename);
            }
        }

        private static void Save()
        {
            FileManager<AutoDoorConfig>.WriteToFile(config, Base.SaveLocation, Filename);
        }
        #region Commands
        [ChatCommand("The Commands to use The Elixr Mods Auto Doors Components")]
        public static void autodoors() { }

        [ChatSubCommand("autodoors", "Enables The Auto Doors Function For All Users", "ad-on")]
        public static void AdOn(User user)
        {
            Load();
            ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "Auto Doors have been enabled!"), user)));
            config.AutoDoorOn = true;
            Save();

        }
        [ChatSubCommand("autodoors", "Disables The Auto Doors Function For All Users", "ad-off")]
        public static void AdOff(User user)
        {
            Load();
            ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "Auto Doors have been disabled!"), user)));
            config.AutoDoorOn = false;
            Save();
        }

        [ChatSubCommand("autodoors", "Set the detection range for the small auto doors", "ad-range-small", ChatAuthorizationLevel.Admin)]
        public static void AdRangeSmall(User user, int door)
        {
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

        [ChatSubCommand("autodoors", "Set the detection range for the large auto doors", "ad-range-large")]
        public static void AdRangeLarge(User user, int ldoor)
        {
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
        #endregion

        public string GetStatus()
        {
            if (!adOn)
                return "Not Active";
            else
                return "Active";
        }
        #region AD Component
        [Serialized]
        [RequireComponent(typeof(PropertyAuthComponent))]
        [RequireComponent(typeof(OnOffComponent))]
        public partial class AutoDoor : WorldObject, IAutoDoor, INetObject, IWireContainer
        {
            [Serialized] public bool OpensOut { get; set; }
            [Serialized] public bool Open { get; private set; }

            public AutoDoor() { Load(); }

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

            protected void OnCreate(User creator)
            {
                base.OnCreate();
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

            protected void OnCreate(User creator)
            {
                base.OnCreate();
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
        #endregion
        private AutoDoorConfig LoadConfig()
        {
            return FileManager<AutoDoorConfig>.ReadFromFile(Base.SaveLocation + _subPath, Filename);
        }

        public static void SaveConfig()
        {
            FileManager<AutoDoorConfig>.WriteToFile(config, Base.SaveLocation + _subPath, Filename);
        }

        public void Initialize(TimedTask timer)
        {
            string adstat = "";
            if (adOn)
            {
                adstat = "Active";
            }
            else adstat = "Not Active";
            ConsoleWriter.TextWriter(System.ConsoleColor.Magenta, Base.appNameCon, System.ConsoleColor.DarkYellow, Filename, System.ConsoleColor.Red, " V 2.0.0");
            ConsoleWriter.TextWriter(System.ConsoleColor.Magenta, Base.appNameCon, System.ConsoleColor.DarkYellow, Filename + " Status: ", System.ConsoleColor.Red, adstat);
        }
    }
}
