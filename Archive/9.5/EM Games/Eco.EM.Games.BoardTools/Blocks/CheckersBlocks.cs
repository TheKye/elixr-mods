using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;

namespace Eco.EM.Games.BoardTools
{
    [Serialized]
    [Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CheckersFloorFormType), typeof(GameBoardItem))]
    public partial class CheckersFloorBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GameBoardItem);
    }
}