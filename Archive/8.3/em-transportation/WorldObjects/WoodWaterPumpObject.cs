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
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Simulation.WorldLayers;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Components;
    using Eco.Shared.Serialization;

    [Serialized]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    public partial class WoodWaterPumpObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Wooden Water Pump"); } }

        public virtual Type RepresentedItemType { get { return typeof(WoodWaterPumpItem); } }


        protected override void Initialize()
        {
            this.GetComponent<PublicStorageComponent>().Initialize(4);
            this.GetComponent<PublicStorageComponent>().Inventory.AddInvRestriction(new SpecificItemTypesRestriction(new System.Type[] { typeof(BucketItem), typeof(BucketOfWaterItem) }));
        }

        public bool WaterTest(Vector3i pos)
        {
            var block = World.GetBlock(pos + Vector3i.Up);
            return (block is WaterBlock && !(block as WaterBlock).PipeSupplied) ? World.GetWaterHeight(pos.XZ) > WorldLayerManager.ClimateSim.State.SeaLevel : false;
        }

        static WoodWaterPumpObject()
        {

            AddOccupancy<WoodWaterPumpObject>(new List<BlockOccupancy>(){
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
    public partial class WoodWaterPumpItem : WorldObjectItem<WoodWaterPumpObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Wooden Water Pump"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Wooden pump used for gathering water."); } }

        static WoodWaterPumpItem()
        {

        }

    }


    [RequiresSkill(typeof(HewingSkill), 5)]
    public partial class WoodWaterPumpRecipe : Recipe
    {
        public WoodWaterPumpRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WoodWaterPumpItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HewnLogItem>(20),
                new CraftingElement<StoneItem>(30),
            };
            this.ExperienceOnCraft = 25;
            this.CraftMinutes = new ConstantValue(25);
            this.Initialize(Localizer.DoStr("Wooden Water Pump"), typeof(WoodWaterPumpRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }

}