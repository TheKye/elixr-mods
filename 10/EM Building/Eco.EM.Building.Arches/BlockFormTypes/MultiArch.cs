using System;
using Eco.Gameplay.Blocks;
using Eco.Shared.Localization;

namespace Eco.EM.Building.Arches.BlockFormTypes
{

    public partial class BaseLeftFormType : FormType
    {
        public override string Name => "BaseLeft";
        public override LocString DisplayName => Localizer.DoStr("Arch Base Left");
        public override LocString DisplayDescription => Localizer.DoStr("Bottom Layer, Left Arch Piece");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }

    public partial class BaseMidFormType : FormType
    {
        public override string Name => "BaseMid";
        public override LocString DisplayName => Localizer.DoStr("Arch Base Mid");
        public override LocString DisplayDescription => Localizer.DoStr("Bottom Layer, Middle Arch Piece");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 2;
        public override int MinTier => 1;
    }

    public partial class BaseRightFormType : FormType
    {
        public override string Name => "BaseRight";
        public override LocString DisplayName => Localizer.DoStr("Arch Base Right");
        public override LocString DisplayDescription => Localizer.DoStr("Bottom Layer, Right Arch Piece");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 3;
        public override int MinTier => 1;
    }

    public partial class MidLeftFormType : FormType
    {
        public override string Name => "MidLeft";
        public override LocString DisplayName => Localizer.DoStr("Arch Mid Left");
        public override LocString DisplayDescription => Localizer.DoStr("Middle Layer, Left Arch Piece");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 4;
        public override int MinTier => 1;
    }

    public partial class MidMidFormType : FormType
    {
        public override string Name => "MidMid";
        public override LocString DisplayName => Localizer.DoStr("Arch Mid Mid");
        public override LocString DisplayDescription => Localizer.DoStr("Middle Layer, Middle Arch Piece");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 5;
        public override int MinTier => 1;
    }

    public partial class MidRightFormType : FormType
    {
        public override string Name => "MidRight";
        public override LocString DisplayName => Localizer.DoStr("Arch Mid Right");
        public override LocString DisplayDescription => Localizer.DoStr("Middle Layer, Right Arch Piece");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 6;
        public override int MinTier => 1;
    }

    public partial class TopLeftFormType : FormType
    {
        public override string Name => "TopLeft";
        public override LocString DisplayName => Localizer.DoStr("Arch Top Left");
        public override LocString DisplayDescription => Localizer.DoStr("Top Layer, Left Arch Piece");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 7;
        public override int MinTier => 1;
    }

    public partial class TopMidFormType : FormType
    {
        public override string Name => "TopMid";
        public override LocString DisplayName => Localizer.DoStr("Arch Top Mid");
        public override LocString DisplayDescription => Localizer.DoStr("Top Layer, Middle Arch Piece");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 8;
        public override int MinTier => 1;
    }

    public partial class TopRightFormType : FormType
    {
        public override string Name => "TopRight";
        public override LocString DisplayName => Localizer.DoStr("Arch Top Right");
        public override LocString DisplayDescription => Localizer.DoStr("Top Layer, Right Arch Piece");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 9;
        public override int MinTier => 1;
    }

    public partial class RoofLeftFormType : FormType
    {
        public override string Name => "RoofLeft";
        public override LocString DisplayName => Localizer.DoStr("Arch Roof Left");
        public override LocString DisplayDescription => Localizer.DoStr("Arch Roof Left Piece");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 10;
        public override int MinTier => 1;
    }

    public partial class ARoofMidFormType : FormType
    {
        public override string Name => "RoofMid";
        public override LocString DisplayName => Localizer.DoStr("Arch Roof Mid");
        public override LocString DisplayDescription => Localizer.DoStr("Arch Roof Middle Piece");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 11;
        public override int MinTier => 1;
    }

    public partial class RoofRightFormType : FormType
    {
        public override string Name => "RoofRight";
        public override LocString DisplayName => Localizer.DoStr("Arch Roof Right");
        public override LocString DisplayDescription => Localizer.DoStr("Arch Roof Right Piece");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 12;
        public override int MinTier => 1;
    }

    public partial class InnerCornerBaseFormType : FormType
    {
        public override string Name => "InnerCornerBase";
        public override LocString DisplayName => Localizer.DoStr("Arch Corner Base In.");
        public override LocString DisplayDescription => Localizer.DoStr("Arch Corner Piece, Bottom Layer (Inner)");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 13;
        public override int MinTier => 1;
    }

    public partial class InnerCornerMidFormType : FormType
    {
        public override string Name => "InnerCornerMid";
        public override LocString DisplayName => Localizer.DoStr("Arch Corner Mid In.");
        public override LocString DisplayDescription => Localizer.DoStr("Arch Corner Piece, Middle Layer (Inner)");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 14;
        public override int MinTier => 1;
    }

    public partial class InnerCornerTopFormType : FormType
    {
        public override string Name => "InnerCornerTop";
        public override LocString DisplayName => Localizer.DoStr("Arch Corner Top In.");
        public override LocString DisplayDescription => Localizer.DoStr("Arch Corner Piece, Top Layer (Inner)");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 15;
        public override int MinTier => 1;
    }

    public partial class InnerCornerRoofFormType : FormType
    {
        public override string Name => "InnerCornerRoof";
        public override LocString DisplayName => Localizer.DoStr("Arch Corner Roof In.");
        public override LocString DisplayDescription => Localizer.DoStr("Arch Corner Piece, Roof Layer (Inner)");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 16;
        public override int MinTier => 1;
    }

    public partial class OutterCornerBaseFormType : FormType
    {
        public override string Name => "OutterCornerBase";
        public override LocString DisplayName => Localizer.DoStr("Arch Corner Base Out.");
        public override LocString DisplayDescription => Localizer.DoStr("Arch Corner Piece, Bottom Layer (Outer)");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 17;
        public override int MinTier => 1;
    }

    public partial class OutterCornerMidFormType : FormType
    {
        public override string Name => "OutterCornerMid";
        public override LocString DisplayName => Localizer.DoStr("Arch Corner Mid Out.");
        public override LocString DisplayDescription => Localizer.DoStr("Arch Corner Piece, Middle Layer (Outer)");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 18;
        public override int MinTier => 1;
    }

    public partial class OutterCornerTopFormType : FormType
    {
        public override string Name => "OutterCornerTop";
        public override LocString DisplayName => Localizer.DoStr("Arch Corner Top Out.");
        public override LocString DisplayDescription => Localizer.DoStr("Arch Corner Piece, Top Layer (Outer)");
        public override Type GroupType => typeof(ArchFormGroup);
        public override int SortOrder => 19;
        public override int MinTier => 1;
    }
}
