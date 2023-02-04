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
    using Eco.EM.Components;
    using Eco.Gameplay.Wires;
    using Eco.Shared.Networking;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class StainedGlassDoubleDoorObject : AutoDoors.AutoDoor
    {

        public override LocString DisplayName { get { return Localizer.DoStr("Stained Glass Double Door"); } }
        public virtual Type RepresentedItemType { get { return typeof(StainedGlassDoubleDoorItem); } }
        protected override void Initialize()
        {
        }
        public override void Destroy()
        {
            base.Destroy();
        }

    }
    [Serialized]
    [ItemTier(2)]
    [Weight(600)]
    public partial class StainedGlassDoubleDoorItem :
        WorldObjectItem<StainedGlassDoubleDoorObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Stained Glass Double Door"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Beautiful Double Stained Glass Door."); } }
        static StainedGlassDoubleDoorItem()
        {
        }
    }
    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public class StainedGlassDoubleDoorRecipe : Recipe
    {
        public StainedGlassDoubleDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
            new CraftingElement<StainedGlassDoubleDoorItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
            new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 12, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingLavishResourcesTalent)),
            new CraftingElement<GlassItem>(typeof(SmeltingSkill), 8, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingLavishResourcesTalent)),
            new CraftingElement<GreenDyeItem>(4)
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(StainedGlassDoubleDoorRecipe), Item.Get<StainedGlassDoubleDoorItem>().UILink(), 10, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Stained Glass Double Door"), typeof(StainedGlassDoubleDoorRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}