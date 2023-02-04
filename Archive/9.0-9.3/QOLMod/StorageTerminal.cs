using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Core.Controller;
using Eco.Shared.Networking;
using Eco.Gameplay.Players;
using Eco.Core.IoC;
using Eco.Gameplay.Aliases;
using System.Text;
using System.Linq;
using Eco.Shared.Math;

namespace Eco.Mods.TechTree
{
    [Serialized, Weight(1000), MaxStackSize(10), LocDisplayName("Storage Terminal")]
    public partial class StorageTerminalItem : WorldObjectItem<StorageTerminalObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Display of all items in storage."); } }
    }

    [RequiresSkill(typeof(MechanicsSkill), 3)]
    public partial class StorageTerminalRecipe : RecipeFamily
    {
        private string rName = "Storage Terminal";
        private Type skillBase = typeof(MechanicsSkill);
        private Type ingTalent = typeof(MechanicsLavishResourcesTalent);
        private Type[] speedTalents = { typeof(MechanicsParallelSpeedTalent), typeof(MechanicsFocusedSpeedTalent) };

        public StorageTerminalRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    rName,
                    Localizer.DoStr(rName),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(CopperBarItem), 5, skillBase, ingTalent),
                        new IngredientElement(typeof(IronBarItem), 5, skillBase, ingTalent),
                    },
                    new CraftingElement<StorageTerminalItem>()
                    )
                };
            this.ExperienceOnCraft = 5;
            this.LaborInCalories = CreateLaborInCaloriesValue(25f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 5f, skillBase, speedTalents);
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            CraftingComponent.AddRecipe(typeof(MachinistTableObject), this);
        }
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(StorageTerminalComponent))]
    public partial class StorageTerminalObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Storage Terminal");

        public Type RepresentedItemType => typeof(StorageTerminalItem);

        static StorageTerminalObject() { AddOccupancyList(typeof(StorageTerminalObject), new BlockOccupancy(Vector3i.Zero, typeof(SolidWorldObjectBlock))); }

        public override void Destroy() { base.Destroy(); }
    }

    [Eco] public enum OrderBy { Alphabetical, StockLevel }

    [Serialized, AutogenClass, LocDisplayName("Storage Terminal")]
    public partial class StorageTerminalComponent : WorldObjectComponent
    {
        [SyncToView, Autogen, AutoRPC,Serialized] public float Radius { get; set; } = 10;
        [Eco] public OrderBy OrderBy { get; set; } = OrderBy.Alphabetical;

        private List<StorageComponent> inventories;
        private List<StoreComponent> stores;

        private Dictionary<Item, int> storeStock;
        private Dictionary<Item, int> nonStoreStock;

        public StorageTerminalComponent() { }

        public StorageTerminalComponent(int radius, OrderBy orderBy)
        {
            this.Radius = radius;
            this.OrderBy = orderBy;
        }

        [RPC, Autogen] public virtual void ShowStockLevels(Player player)
        {
            // Ensure there is an owner for this Terminal
            if (this.Parent.Owners == null) { player.ErrorLocStr("Object does not have an owner, cannot be used."); return; }

            QueryWorldObjects(player);

            // Ensure there are stores and invetories to display
            if (stores.Count <= 0 || inventories.Count <= 0) 
            { 
                player.ErrorLocStr($"You have {stores.Count} stores and {inventories.Count} inventories, which means no stock level data can be displayed."); 
                return; 
            }

            // Build listings from all stores in range and ensure there are listings for sale
            BuildStoresListings();

            // Build all the stock levels
            BuildStockLevels();

            // Display the stock level output to the player
            DisplayStock(player);
        }

        protected virtual void DisplayStock(Player player)
        {
            var orderedStoreStock = storeStock.OrderBy(x => x.Key.DisplayName);           
            var orderedNonStoreStock = nonStoreStock.OrderBy(x => x.Key.DisplayName);

            if (OrderBy == OrderBy.StockLevel)
            {
                orderedStoreStock = storeStock.OrderBy(x => x.Value);
                orderedNonStoreStock = nonStoreStock.OrderBy(x => x.Value);
            }

            StringBuilder sb = new StringBuilder();
            // Create the store stock string part
            sb.AppendLine(WhiteText("STORE STOCK:"));

            foreach (var item in orderedStoreStock)
            {
                if (item.Value == 0) { sb.AppendLine(RedText($"{item.Key.UILink()} : {item.Value}")); continue; }
                if (item.Value < 10) { sb.AppendLine(OrangeText($"{item.Key.UILink()} : {item.Value}")); continue; }
                sb.AppendLine(GreenText($"{item.Key.UILink()} : {item.Value}")); 
            }

            // Create the non-store stock string part
            sb.AppendLine("");
            sb.AppendLine(WhiteText("NON-STORE STOCK:"));

            foreach (var item in orderedNonStoreStock)
            {
                if (item.Value == 0) { sb.AppendLine(RedText($"{item.Key.UILink()} : {item.Value}")); continue; }
                if (item.Value < 10) { sb.AppendLine(OrangeText($"{item.Key.UILink()} : {item.Value}")); continue; }
                sb.AppendLine(GreenText($"{item.Key.UILink()} : {item.Value}"));
            }

            player.OpenInfoPanel("Storage Terminal Display", sb.ToString(), "StorageTerminal");
        }

        protected virtual void BuildStoresListings()
        {
            storeStock = new Dictionary<Item, int>();

            foreach (var store in stores)
            {
                foreach( var sellOffer in store.StoreData.SellOffers.Collection)
                {
                    if (!storeStock.ContainsKey(sellOffer.Stack.Item))
                        storeStock.Add(sellOffer.Stack.Item, 0);
                }
            }
        }

        protected virtual void BuildStockLevels()
        {
            nonStoreStock = new Dictionary<Item, int>();

            // Go through all the stacks in all the inventories and build our quantities of items that our stores offer
            foreach (var inv in inventories)
            {
                foreach (var stack in inv.Inventory.Stacks)
                {
                    // protection for null stacks
                    if (stack.Item == null) { continue; }

                    // if store stock
                    if (storeStock.ContainsKey(stack.Item)) { storeStock[stack.Item] += stack.Quantity; continue; }
                    
                    // if not store stock
                    if (!nonStoreStock.ContainsKey(stack.Item)) { nonStoreStock.Add(stack.Item, 0); }

                    nonStoreStock[stack.Item] += stack.Quantity;
                }
            }
        }

        protected virtual void QueryWorldObjects(Player player)
        {
            inventories = new List<StorageComponent>();
            stores = new List<StoreComponent>();

            foreach (var worldObject in ServiceHolder<IWorldObjectManager>.Obj.GetObjectsWithin(this.Parent.Position, this.Radius))
            {
                // Any object that contains an inventory where our player is an owner add to the list of inventories.
                var storageComponent = worldObject.GetComponent<StorageComponent>();
                if (storageComponent != null && storageComponent.Parent.Owners != null && (storageComponent.Parent.Auth.UsersWithFullAccess.ContainsUser(player.User) || storageComponent.Parent.Owners.UserSet.ContainsUser(player.User) || storageComponent.Parent.Auth.UsersWithConsumerAccess.Contains(player.User)))
                {
                        inventories.Add(storageComponent);
                }

                // Any store where our player is an owner add to the list of stores.
                var storeComponent = worldObject.GetComponent<StoreComponent>();
                if (storeComponent != null && storeComponent.Parent.Owners != null && (storeComponent.Parent.Auth.UsersWithFullAccess.ContainsUser(player.User) || storeComponent.Parent.Owners.UserSet.ContainsUser(player.User) || storeComponent.Parent.Auth.UsersWithConsumerAccess.Contains(player.User)))
                {
                    stores.Add(storeComponent);
                }
            }
        }

        string WhiteText(string s) { return $"<color=#ffffff>{s}</color>"; }
        string RedText(string s) { return $"<color=#ff0000>{s}</color>"; }
        string OrangeText(string s) { return $"<color=#ffa31a>{s}</color>"; }
        string GreenText(string s) { return $"<color=#66ff33>{s}</color>"; }
    }  
}