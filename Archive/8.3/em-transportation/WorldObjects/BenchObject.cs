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

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class BenchObject :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Bench"); } }

        public virtual Type RepresentedItemType { get { return typeof(BenchItem); } }
        protected override void Initialize()
        {


        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [Weight(6000)]
    public partial class BenchItem :
        WorldObjectItem<BenchObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Bench"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Beautiful Parck Bench."); } }

        static BenchItem()
        {

        }
    }

    [RequiresSkill(typeof(LumberSkill), 3)]
    public class BenchRecipe : Recipe
    {
        public BenchRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<BenchItem>()
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(LumberSkill), 20, LumberSkill.MultiplicativeStrategy, typeof(LumberLavishResourcesTalent)),
                new CraftingElement<IronIngotItem>(typeof(LumberSkill), 4, LumberSkill.MultiplicativeStrategy, typeof(LumberLavishResourcesTalent)),
                new CraftingElement<RivetItem>(typeof(LumberSkill), 20, LumberSkill.MultiplicativeStrategy, typeof(LumberLavishResourcesTalent)),
                new CraftingElement<BrownDyeItem>(3)
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(BenchRecipe), Item.Get<BenchItem>().UILink(), 5, typeof(LumberSkill), typeof(LumberFocusedSpeedTalent), typeof(LumberParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Park Bench"), typeof(BenchRecipe));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }


}