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
    public partial class BlueGlassRecipe : Recipe
    {
        public BlueGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BlueGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SandItem>(typeof(GlassworkingSkill), 6, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<BlueDyeItem>(2),
            };
            this.ExperienceOnCraft = 0.5f;
            this.CraftMinutes = CreateCraftTimeValue(typeof(BlueGlassRecipe), Item.Get<BlueGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Blue Glass"), typeof(BlueGlassRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }

    [Serialized]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Currency]
    [ItemTier(2)]
    public partial class BlueGlassItem : BlockItem<BlueGlassBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Blue Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Blue Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(BlueGlassStacked1Block),
            typeof(BlueGlassStacked2Block),
            typeof(BlueGlassStacked3Block),
            typeof(BlueGlassStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }

    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [Tier(2)]
    [DoesntEncase]
    public class BlueGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueGlassItem); } }

    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Window", typeof(BlueGlassItem))]
    public partial class BlueGlassWall : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Roof", typeof(BlueGlassItem))]
    public partial class BlueGlassRoof : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Floor", typeof(BlueGlassItem))]
    public partial class BlueGlassFloor : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueGlassItem); } }
    }

    [Serialized, Solid] public class BlueGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BlueGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BlueGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BlueGlassStacked4Block : PickupableBlock { }

}