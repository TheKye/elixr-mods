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
    /*public partial class BlackGlassRecipe : Recipe
    {
        public BlackGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BlackGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SandItem>(typeof(GlassworkingSkill), 6, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<BlackDyeItem>(2),
            };
            this.ExperienceOnCraft = 0.5f;
            this.CraftMinutes = CreateCraftTimeValue(typeof(BlackGlassRecipe), Item.Get<BlackGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Black Glass"), typeof(BlackGlassRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }*/

    [Serialized]
    [MaxStackSize(20)]
    [Currency]
    [Weight(10000)]
    public partial class BlackGlassItem : BlockItem<BlackGlassBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Black Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(BlackGlassStacked1Block),
            typeof(BlackGlassStacked2Block),
            typeof(BlackGlassStacked3Block),
            typeof(BlackGlassStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }

    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [Tier(2)]
    [DoesntEncase]
    public class BlackGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlackGlassItem); } }

    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm(typeof(WallFormType), typeof(BlackGlassItem))]
    public partial class BlackGlassWall : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlackGlassItem); } }
    }

   /* [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Roof", typeof(BlackGlassItem))]
    public partial class BlackGlassRoof : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlackGlassItem); } }
    }

    [Serialized]
    [Solid, Constructed, Wall]
    [Tier(2)]
    [IsForm("Floor", typeof(BlackGlassItem))]
    public partial class BlackGlassFloor : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlackGlassItem); } }
    }*/

    [Serialized, Solid] public class BlackGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BlackGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BlackGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BlackGlassStacked4Block : PickupableBlock { }

}