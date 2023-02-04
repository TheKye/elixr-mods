using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Mods.TechTree;

namespace Eco.EM.Scifi
{
    // Limits stack sizes to a different quantity other than item.maxstacksize, while restricting Tools and Tailings/Garbage.
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
            else if (item is TailingsItem || item is WetTailingsItem || item is GarbageItem)
            {
                return 0;
            }
            else
            {
                return this.MaxItems;
            }
        }
    }
}