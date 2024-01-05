using System;
using System.Collections.Generic;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Games.BoardGames
{
    [Serialized, LocDisplayName("Pin Hit - Floor"), MaxStackSize(500)]
    public partial class PinFloorHitItem : WorldObjectItem<PinFloorHitObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("The Hit Pin for playing Battleship, Used To Mark a Hit On Your Ship");
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class PinFloorHitObject : BattleshipBase, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Pin Hit - Floor");

        public Type RepresentedItemType => typeof(PinFloorHitItem);

        static PinFloorHitObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>
            {
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock))
            };

            AddOccupancy<PinFloorHitObject>(BlockOccupancyList);
        }

        public override InteractResult OnActRight(InteractionContext context)
        {

            if (context.SelectedItem != null &&
                   context.Target.GetType() == typeof(PatrolBoatObject)
                || context.Target.GetType() == typeof(BattleshipObject)
                || context.Target.GetType() == typeof(DestroyerObject)
                || context.Target.GetType() == typeof(SubmarineObject)
                || context.Target.GetType() == typeof(CarrierObject))
                {
                Vector3i abovePos = Position3i;
                Quaternion playerFace = context.Player.User.FacingDir.Rotate180().ToQuat();
                do
                {
                    abovePos.Y += 1;
                }
                while (WorldUtils.WorldObjectsAtPos(abovePos) != null);
                WorldObjectManager.TryPlaceWorldObject(context.Player, (WorldObjectItem)context.SelectedItem, abovePos, playerFace);
                return InteractResult.Success;
            }

            return base.OnActRight(context);
        }


    }

    //Todo Add Recipe
    public partial class PinFloorHitRecipe : RecipeFamily
    {

    }

    [Serialized, LocDisplayName("Pin Hit - Wall"), MaxStackSize(500)]
    public partial class PinWallHitItem : WorldObjectItem<PinWallHitObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("The Hit Pin for playing Battleship, Used to Mark a Hit on the Wall");
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class PinWallHitObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Pin Hit - Wall");

        public Type RepresentedItemType => typeof(PinWallHitItem);

        static PinWallHitObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>
            {
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock))
            };

            AddOccupancy<PinWallHitObject>(BlockOccupancyList);
        }

    }

    //Todo Add Recipe
    public partial class PinWallHitRecipe : RecipeFamily
    {

    }
}
