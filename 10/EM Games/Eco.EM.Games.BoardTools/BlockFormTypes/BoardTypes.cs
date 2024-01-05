using Eco.Mods.TechTree;
using System;

namespace Eco.EM.Games.BoardTools
{
    public partial class BattleshipWallFormType : WallFormType
    {
        public override Type GroupType => typeof(BattleshipGroup);
    }

    public partial class BattleshipFloorFormType : FloorFormType
    {
        public override Type GroupType => typeof(BattleshipGroup);
    }

    public partial class ChessFloorFormType : FloorFormType
    {
        public override Type GroupType => typeof(ChessGroup);
    }

    public partial class CheckersFloorFormType : FloorFormType
    {
        public override Type GroupType => typeof(CheckersGroup);
    }
}
