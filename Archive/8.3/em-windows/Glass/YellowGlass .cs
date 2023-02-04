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
    public partial class YellowGlassRecipe : Recipe
    {
        public YellowGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<YellowGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SandItem>(typeof(GlassworkingSkill), 6, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<YellowDyeItem>(2),
            };
            this.ExperienceOnCraft = 0.5f;
            this.CraftMinutes = CreateCraftTimeValue(typeof(YellowGlassRecipe), Item.Get<YellowGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Yellow Glass"), typeof(YellowGlassRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }

    [Serialized]
    [MaxStackSize(20)]
    [ItemTier(2)]
    [Currency]
    [Weight(10000)]
    public partial class YellowGlassItem : BlockItem<YellowGlassBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Yellow Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Yellow Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(YellowGlassStacked1Block),
            typeof(YellowGlassStacked2Block),
            typeof(YellowGlassStacked3Block),
            typeof(YellowGlassStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }

    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [Tier(2)]
    [DoesntEncase]
    public class YellowGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowGlassItem); } }

    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Window", typeof(YellowGlassItem))]
    public partial class YellowGlassWall : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Roof", typeof(YellowGlassItem))]
    public partial class YellowGlassRoof : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Floor", typeof(YellowGlassItem))]
    public partial class YellowGlassFloor : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowGlassItem); } }
    }

    [Serialized, Solid] public class YellowGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class YellowGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class YellowGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class YellowGlassStacked4Block : PickupableBlock { }

}