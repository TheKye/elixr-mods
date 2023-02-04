namespace Eco.Mods.TechTree
{

    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Serialization;

    [Serialized]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]
    [RequireRoomMaterialTier(0.8f, typeof(GlassworkingLavishReqTalent), typeof(GlassworkingFrugalReqTalent))]

    public partial class GlassworkingTableObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Glassworking Table"); } }

        public virtual Type RepresentedItemType { get { return typeof(GlassworkingTableItem); } }

        protected override void Initialize()
        {
            this.GetComponent<PropertyAuthComponent>().SetPublic();
        }
        static GlassworkingTableObject()
        {

            AddOccupancy<GlassworkingTableObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock)),
            new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(WorldObjectBlock)),
            new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    public partial class GlassworkingTableItem : ModuleItem<GlassworkingTableObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Glassworking Table"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Table Used To Create Stained Glass."); } }

        static GlassworkingTableItem()
        {

        }

    }


    [RequiresSkill(typeof(LumberSkill), 5)]
    public partial class GlassworkingTableRecipe : Recipe
    {
        public GlassworkingTableRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GlassworkingTableItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(20),
                new CraftingElement<IronIngotItem>(25),
                new CraftingElement<StoneItem>(30),
            };
            this.ExperienceOnCraft = 25;
            this.CraftMinutes = new ConstantValue(25);
            this.Initialize(Localizer.DoStr("Glassworking Table"), typeof(GlassworkingTableRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }

}