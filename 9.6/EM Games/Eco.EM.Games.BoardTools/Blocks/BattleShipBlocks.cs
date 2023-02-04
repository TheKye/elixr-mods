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
    [IsForm(typeof(BattleshipFloorFormType), typeof(GameBoardItem))]
    public partial class BattleshipFloorBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GameBoardItem);
    }

    [Serialized]
    [RotatedVariants(typeof(BattleshipWallBlock), typeof(BattleshipWall90Block), typeof(BattleshipWall180Block), typeof(BattleshipWall270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BattleshipWallFormType), typeof(GameBoardItem))]
    public partial class BattleshipWallBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GameBoardItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BattleshipWall90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BattleshipWall180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BattleshipWall270Block : Block
    { }
}
