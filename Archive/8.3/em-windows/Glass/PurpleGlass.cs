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
    public partial class PurpleGlassRecipe : Recipe
    {
        public PurpleGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PurpleGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SandItem>(typeof(GlassworkingSkill), 6, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<PurpleDyeItem>(2),
            };
            this.ExperienceOnCraft = 0.5f;
            this.CraftMinutes = CreateCraftTimeValue(typeof(PurpleGlassRecipe), Item.Get<PurpleGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Purple Glass"), typeof(PurpleGlassRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }

    [Serialized]
    [MaxStackSize(20)]
    [ItemTier(2)]
    [Currency]
    [Weight(10000)]
    public partial class PurpleGlassItem : BlockItem<PurpleGlassBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Purple Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Purple Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(PurpleGlassStacked1Block),
            typeof(PurpleGlassStacked2Block),
            typeof(PurpleGlassStacked3Block),
            typeof(PurpleGlassStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }

    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [Tier(2)]
    [DoesntEncase]
    public class PurpleGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleGlassItem); } }

    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Window", typeof(PurpleGlassItem))]
    public partial class PurpleGlassWall : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Roof", typeof(PurpleGlassItem))]
    public partial class PurpleGlassRoof : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Floor", typeof(PurpleGlassItem))]
    public partial class PurpleGlassFloor : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleGlassItem); } }
    }

    [Serialized, Solid] public class PurpleGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class PurpleGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class PurpleGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class PurpleGlassStacked4Block : PickupableBlock { }

}