﻿using Eco.Core.Controller;
using Eco.EM.Framework.Extentsions;
using Eco.EM.Framework.Helpers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using System;

namespace Eco.EM.Framework.Components
{
    [Eco, AutogenClass, LocDisplayName("Automatic Doors")]
    public class AutoDoorComponent : WorldObjectComponent
    {
        private StatusElement status;

        float detectionRange = 4;
        bool allowGuests = false;

        [Eco, ClientInterfaceProperty, GuestHidden]
        public float DetectionRange
        {
            get => this.detectionRange;
            set
            {
                if (value == this.detectionRange) return;
                this.detectionRange = value;
                this.Changed(nameof(this.DetectionRange));
            }
        }

        [Eco, ClientInterfaceProperty, GuestHidden]
        public bool AllowGuests
        {
            get => this.allowGuests;
            set
            {
                if (value == this.allowGuests) return;
                this.allowGuests = value;
                this.Changed(nameof(this.AllowGuests));
            }
        }

        public override bool Enabled => true;

        [Serialized] public bool enabled { get; set; }

        public WorldObject Object { get; set; }
        public AutoDoorComponent() { }
        public AutoDoorComponent(float detectionRange, bool allowGuests)
        {
            DetectionRange = detectionRange;
            AllowGuests = allowGuests;
        }

        public void Initialize(WorldObject obj)
        {
            Object = obj;
            base.Initialize();
            if (!Object.HasComponent<StatusComponent>())
                throw new NotImplementedException("Status Component Is Required in order to use the Auto Door Component.");
            status = Object.GetComponent<StatusComponent>().CreateStatusElement();
            status.SetStatusMessage(true, Localizer.DoStr(string.Format("Automatic Door Module Installed, Automatic Doors Enabled and are {0}", enabled ? "Working!" : "Idle.")));
        }

        [RPC, Autogen]
        public virtual void EnableAutoDoor(Player player)
        {
            enabled = true;
            Tick();
        }

        [RPC, Autogen]
        public virtual void DisableAutoDoor(Player player)
        {
            enabled = false;
        }

        public override void Tick()
        {
            if (enabled)
                OperateAutoDoor();
            base.Tick();
            status.SetStatusMessage(true, Localizer.DoStr(string.Format("Automatic Door Module Installed, Automatic Doors Enabled and are {0}", enabled ? "Working!" : "Idle.")));
        }

        protected virtual void OperateAutoDoor()
        {
            if (!enabled) return;
            NetObjectManager.Default
                .GetObjectsWithin(Parent.Position.XYZi, 2)
                .ForEach(obj =>
                {
                    switch (obj)
                    {
                        case DoorObject wo when Parent is WorldObject:
                            if (wo.Open && PlayerSensor.AuthorizedPersonnelNear(wo, (int)DetectionRange) || wo.Open && PlayerSensor.AnyoneNear(wo, (int)DetectionRange) && AllowGuests)
                                return;

                            wo.SetOpen(PlayerSensor.AuthorizedPersonnelNear(wo, (int)DetectionRange) || PlayerSensor.AnyoneNear(wo, (int)DetectionRange) && AllowGuests);
                            break;

                        case EmDoor woe when Parent is WorldObject:
                            if (woe.Open && PlayerSensor.AuthorizedPersonnelNear(woe, (int)DetectionRange) || woe.Open && PlayerSensor.AnyoneNear(woe, (int)DetectionRange) && AllowGuests)
                                return;

                            woe.SetOpen(PlayerSensor.AuthorizedPersonnelNear(woe, (int)DetectionRange) || PlayerSensor.AnyoneNear(woe, (int)DetectionRange) && AllowGuests);
                            break;

                        case WorldObject wod when Parent is WorldObject && wod.HasComponent<OnOffComponent>():
                            {
                                var on = wod.GetComponent<OnOffComponent>();
                                if (!on.On && PlayerSensor.AuthorizedPersonnelNear(wod, (int)DetectionRange) || !on.On && PlayerSensor.AnyoneNear(wod, (int)DetectionRange) && AllowGuests)
                                    return;
                                bool open = false;
                                if (PlayerSensor.AuthorizedPersonnelNear(wod, (int)DetectionRange) || PlayerSensor.AnyoneNear(wod, (int)DetectionRange) && AllowGuests)
                                    open = false;
                                else
                                    open = true;
                                on.SetOnOff(null, open);
                                break;
                            }
                    }
                });
        }
    }
}
