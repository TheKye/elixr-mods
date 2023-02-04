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
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    public partial class SteelShippingContainerObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Steel Shipping Container"); } }

        protected override void Initialize()
        {
        }

        static SteelShippingContainerObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = -2; x <= 0; x++)
                for (int z = 0; z <= 2; z++)
                    for (int y = -8; y <= 0; y++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, z, y), typeof(WorldObjectBlock)));

            WorldObject.AddOccupancy<SteelShippingContainerObject>(BlockOccupancyList);
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }


    [Serialized]
    [ItemTier(3)]
    [Weight(30000)]
    [MaxStackSize(10)]
    public partial class SteelShippingContainerItem : WorldObjectItem<SteelShippingContainerObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Steel Shipping Container"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Steel Shipping Container For Storage."); } }

        static SteelShippingContainerItem()
        {

        }

    }

    [RequiresSkill(typeof(IndustrySkill), 4)]
    public partial class SteelShippingContainerRecipe : Recipe
    {
        public SteelShippingContainerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SteelShippingContainerItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelPlateItem>(typeof(IndustrySkill), 15, IndustrySkill.MultiplicativeStrategy, typeof(IndustryLavishResourcesTalent)),
                new CraftingElement<SteelItem>(typeof(AdvancedSmeltingSkill), 10, AdvancedSmeltingSkill.MultiplicativeStrategy, typeof(AdvancedSmeltingLavishResourcesTalent)),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelShippingContainerRecipe), Item.Get<SteelShippingContainerItem>().UILink(), 10, typeof(IndustrySkill), typeof(IndustryFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Steel Shipping Container"), typeof(SteelShippingContainerRecipe));
            CraftingComponent.AddRecipe(typeof(RollingMillObject), this);
        }
    }
}