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
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(20)]
    [RequireRoomMaterialTier(0.8f, typeof(TailoringLavishReqTalent), typeof(TailoringFrugalReqTalent))]
    public partial class DyeTableObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Dye Table"); } }

        public virtual Type RepresentedItemType { get { return typeof(DyeTableItem); } }

        protected override void Initialize()
        {
            this.GetComponent<PropertyAuthComponent>().SetPublic();
        }
        static DyeTableObject()
        {

            AddOccupancy<DyeTableObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock)),
            new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock)),
            new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(WorldObjectBlock)),
            });
        }



        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]

    public partial class DyeTableItem : WorldObjectItem<DyeTableObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Dye Table"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Table Used To Create Dyes."); } }

        static DyeTableItem()
        {

        }

    }


    [RequiresSkill(typeof(LumberSkill), 2)]
    public partial class DyeTableRecipe : Recipe
    {
        public DyeTableRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DyeTableItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StoneItem>(20),
                new CraftingElement<MortarItem>(10),
                new CraftingElement<LumberItem>(25),
                new CraftingElement<BucketItem>(10)
            };
            this.ExperienceOnCraft = 25;
            this.CraftMinutes = new ConstantValue(25);
            this.Initialize(Localizer.DoStr("Dye Table"), typeof(DyeTableRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }

}