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
    public partial class RedGlassRecipe : Recipe
    {
        public RedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SandItem>(typeof(GlassworkingSkill), 6, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<RedDyeItem>(2),
            };
            this.ExperienceOnCraft = 0.5f;
            this.CraftMinutes = CreateCraftTimeValue(typeof(RedGlassRecipe), Item.Get<RedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Red Glass"), typeof(RedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }

    [Serialized]
    [MaxStackSize(20)]
    [ItemTier(2)]
    [Currency]
    [Weight(10000)]
    public partial class RedGlassItem : BlockItem<RedGlassBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Red Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Red Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(RedGlassStacked1Block),
            typeof(RedGlassStacked2Block),
            typeof(RedGlassStacked3Block),
            typeof(RedGlassStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }

    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [Tier(2)]
    [DoesntEncase]
    public class RedGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(RedGlassItem); } }

    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Window", typeof(RedGlassItem))]
    public partial class RedGlassWall : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(RedGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Roof", typeof(RedGlassItem))]
    public partial class RedGlassRoof : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(RedGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Floor", typeof(RedGlassItem))]
    public partial class RedGlassFloor : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(RedGlassItem); } }
    }

    [Serialized, Solid] public class RedGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class RedGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class RedGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class RedGlassStacked4Block : PickupableBlock { }

}