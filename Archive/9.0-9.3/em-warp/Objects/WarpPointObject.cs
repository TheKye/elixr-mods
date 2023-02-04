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

namespace Eco.EM.Warp
{
    [Serialized]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class WarpPointObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Community Warp Point"); } }
        public virtual Type RepresentedItemType { get { return typeof(WarpPointItem); } }

       [Serialized] private string NameRollback { get; set; } = "new point";
        private bool internalPropChange = false;

        protected override void Initialize()
        {
            GetComponent<CustomTextComponent>().Initialize(700);
            SetName(NameRollback);
            // watch for changes to the point name
            this.WatchProp(nameof(GivenName), val =>
            { 
                var pointName = Base.Sanitize(GivenName);
                
                // check if we already have a point with that name
                if (!internalPropChange && WarpManager.Data.GetPoint(pointName) != null)
                {
                    // This will send to each player interacting with the point, I don't see another way to do this yet.
                    PlayerUseTracking.ForEachPlayer(this.UsingPlayers, x =>
                    {
                    ChatBaseExtended.CBError(Base.appName + $"A warp point already exists with that name set, please choose a different name", x.User);
                    });
                    internalPropChange = true;
                    SetName(NameRollback);
                    internalPropChange = false;
                }
                else
                {
                    WarpManager.Data.ChangePointName(this.Position, pointName);
                    ChatBaseExtended.CBError(Base.appName + $"The community warp point {NameRollback} has been renamed to {pointName}");
                    NameRollback = pointName;
                    WarpManager.SaveData();
                }               
            });         
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

        static WarpPointObject()
        {
            AddOccupancy<WarpPointObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 2, 0), typeof(WorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            var pointName = Base.Sanitize(this.GivenName);
            WarpManager.Data.RemovePoint(pointName);
            WarpManager.SaveData();
            base.Destroy();
        }
    }

    [Serialized]
    [LocDisplayName("Warp Point")]
    [MaxStackSize(100)]
    public partial class WarpPointItem : WorldObjectItem<WarpPointObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Community Warp Point!"); } }

        static WarpPointItem() { }

        public override bool TryPlaceObject(Player player, Vector3i position, Quaternion rotation)
        {
            var text = "new point";

            if (!WarpManager.Data.AddPoint(text,position,rotation))
            {
                ChatBaseExtended.CBError(Base.appName + $"A warp point already exists that has not had it's name set, please set or remove that point first", player.User);
                return false;
            }

            if (!base.TryPlaceObject(player, position, rotation))
            {
                WarpManager.Data.RemovePoint(text);
                return false;
            }

            WarpManager.SaveData();

            return true;
        }
    }
}