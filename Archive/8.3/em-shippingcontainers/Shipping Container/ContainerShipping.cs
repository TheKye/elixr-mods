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
    using Eco.Gameplay.Audio;
    using Eco.Shared.Networking;
    using Eco.EM.Components;

    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    public partial class ShippingContainerObject : AutoDoor.Autodoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Shipping Container"); } }



        protected override void Initialize()
        {

        }

        static ShippingContainerObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = -1; x <= 0; x++)
                for (int z = 0; z <= 1; z++)
                    for (int y = -5; y <= 0; y++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, z, y), typeof(WorldObjectBlock)));

            WorldObject.AddOccupancy<ShippingContainerObject>(BlockOccupancyList);
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        public override InteractResult OnActRight(InteractionContext context)
        {
            if (context.Parameters != null && context.Parameters.ContainsKey("DoorsOpen"))
            {
                return InteractResult.Success;
            }
            return InteractResult.NoOp;
        }


    }

    public partial class ContainerDoorsObject : WorldObject
    {

    }


    [Serialized]
    [Tier(2)]
    [LocDisplayName("Shipping Container")]
    [Weight(20000)]
    [MaxStackSize(10)]
    public partial class ShippingContainerItem : WorldObjectItem<ShippingContainerObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Shipping Container For Storage."); } }

        static ShippingContainerItem()
        {

        }

    }

   /* [RequiresSkill(typeof(MechanicsSkill), 3)]
    public partial class ShippingContainerRecipe : Recipe
    {
        public ShippingContainerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ShippingContainerItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronPlateItem>(typeof(MechanicsSkill), 15, MechanicsSkill.MultiplicativeStrategy, typeof(MechanicsLavishResourcesTalent)),
                new CraftingElement<ScrewsItem>(typeof(MechanicsSkill), 10, MechanicsSkill.MultiplicativeStrategy, typeof(MechanicsLavishResourcesTalent)),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ShippingContainerRecipe), Item.Get<ShippingContainerItem>().UILink(), 10, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Shipping Container"), typeof(ShippingContainerRecipe));
            CraftingComponent.AddRecipe(typeof(MachinistTableObject), this);
        }
    }*/
}