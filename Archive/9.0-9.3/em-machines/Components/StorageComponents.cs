using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Industry
{
    [Serialized]
    public class ConveyorStorageComponent : StorageComponent
    {
        [Serialized] public Inventory Storage { get; private set; }
        public override Inventory Inventory { get { return this.Storage; } }

        public ConveyorStorageComponent()
        { }

        public ConveyorStorageComponent(int numSlots)
        {
            this.Initialize(numSlots);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(int numSlots)
        {
            if (this.Storage == null)
                this.Storage = new LimitedInventory(numSlots);
        }
    }

    [Serialized]
    public class ItemFilterSlotComponent : StorageComponent
    {
        [Serialized] public Inventory Storage { get; private set; }
        public override Inventory Inventory { get { return this.Storage; } }

        public ItemFilterSlotComponent()
        { }

        public ItemFilterSlotComponent(int numSlots)
        {
            this.Initialize(numSlots);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(int numSlots)
        {
            if (this.Storage == null)
                this.Storage = new LimitedInventory(numSlots);
        }
    }

    public class FilterRestriction : InventoryRestriction
    {
        public override LocString Message { get { return Localizer.DoStr("Inventory only single items for filter"); } }
        public override int MaxAccepted(Item item, int currentQuantity)
        {
            return 1;
        }
    }
}
