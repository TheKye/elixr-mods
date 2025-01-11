using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Components.Storage;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class RemovalBinObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Trash Can");

        public RemovalBinObject() { }

        static RemovalBinObject() { }

        public override void Tick()
        {
            base.Tick();
            TransformToGarbage.TransformToTrash(this);
        }

        protected override void PostInitialize()
        {
            base.PostInitialize();
            var storage = GetComponent<PublicStorageComponent>();
            storage.Initialize(2);
            storage.Inventory.AddInvRestriction(new CustomStackLimitRestriction(500));

        }
    }

    [Serialized]
    [LocDisplayName("Trash Can")]
    [MaxStackSize(100)]
    [Weight(500)]
    [Tag("Trash")]
    [Currency]
    [LocDescription("Turns items into Garbage")]
    public partial class RemovalBinItem : WorldObjectItem<RemovalBinObject>
    {
        
    }


    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class CompostBinObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Compost Bin");

        public CompostBinObject() { }

        static CompostBinObject() { }

        public override void Tick()
        {
        }

        protected override void PostInitialize()
        {
            base.PostInitialize();
            var storage = GetComponent<PublicStorageComponent>();
            storage.Initialize(2);
            storage.Inventory.AddInvRestriction(new CustomStackLimitRestriction(500));

        }
    }

    [Serialized]
    [LocDisplayName("Compost Bin")]
    [MaxStackSize(100)]
    [Weight(500)]
    [Tag("Trash")]
    [LocDescription("Turns Garbage Into Compost")]
    [Currency]
    public partial class CompostBinItem : WorldObjectItem<CompostBinObject>
    {
        
    }

    public class TransformToGarbage
    {
        public static void TransformToTrash(WorldObject obj)
        {
            //Protections - If for some reason it doesn't have the Public Storage Component we exit
            if (!obj.HasComponent<PublicStorageComponent>())
                return;

            //Get the Inventory of the object
            var inven = obj.GetComponent<PublicStorageComponent>();

            //Get the List of items in the inventory
            var itemlist = inven.Inventory.Stacks.ToList();

            if (itemlist == null)
                return;
            //Separate the items out and then do the change over
            foreach (var item in itemlist)
            {
                if (item.Item.GetType() != typeof(GarbageItem))
                    continue;
                else
                {
                    inven.Inventory.TryRemoveItems(item);
                    inven.Inventory.TryAddItemNonUnique(typeof(CompostItem));
                }
            }
            return;

        }

        public static void TransformToCompost(WorldObject obj)
        {
            //Protections - If for some reason it doesn't have the Public Storage Component we exit
            if (!obj.HasComponent<PublicStorageComponent>())
                return;

            //Get the Inventory of the object
            var inven = obj.GetComponent<PublicStorageComponent>();

            //Get the List of items in the inventory
            var itemlist = inven.Inventory.Stacks.ToList();

            if (itemlist == null)
                return;
                //Separate the items out and then do the change over
                foreach (var item in itemlist)
                {
                    if (item.Item.GetType() != typeof(GarbageItem))
                        continue;
                    if (item.Item.GetType() != typeof(FoodItem))
                        continue;

                    else
                    {
                        inven.Inventory.TryRemoveItems(item);
                        inven.Inventory.TryAddItemNonUnique(typeof(CompostItem));
                    }
                }
            return;
        }
    }


    public class CustomStackLimitRestriction : InventoryRestriction
    {
        public override bool SurpassStackSize => true;
        public virtual int MaxItems { get; protected set; }

        public override LocString Message => Localizer.DoStr("Not able to store in this Storage.");
        public virtual bool Enabled => this.MaxItems > 0;

        public CustomStackLimitRestriction(int maxItems) => this.MaxItems = maxItems;

        public override int MaxAccepted(Item item, int currentQuantity)
        {
            if (item is ToolItem)
            {
                return item.MaxStackSize;
            }
            else if (item is TailingsItem || item is WetTailingsItem || item is GarbageItem || item is CompostItem)
            {
                return item.MaxStackSize;
            }
            else
            {
                return this.MaxItems;
            }
        }
    }
}
