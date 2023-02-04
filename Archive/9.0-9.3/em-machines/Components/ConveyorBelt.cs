using Eco.Core.IoC;
using Eco.Core.Utils;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;

namespace Eco.EM.Industry
{
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(ConveyorStorageComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public abstract class ConveyorBeltObject : WorldObject
    {
        [Serialized] private bool hasItems = false;
        protected bool HasItems { get { return hasItems; } set { hasItems = value; } }

        [Serialized] public ThreadSafeList<ItemTracker> ItemTraveller = new ThreadSafeList<ItemTracker>(); // this keeps track of the items and how long they have been in the conveyor belt

        protected virtual float PassSpeed => 16f;
        protected virtual string DefaultPassDirection => "Forward";

        protected override void Initialize()
        {
            this.GetComponent<ConveyorStorageComponent>().Initialize(4);
            this.GetComponent<PropertyAuthComponent>();
            this.GetComponent<ConveyorStorageComponent>().Inventory.OnChangedDetailed.Add(HandleInputInventory);
        }

        public override void Tick()
        {
            SetAnimatedState("Operating", Operating);
            SetAnimatedState("HasItems", HasItems);
            if (Operating) { PassInventory(); }
            base.Tick();
        }

        /// <summary>
        /// this handles items going into the inventory space of the conveyor belt.
        /// </summary>
        /// <param name="user">likely null for the conveyor belt</param> 
        /// <param name="changes">tracks the changes to an inventory. SLG implemented code</param>
        /// <param name="invDic">tracks the changes to a stack. SLG implemented code</param>
        public virtual void HandleInputInventory(User user, IEnumerable<KeyValuePair<Type, int>> changes, Dictionary<ItemStack, ChangedStack> invDic)
        {
            changes.ForEach(item => // for each change to this inventory
            {
                if (item.Value < 0) // if the item has a negative change.
                {
                    foreach (ItemTracker i in ItemTraveller.AsList()) //change any current tracker that tracks this item to updates it's amount
                    {
                        if (i.ItemType == item.Key)
                        {
                            ItemTracker newTracker = new ItemTracker(item.Key, i.Qty + item.Value, i.Time);
                            ItemTraveller.Remove(i);
                            if (newTracker.Qty > 0)
                                ItemTraveller.Add(newTracker);
                            break;
                        }
                    }
                }
                else
                {
                    ItemTraveller.Add(new ItemTracker(item.Key, item.Value)); // add a new tracker
                }
            });
            HasItems = !this.GetComponent<ConveyorStorageComponent>().Inventory.IsEmpty; //determine if there is any inventory in the conveyor
        }

        /// <summary>
        /// this handles passing items from a tracker that have passed the travel time simulation of the conveyor
        /// </summary>
        public virtual void PassInventory()
        {
            if (GetInventory() != null)
            {
                ItemTraveller.ForEach(item => // check each item in the traveller
                {
                    item.Time += ServiceHolder<IWorldObjectManager>.Obj.TickDeltaTime; // add the time that has elapsed in the world since this was last run
                    if (item.Time > PassSpeed) // pass the inventory if greater than 4 seconds.
                    {
                        GetComponent<ConveyorStorageComponent>().Inventory.MoveAsManyItemsAsPossible(item.ItemType, item.Qty, GetInventory()); // check the forward inventory to see if we can pass items
                    }
                });
            }
            HasItems = !this.GetComponent<ConveyorStorageComponent>().Inventory.IsEmpty; //determine if there is any inventory in the conveyor
        }

        /// <summary>
        /// this handles retrieving the inventory from a conveyor in front of me.
        /// </summary>
        /// <returns>an inventory or null</returns>
        public Inventory GetInventory()
        {
            Vector3i passVector;
            WorldObject obj = null;

            if (DefaultPassDirection == "Up")
            {
                passVector = this.Position3i + Rotation.Up.XYZi;
                obj = WorldObjectsAtPos(passVector);
            }

            if (DefaultPassDirection == "Down")
            {
                passVector = this.Position3i - Rotation.Up.XYZi;
                obj = WorldObjectsAtPos(passVector);
            }

            // Check for world seam in forward check
            if (obj == null)
            {
                passVector = this.Position3i + Rotation.Forward.XYZi;
                if (passVector.X == WorldArea.WholeWorld.Size.X)
                    passVector.X = 0;
                if (passVector.X == -1)
                    passVector.X = WorldArea.WholeWorld.Size.X - 1;
                if (passVector.Z == WorldArea.WholeWorld.Size.Y)
                    passVector.Z = 0;
                if (passVector.Z == -1)
                    passVector.Z = WorldArea.WholeWorld.Size.Y - 1;
                obj = WorldObjectsAtPos(passVector);
            }

            if (obj != null && obj.HasComponent<ConveyorStorageComponent>())
                return obj.GetComponent<ConveyorStorageComponent>().Inventory;

            return null;
        }

        /// <summary>
        /// returns an object at a given position
        /// </summary>
        /// <param name="pos">a world position in 3 dimensions</param>
        /// <returns></returns>
        public WorldObject WorldObjectsAtPos(Vector3i pos)
        {
            WorldObject objAtPos = null;
            WorldObjectManager.ForEach(worldObject =>
            {
                foreach (Vector3i vector in worldObject.WorldOccupancy)
                {
                    if (vector == pos)
                    {
                        objAtPos = worldObject;
                        break;
                    }
                }
            });
            return objAtPos;
        }
    }
}
