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

    [RequiresSkill(typeof(GlassworkingSkill), 0)]
    public partial class BrownGlassRecipe : Recipe
    {
        public BrownGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BrownGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SandItem>(typeof(GlassworkingSkill), 6, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<BrownDyeItem>(2),
            };
            this.ExperienceOnCraft = 0.5f;
            this.CraftMinutes = CreateCraftTimeValue(typeof(BrownGlassRecipe), Item.Get<BrownGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Brown Glass"), typeof(BrownGlassRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }

    [Serialized]
    [MaxStackSize(20)]
    [ItemTier(2)]
    [Currency]
    [Weight(10000)]
    public partial class BrownGlassItem : BlockItem<BrownGlassBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Brown Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Brown Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(BrownGlassStacked1Block),
            typeof(BrownGlassStacked2Block),
            typeof(BrownGlassStacked3Block),
            typeof(BrownGlassStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }

    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [Tier(2)]
    [DoesntEncase]
    public class BrownGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownGlassItem); } }

    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Window", typeof(BrownGlassItem))]
    public partial class BrownGlassWall : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Roof", typeof(BrownGlassItem))]
    public partial class BrownGlassRoof : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Floor", typeof(BrownGlassItem))]
    public partial class BrownGlassFloor : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownGlassItem); } }
    }

    [Serialized, Solid] public class BrownGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BrownGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BrownGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BrownGlassStacked4Block : PickupableBlock { }

}