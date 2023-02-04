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
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class OreWasherObject :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Ore Washer"); } }

        public virtual Type RepresentedItemType { get { return typeof(OreWasherItem); } }

        protected override void Initialize()
        {


        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    public partial class OreWasherItem :
        WorldObjectItem<OreWasherObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Ore Washer"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("It washes ores!"); } }

        static OreWasherItem()
        {

        }
    }

    [Serialized]
    [RequiresSkill(typeof(SmeltingSkill), 0)] //skill used, level required
    public class OreWasherItemRecipe : Recipe //unique name of the recipe
    {
        public OreWasherItemRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<OreWasherItem>(1), //what is crafted, ammount, can craft multible products at a time
            };

            this.Ingredients = new CraftingElement[] //can't be empty or zero, can use multible ingredients at a time
            {
                new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 20f, SmeltingSkill.MultiplicativeStrategy),
                new CraftingElement<CopperIngotItem>(typeof(SmeltingSkill), 20f, SmeltingSkill.MultiplicativeStrategy),
                new CraftingElement<GoldIngotItem>(typeof(SmeltingSkill), 20f, SmeltingSkill.MultiplicativeStrategy),
            };

            this.CraftMinutes = CreateCraftTimeValue(typeof(OreWasherItemRecipe), Item.Get<OreWasherItem>().UILink(), 0.1f, typeof(SmeltingSkill)); //from arrows recipe, 2 sec at max lvl

            this.Initialize(Localizer.DoStr("Ore Washer"), typeof(OreWasherItemRecipe)); //visible name at the crafting station

            CraftingComponent.AddRecipe(typeof(AnvilObject), this); //where is it crafted
        }
    }

}