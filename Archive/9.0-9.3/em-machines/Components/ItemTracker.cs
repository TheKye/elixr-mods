using Eco.Shared.Serialization;
using System;

namespace Eco.EM.Industry
{
    [Serialized]
    public class ItemTracker
    {
        [Serialized] private Type itemType;
        [Serialized] private int qty;
        [Serialized] private float time;

        public int Qty { get { return qty; } set { qty = value; } }
        public float Time { get { return time; } set { time = value; } }
        public Type ItemType { get { return itemType; } }

        public ItemTracker() { }
        public ItemTracker(Type key, int value, float t = 0)
        {
            this.itemType = key;
            this.Qty = value;
            this.Time = t;
        }
    }
}
