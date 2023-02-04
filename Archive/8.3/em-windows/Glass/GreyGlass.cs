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
    public partial class GreyGlassRecipe : Recipe
    {
        public GreyGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GreyGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SandItem>(typeof(GlassworkingSkill), 6, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<GreyDyeItem>(2),
            };
            this.ExperienceOnCraft = 0.5f;
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreyGlassRecipe), Item.Get<GreyGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Grey Glass"), typeof(GreyGlassRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }

    [Serialized]
    [MaxStackSize(20)]
    [ItemTier(2)]
    [Currency]
    [Weight(10000)]
    public partial class GreyGlassItem : BlockItem<GreyGlassBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Grey Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Tinted Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(GreyGlassStacked1Block),
            typeof(GreyGlassStacked2Block),
            typeof(GreyGlassStacked3Block),
            typeof(GreyGlassStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }

    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [Tier(2)]
    [DoesntEncase]
    public class GreyGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyGlassItem); } }

    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Window", typeof(GreyGlassItem))]
    public partial class GreyGlassWall : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Roof", typeof(GreyGlassItem))]
    public partial class GreyGlassRoof : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Floor", typeof(GreyGlassItem))]
    public partial class GreyGlassFloor : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyGlassItem); } }
    }
    [Serialized, Solid] public class GreyGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GreyGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GreyGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class GreyGlassStacked4Block : PickupableBlock { }

}