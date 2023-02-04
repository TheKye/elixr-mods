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
    public partial class GreenGlassRecipe : Recipe
    {
        public GreenGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GreenGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SandItem>(typeof(GlassworkingSkill), 6, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<GreenDyeItem>(2),
            };
            this.ExperienceOnCraft = 0.5f;
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreenGlassRecipe), Item.Get<GreenGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Green Glass"), typeof(GreenGlassRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }

    [Serialized]
    [MaxStackSize(20)]
    [ItemTier(2)]
    [Currency]
    [Weight(10000)]
    public partial class GreenGlassItem : BlockItem<GreenGlassBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Green Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Green Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(GreenGlassStacked1Block),
            typeof(GreenGlassStacked2Block),
            typeof(GreenGlassStacked3Block),
            typeof(GreenGlassStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }

    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [Tier(2)]
    [DoesntEncase]
    public class GreenGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenGlassItem); } }

    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Window", typeof(GreenGlassItem))]
    public partial class GreenGlassWall : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Roof", typeof(GreenGlassItem))]
    public partial class GreenGlassRoof : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Floor", typeof(GreenGlassItem))]
    public partial class GreenGlassFloor : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenGlassItem); } }
    }

    [Serialized, Solid] public class GreenGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GreenGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GreenGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class GreenGlassStacked4Block : PickupableBlock { }

}