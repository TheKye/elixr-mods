using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Mods.Organisms;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.ModkitTools
{
    [Serialized]
    [RequireComponent(typeof(PassiveCraftingComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(StatusComponent))]
    public class NoInputTestObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("No Input Test Object");
        public virtual Type RepresentedItemType => typeof(NoInputTestItem);

        protected override void PostInitialize()
        {
            this.GetComponent<StatusComponent>().Initialize();
            this.GetComponent<PublicStorageComponent>().Initialize(2);
            this.GetComponent<PassiveCraftingComponent>().Initialize(5, new List<(Item, float)>() { (Item.Get(typeof(WoodPulpItem)), 1) }, null);

            base.PostInitialize();
        }
    }

    [Serialized]
    [RequireComponent(typeof(PassiveCraftingComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(StatusComponent))]
    public class InputTestObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Input Test Object");
        public virtual Type RepresentedItemType => typeof(InputTestItem);

        protected override void PostInitialize()
        {
            this.GetComponent<StatusComponent>().Initialize();
            this.GetComponent<LinkComponent>().Initialize(7);
            this.GetComponent<PublicStorageComponent>().Initialize(2);
            this.GetComponent<PassiveCraftingComponent>().Initialize(5, RecipeFamily.Get(typeof(SimmeredMeatRecipe)).DefaultRecipe);

            base.PostInitialize();
        }
    }

    [Serialized]
    [RequireComponent(typeof(PassiveCraftingComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(StatusComponent))]
    public class PlantGenerationTestObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Plant Generation Test Object");
        public virtual Type RepresentedItemType => typeof(PlantGenerationTestItem);

        protected override void PostInitialize()
        {
            this.GetComponent<StatusComponent>().Initialize();
            this.GetComponent<PublicStorageComponent>().Initialize(2);
            var pcc = this.GetComponent<PassiveCraftingComponent>();
            pcc.Initialize(5, new List<(Item, float)>() { (Item.Get(typeof(CornSeedItem)), 1) }, null);
            pcc.AddCraftCondition(new PlantAreaCraftCondition(this, 6, 5, new Type[] { typeof(CornBlock) }));
            base.PostInitialize();
        }
    }

    [Serialized, LocDisplayName("Input Required Test Item")]
    [MaxStackSize(100)]
    public partial class InputTestItem : WorldObjectItem<InputTestObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("input required item for testing passive crafting");
    }

    [Serialized, LocDisplayName("No Input Required Test Item")]
    [MaxStackSize(100)]
    public partial class NoInputTestItem : WorldObjectItem<NoInputTestObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("No input required item for testing passive crafting");
    }

    [Serialized, LocDisplayName("Plant Generation Test Item")]
    [MaxStackSize(100)]
    public partial class PlantGenerationTestItem : WorldObjectItem<PlantGenerationTestObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Plant generation required item for testing passive crafting");
    }
}
