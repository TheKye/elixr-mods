namespace Eco.Mods.TechTree
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.World;

    #region Purple
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    public partial class PurpleDyeItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Purple Dye"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Purple Dye Used for Dying Certain Items."); } }

        static PurpleDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class PurpleDyeRecipe : Recipe
    {
        public PurpleDyeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PurpleDyeItem>(),
                new CraftingElement<BucketItem>()
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ClothItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<FireweedShootsItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PlantFibersItem>(typeof(TailoringSkill), 25, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PaperItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<BucketOfWaterItem>(1)
            };
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(PurpleDyeRecipe), Item.Get<PurpleDyeItem>().UILink(), 2, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Dye - Purple"), typeof(PurpleDyeRecipe));
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }
    }
    #endregion

    #region Green
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    public partial class GreenDyeItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Green Dye"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Green Dye Used for Dying Certain Items."); } }

        static GreenDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class GreenDyeRecipe : Recipe
    {
        public GreenDyeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GreenDyeItem>(),
                new CraftingElement<BucketItem>()
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ClothItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<AgaveLeavesItem>(typeof(TailoringSkill), 25, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PlantFibersItem>(typeof(TailoringSkill), 25, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PaperItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<BucketOfWaterItem>(1)
            };
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreenDyeRecipe), Item.Get<GreenDyeItem>().UILink(), 2, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Dye - Green"), typeof(GreenDyeRecipe));
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }
    }
    #endregion

    #region Yellow
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    public partial class YellowDyeItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Yellow Dye"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Yellow Dye Used for Dying Certain Items."); } }

        static YellowDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class YellowDyeRecipe : Recipe
    {
        public YellowDyeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<YellowDyeItem>(),
                new CraftingElement<BucketItem>()
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ClothItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PineappleItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PlantFibersItem>(typeof(TailoringSkill), 25, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PaperItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<BucketOfWaterItem>(1)
            };
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(YellowDyeRecipe), Item.Get<YellowDyeItem>().UILink(), 2, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Dye - Yellow"), typeof(YellowDyeRecipe));
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }
    }
    #endregion

    #region Blue
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    public partial class BlueDyeItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Blue Dye"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Blue Dye Used for Dying Certain Items."); } }

        static BlueDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class BlueDyeRecipe : Recipe
    {
        public BlueDyeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BlueDyeItem>(),
                new CraftingElement<BucketItem>()
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ClothItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<HuckleberriesItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PlantFibersItem>(typeof(TailoringSkill), 25, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PaperItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<BucketOfWaterItem>(1)
            };
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(BlueDyeRecipe), Item.Get<BlueDyeItem>().UILink(), 2, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Dye - Blue"), typeof(BlueDyeRecipe));
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }
    }
    #endregion

    #region Red
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    public partial class RedDyeItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Red Dye"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Red Dye Used for Dying Certain Items."); } }

        static RedDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class RedDyeRecipe : Recipe
    {
        public RedDyeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RedDyeItem>(),
                new CraftingElement<BucketItem>()
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ClothItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<TomatoItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PlantFibersItem>(typeof(TailoringSkill), 25, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PaperItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<BucketOfWaterItem>(1)
            };
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(RedDyeRecipe), Item.Get<RedDyeItem>().UILink(), 2, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Dye - Red"), typeof(RedDyeRecipe));
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }
    }
    #endregion

    #region Brown
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    public partial class BrownDyeItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Brown Dye"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Brown Dye Used for Dying Certain Items."); } }

        static BrownDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class BrownDyeRecipe : Recipe
    {
        public BrownDyeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BrownDyeItem>(),
                new CraftingElement<BucketItem>()
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ClothItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<DirtItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PlantFibersItem>(typeof(TailoringSkill), 25, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PaperItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<BucketOfWaterItem>(1)
            };
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(BrownDyeRecipe), Item.Get<BrownDyeItem>().UILink(), 2, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Dye - Brown"), typeof(BrownDyeRecipe));
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }
    }
    #endregion

    #region Orange
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    public partial class OrangeDyeItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Orange Dye"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Orange Dye Used for Dying Certain Items."); } }

        static OrangeDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class OrangeDyeRecipe : Recipe
    {
        public OrangeDyeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<OrangeDyeItem>(),
                new CraftingElement<BucketItem>()
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ClothItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PapayaItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PlantFibersItem>(typeof(TailoringSkill), 25, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PaperItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<BucketOfWaterItem>(1)
            };
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(OrangeDyeRecipe), Item.Get<OrangeDyeItem>().UILink(), 2, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Dye - Orange"), typeof(OrangeDyeRecipe));
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }
    }
    #endregion

    #region Grey
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    public partial class GreyDyeItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Grey Dye"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Grey Dye Used for Dying Certain Items."); } }

        static GreyDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class GreyDyeRecipe : Recipe
    {
        public GreyDyeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GreyDyeItem>(),
                new CraftingElement<BucketItem>()
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ClothItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PlantFibersItem>(typeof(TailoringSkill), 25, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PaperItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<BucketOfWaterItem>(1)
            };
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreyDyeRecipe), Item.Get<GreyDyeItem>().UILink(), 2, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Dye - Grey"), typeof(GreyDyeRecipe));
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }
    }
    #endregion

    #region Black
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    public partial class BlackDyeItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Black Dye"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Black Dye Used for Dying Certain Items."); } }

        static BlackDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class BlackDyeRecipe : Recipe
    {
        public BlackDyeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BlackDyeItem>(),
                new CraftingElement<BucketItem>()
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ClothItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<CoalItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PlantFibersItem>(typeof(TailoringSkill), 25, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<PaperItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<BucketOfWaterItem>(1)
            };
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(BlackDyeRecipe), Item.Get<BlackDyeItem>().UILink(), 2, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Dye - Black"), typeof(BlackDyeRecipe));
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }
    }
    #endregion
}
