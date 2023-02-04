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
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;

    [Serialized]
    [RequireComponent(typeof(StoreComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]

    public partial class FarmersStandObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Farmers Stand"); } }

        public virtual Type RepresentedItemType { get { return typeof(FarmersStandItem); } }

        protected override void PostInitialize()
        {
            this.GetComponent<PropertyAuthComponent>().SetPublic();
        }

        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Economy");

            if (WorldObject.GetOccupancy(typeof(FarmersStandObject)) == null)
                WorldObject.AddOccupancy<FarmersStandObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(-2, 0, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 0, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 0, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 1, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 1, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 1, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 2, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 2, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 2, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 0, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 0, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 0, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 1, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 1, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 1, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 2, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 2, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 2, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 0, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 0, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 0, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 1, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 1, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 1, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 2, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 2, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 2, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),


                });


        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    public partial class FarmersStandItem : WorldObjectItem<FarmersStandObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Farmers Stand"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Allows the selling and trading of items outdoors."); } }

        static FarmersStandItem()
        {
        }
    }

    [RequiresSkill(typeof(FarmingSkill), 1)]
    public partial class FarmersStandRecipe : Recipe
    {
        public FarmersStandRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FarmersStandItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(20),
                new CraftingElement<PlantFibersItem>(100),
            };
            this.CraftMinutes = new ConstantValue(25);
            this.Initialize(Localizer.DoStr("Farmers Stand"), typeof(FarmersStandRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

}
