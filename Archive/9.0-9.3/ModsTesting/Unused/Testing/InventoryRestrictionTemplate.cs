using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Mods.TechTree;
using Eco.Gameplay.Components;

namespace Eco.EM.Testing
{
    // Tutorial Class for creating a custom Inventory Restriction
    public class TemplateInventoryRestriction : InventoryRestriction
    {
        // Can this restriction override the max stack size defined on the item {true/ false}
        public override bool SurpassStackSize => true;
        // Message to be returned when the object can't be held by the storage
        public override LocString Message => Localizer.DoStr("Not able to store in this Storage.");

        // Constructor. Define here what will be passed on creation of this restriction.
        public TemplateInventoryRestriction() { }

        // Returns the maximum stacksize of the item trying to be placed into the inventory that is allowed to be placed in there.
        public override int MaxAccepted(Item item, int currentQuantity)
        {
                return item.MaxStackSize;
        }
    }


    // Example class that takes doubles a normal stockpile restriction for all blocks but restricts placement of tailings or wet tailings
    public class MyCustomRestriction : InventoryRestriction
    {
        // This restriction can override the items defined max stacksize
        public override bool SurpassStackSize => true;

        // Player feedback
        public override LocString Message => Localizer.DoStr("Not able to store in this Storage.");

        // a stockpile restriction we can use for our check.
        private StockpileStackRestriction spRestriction;

        // Constructor. Pass the height of the stockpile and the desired multiplier and assign a new stockpile restriction to our private field
        public MyCustomRestriction(int StockpileHeight, int heightMultiplier) 
        {
            spRestriction = new StockpileStackRestriction(StockpileHeight * heightMultiplier);
        }

        // Returns 0 if item is tailings/wet tailings or follow the stockpile rules with our adjusted height.
        public override int MaxAccepted(Item item, int currentQuantity)
        {
           return (item is TailingsItem || item is WetTailingsItem) ? 0 : spRestriction.MaxAccepted(item, currentQuantity);
        }
    }
}