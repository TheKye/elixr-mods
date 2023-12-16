using System;
using System.Collections.Generic;
using Eco.Core.Controller;
using Eco.EM.Framework;
using Eco.EM.Framework.ChatBase;
using Eco.Gameplay.Components;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Utils;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Gameplay.Components.Auth;
using Eco.EM.Framework.Utils;
using System.Numerics;
using Eco.Shared.Utils;
using System.ComponentModel;
using Eco.Core.Properties;
using Eco.Gameplay.Occupancy;
using static Eco.Gameplay.Civics.IfThenBlock;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;

namespace Eco.EM.Warp
{
    [Serialized]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class WarpPointObject : WorldObject, IRepresentsItem, IPlayerUseTracking, INotifyPropertyChanged
    {
        public override LocString DisplayName => Localizer.DoStr("Community Warp Point");
        public virtual Type RepresentedItemType => typeof(WarpPointItem);

        [Serialized] private string NameRollback { get; set; } = "new point";

        protected override void Initialize()
        {
            GetComponent<CustomTextComponent>().Initialize(700);
            SetName(NameRollback);

            // watch for changes to the point name
            this.WatchPropAndCall(this, nameof(Name), () =>
            {
                var pointName = StringUtils.Sanitize(Name);
                switch (WarpManager.Data.GetPoint(pointName))
                {
                    case null:
                        WarpManager.Data.ChangePointName(this.Position, pointName);
                        PlayerUseTracking.ForEachPlayer(this, x =>
                        {
                            ChatBaseExtended.CBInfo(Defaults.appName + $"The community warp point {NameRollback} has been renamed to {pointName}", x.User);
                        });
                        NameRollback = pointName;
                        WarpManager.SaveData();
                        break;
                    case not null:
                        if (NameRollback != pointName)
                        {
                            SetName(NameRollback);
                            PlayerUseTracking.ForEachPlayer(this, x =>
                            {
                                ChatBaseExtended.CBError(Defaults.appName + $"A warp point already exists with that name set, please choose a different name", x.User);
                            });
                        }
                        break;
                }
            });
        }

        public void OnActLeft(Player context)
        {
            if (!context.User.IsAdmin)
            {
                context.ErrorLocStr("Only an admin may remove this object");
                return;
            }
        }

        public void OnActInteract(Player context)
        {
            if (!context.User.IsAdmin)
            {
                context.ErrorLocStr("Only an admin may change the content on this object.");
                return;
            }
        }

        static WarpPointObject()
        {
            AddOccupancy<WarpPointObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 2, 0), typeof(WorldObjectBlock)),
            });
        }

        protected override void OnDestroy()
        {
            var pointName = StringUtils.Sanitize(this.GivenName);
            WarpManager.Data.RemovePoint(pointName);
            WarpManager.SaveData();
            base.OnDestroy();
        }
    }

    [Serialized]
    [LocDisplayName("Warp Point")]
    [MaxStackSize(100)]
    [LocDescription("A Community Warp Point!")]
    public partial class WarpPointItem : WorldObjectItem<WarpPointObject>
    {
        static WarpPointItem() { }


        public override Task<bool> CanPlaceObject(Player player, Vector3i position, Eco.Shared.Math.Quaternion rotation)
        {
            var text = "new point";

            if (!WarpManager.Data.AddPoint(text, (Vector3)position, rotation))
            {
                ChatBaseExtended.CBError(Defaults.appName + $"A warp point already exists that has not had it's name set, please set or remove that point first", player.User);
                return Task.FromResult(false);
            }

            if (!base.CanPlaceObject(player, position, rotation).Result)
            {
                WarpManager.Data.RemovePoint(text);
                return Task.FromResult(false);
            }

            WarpManager.SaveData();
            return Task.FromResult(true);
        }
    }
}