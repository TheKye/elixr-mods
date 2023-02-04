namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;

    public partial class ShelvesFormType : FormType
    {
        public override string Name => "Shelves";
        public override LocString DisplayName => Localizer.DoStr("Shelves - Walls");
        public override LocString DisplayDescription => Localizer.DoStr("Simple Shelves for storing objects on.");
        public override Type GroupType => typeof(ShelvesFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }
    public partial class ShelvesBlockFormType : FormType
    {
        public override string Name => "Shelves";
        public override LocString DisplayName => Localizer.DoStr("Shelves - Block");
        public override LocString DisplayDescription => Localizer.DoStr("Simple Shelves for storing objects on.");
        public override Type GroupType => typeof(ShelvesFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }


    public partial class CatwalkCornerFormType : FormType
    {
        public override string Name => "CatwalkCorner";
        public override LocString DisplayName => Localizer.DoStr("Catwalk - Corner");
        public override LocString DisplayDescription => Localizer.DoStr("Simple Catwalks, can be used in all kinds of ways.");
        public override Type GroupType => typeof(CatwalkFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }

    public partial class CatwalkMiddleFormType : FormType
    {
        public override string Name => "CatwalkMiddle";
        public override LocString DisplayName => Localizer.DoStr("Catwalk - Middle");
        public override LocString DisplayDescription => Localizer.DoStr("Simple Catwalks, can be used in all kinds of ways.");
        public override Type GroupType => typeof(CatwalkFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }

    public partial class CatwalkSideFormType : FormType
    {
        public override string Name => "CatwalkSide";
        public override LocString DisplayName => Localizer.DoStr("Catwalk - Side");
        public override LocString DisplayDescription => Localizer.DoStr("Simple Catwalks, can be used in all kinds of ways.");
        public override Type GroupType => typeof(CatwalkFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }

    public partial class CatwalkSingleFormType : FormType
    {
        public override string Name => "CatwalkSingle";
        public override LocString DisplayName => Localizer.DoStr("Catwalk - Single");
        public override LocString DisplayDescription => Localizer.DoStr("Simple Catwalks, can be used in all kinds of ways.");
        public override Type GroupType => typeof(CatwalkFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }

    public partial class CatwalkInnerCornerFormType : FormType
    {
        public override string Name => "CatwalkInnerCorner";
        public override LocString DisplayName => Localizer.DoStr("Catwalk - Inner Corner");
        public override LocString DisplayDescription => Localizer.DoStr("Simple Catwalks, can be used in all kinds of ways.");
        public override Type GroupType => typeof(CatwalkFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }

    public partial class CatwalkExtenFormType : FormType
    {
        public override string Name => "CatwalkExten";
        public override LocString DisplayName => Localizer.DoStr("Catwalk - Extension");
        public override LocString DisplayDescription => Localizer.DoStr("Simple Catwalks, can be used in all kinds of ways.");
        public override Type GroupType => typeof(CatwalkFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }
}
