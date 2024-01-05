using Eco.Gameplay.Blocks;
using Eco.Shared.Localization;

namespace Eco.EM.Games.BoardTools
{

    public partial class BattleshipGroup : FormGroup
    {
        public override string Name => "Battleship";
        public override LocString DisplayName => Localizer.DoStr("Battleship");
        public override LocString DisplayDescription => Localizer.DoStr("Battleship");
        public override int SortOrder => 1;
    }

    public partial class ChessGroup : FormGroup
    {
        public override string Name => "Chess";
        public override LocString DisplayName => Localizer.DoStr("Chess");
        public override LocString DisplayDescription => Localizer.DoStr("Chess");
        public override int SortOrder => 2;
    }

    public partial class CheckersGroup : FormGroup
    {
        public override string Name => "Checkers";
        public override LocString DisplayName => Localizer.DoStr("Checkers");
        public override LocString DisplayDescription => Localizer.DoStr("Checkers");
        public override int SortOrder => 3;
    }
}