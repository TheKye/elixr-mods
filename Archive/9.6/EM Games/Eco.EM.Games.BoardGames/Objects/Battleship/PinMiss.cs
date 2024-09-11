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
    [Serialized, LocDisplayName("Pin Miss - Floor"), MaxStackSize(500)]
    public partial class PinFloorMissItem : WorldObjectItem<PinFloorMissObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("The Miss Pin for playing Battleship, Used To Mark a miss");
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class PinFloorMissObject : BattleshipBase, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Pin Miss - Floor");

        public Type RepresentedItemType => typeof(PinFloorMissItem);

        static PinFloorMissObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>
            {
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock))
            };

            AddOccupancy<PinFloorMissObject>(BlockOccupancyList);
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
    public partial class PinFloorMissRecipe : RecipeFamily
    {

    }

    [Serialized, LocDisplayName("Pin Miss - Wall"), MaxStackSize(500)]
    public partial class PinWallMissItem : WorldObjectItem<PinWallMissObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("The Miss Pin for playing Battleship, Used to Mark a Miss on the Wall");
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class PinWallMissObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Pin Miss - Wall");

        public Type RepresentedItemType => typeof(PinWallMissItem);

        static PinWallMissObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>
            {
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock))
            };

            AddOccupancy<PinWallMissObject>(BlockOccupancyList);
        }
    }

    //Todo Add Recipe
    public partial class PinWallMissRecipe : RecipeFamily
    {

    }
}
