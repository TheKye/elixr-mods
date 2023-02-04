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
    #region Frame 1x1
    [Serialized]
    [Weight(10)]
    [Currency]
    [MaxStackSize(500)]
    public partial class FrameItem :
        Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Frame"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Frames"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Small Frame For Stained Glass."); } }
    }

    [RequiresSkill(typeof(HewingSkill), 2)]
    public partial class FrameRecipe : Recipe
    {
        public FrameRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FrameItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(HewingSkill), 5, HewingSkill.MultiplicativeStrategy, typeof(HewingLavishResourcesTalent))
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(FrameRecipe), Item.Get<FrameItem>().UILink(), 2, typeof(HewingSkill), typeof(HewingFocusedSpeedTalent), typeof(HewingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Frame"), typeof(FrameRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
    #endregion
    #region Frame Long 1x2
    [Serialized]
    [Weight(10)]
    [Currency]
    [MaxStackSize(500)]
    public partial class LongFrameItem :
    Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Frame"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Long Frames"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Wide Frame For Stained Glass"); } }
    }

    [RequiresSkill(typeof(HewingSkill), 2)]
    public partial class LongFrameRecipe : Recipe
    {
        public LongFrameRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LongFrameItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(HewingSkill), 8, HewingSkill.MultiplicativeStrategy, typeof(HewingLavishResourcesTalent))
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LongFrameRecipe), Item.Get<LongFrameItem>().UILink(), 2, typeof(HewingSkill), typeof(HewingFocusedSpeedTalent), typeof(HewingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Frame - Long"), typeof(LongFrameRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
    #endregion
    #region Frame Large 2x2
    [Serialized]
    [Weight(10)]
    [Currency]
    [MaxStackSize(500)]
    public partial class LargeFrameItem :
    Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Frame"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Large Frames"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Large Frame For Stained Glass."); } }
    }

    [RequiresSkill(typeof(HewingSkill), 2)]
    public partial class LargeFrameRecipe : Recipe
    {
        public LargeFrameRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LargeFrameItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(HewingSkill), 12, HewingSkill.MultiplicativeStrategy, typeof(HewingLavishResourcesTalent))
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargeFrameRecipe), Item.Get<LargeFrameItem>().UILink(), 2, typeof(HewingSkill), typeof(HewingFocusedSpeedTalent), typeof(HewingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Frame - Large"), typeof(LargeFrameRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
    #endregion
    #region Frame Tall 2x1
    [Serialized]
    [Weight(10)]
    [Currency]
    [MaxStackSize(500)]
    public partial class TallFrameItem :
    Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Frame"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Tall Frames"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Tall Frame For Stained Glass."); } }
    }

    [RequiresSkill(typeof(HewingSkill), 2)]
    public partial class TallFrameRecipe : Recipe
    {
        public TallFrameRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TallFrameItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(HewingSkill), 8, HewingSkill.MultiplicativeStrategy, typeof(HewingLavishResourcesTalent))
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(TallFrameRecipe), Item.Get<TallFrameItem>().UILink(), 2, typeof(HewingSkill), typeof(HewingFocusedSpeedTalent), typeof(HewingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Frame - Tall"), typeof(TallFrameRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
    #endregion
}
