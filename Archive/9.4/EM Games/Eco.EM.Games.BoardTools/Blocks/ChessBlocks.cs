using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Games.BoardTools
{
    [Serialized]
    [Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ChessFloorFormType), typeof(GameBoardItem))]
    public partial class ChessFloorBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GameBoardItem);
    }
}