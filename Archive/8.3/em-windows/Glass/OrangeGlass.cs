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
    public partial class OrangeGlassRecipe : Recipe
    {
        public OrangeGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<OrangeGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SandItem>(typeof(GlassworkingSkill), 6, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<OrangeDyeItem>(2),
            };
            this.ExperienceOnCraft = 0.5f;
            this.CraftMinutes = CreateCraftTimeValue(typeof(OrangeGlassRecipe), Item.Get<OrangeGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Orange Glass"), typeof(OrangeGlassRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }

    [Serialized]
    [MaxStackSize(20)]
    [ItemTier(2)]
    [Currency]
    [Weight(10000)]
    public partial class OrangeGlassItem : BlockItem<OrangeGlassBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Orange Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Orange Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(OrangeGlassStacked1Block),
            typeof(OrangeGlassStacked2Block),
            typeof(OrangeGlassStacked3Block),
            typeof(OrangeGlassStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }

    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [Tier(2)]
    [DoesntEncase]
    public class OrangeGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeGlassItem); } }

    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Window", typeof(OrangeGlassItem))]
    public partial class OrangeGlassWall : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Roof", typeof(OrangeGlassItem))]
    public partial class OrangeGlassRoof : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Floor", typeof(OrangeGlassItem))]
    public partial class OrangeGlassFloor : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeGlassItem); } }
    }

    [Serialized, Solid] public class OrangeGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class OrangeGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class OrangeGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class OrangeGlassStacked4Block : PickupableBlock { }

}