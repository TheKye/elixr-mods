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
using Eco.Shared.IoC;
using System.Text;
using System.Linq;
using Eco.Shared.Math;
using Eco.Gameplay.Auth;
using Eco.EM.Framework.Resolvers;
using Eco.Shared.Items;

namespace Eco.EM.Storage.Warehousing
{
    [Serialized, Weight(1000), MaxStackSize(10), LocDisplayName("Storage Terminal")]
    public partial class StorageTerminalItem : WorldObjectItem<StorageTerminalObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Display of all items in storage.");
    }

    [RequiresSkill(typeof(MechanicsSkill), 3)]
    public partial class StorageTerminalRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(StorageTerminalRecipe).Name,
            Assembly = typeof(StorageTerminalRecipe).AssemblyQualifiedName,
            HiddenName = "Storage Terminal",
            LocalizableName = Localizer.DoStr("Storage Terminal"),
            RequiredSkillType = typeof(MechanicsSkill),
            RequiredSkillLevel = 3,
            SpeedImprovementTalents = new Type[] { typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent) },
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 100),
            },
            ProductList = new()
            {
                new EMCraftable("StorageTerminalItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 25,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "MachinistTableItem",
        };
        static StorageTerminalRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public StorageTerminalRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ModsPreInitialize();
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(StorageTerminalComponent))]
    public partial class StorageTerminalObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Storage Terminal");

        public Type RepresentedItemType => typeof(StorageTerminalItem);
        public override TableTextureMode TableTexture => TableTextureMode.Metal;
        static StorageTerminalObject() { AddOccupancyList(typeof(StorageTerminalObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock))); }


    }

    [Eco] public enum OrderBy { SellingAlphabetical, SellingInStockQty, StoragesAlphabetical, StoragesQuantity }

    [Serialized, AutogenClass, LocDisplayName("Storage Terminal")]
    public partial class StorageTerminalComponent : WorldObjectComponent
    {
        private float radius;

        [SyncToView, Autogen, AutoRPC, Serialized]
        public float Radius
        {
            get => radius;
            set
            {
                if (value == radius) return;
                radius = value;
                this.Changed(nameof(Radius));
            }
        }

        private OrderBy orderBy;

        [Eco]
        public OrderBy OrderBy
        {
            get => orderBy;
            set
            {
                if (value == orderBy) return;
                orderBy = value;
                this.Changed(nameof(OrderBy));
            }
        }


        private List<PublicStorageComponent> inventories;
        private List<StoreComponent> stores;

        private Dictionary<Item, int> storeStock;
        private Dictionary<Item, int> nonStoreStock;
        private Dictionary<LocString, Dictionary<Item, int>> storages;

        public StorageTerminalComponent() { }

        public StorageTerminalComponent(int radius, OrderBy orderBy)
        {
            this.Radius = radius;
            this.OrderBy = orderBy;
        }

        [RPC, Autogen]
        public virtual void ShowStockLevels(Player player)
        {
            // Ensure there is an owner for this Terminal
            if (this.Parent.Owners == null) { player.ErrorLocStr("Object does not have an owner, cannot be used."); return; }

            QueryWorldObjects(player);

            // Ensure there are stores and invetories to display
            if (stores.Count <= 0 && inventories.Count <= 0)
            {
                player.ErrorLocStr($"You have {stores.Count} stores and {inventories.Count} inventories, which means no stock level data can be displayed.");
                return;
            }

            if (OrderBy == OrderBy.SellingAlphabetical || OrderBy == OrderBy.SellingInStockQty)
            {
                // Build listings from all stores in range and ensure there are listings for sale
                BuildStoresListings();
                // Build all the stock levels
                BuildStockLevels();
                // Display the stock level output to the player
                DisplayStock(player);
            }
            else
            {
                // Build data from all storages in range
                BuildStorageContents();
                // Display the contents to the player
                DisplayStorageContents(player);
            }
        }

        protected virtual void DisplayStock(Player player)
        {
            IOrderedEnumerable<KeyValuePair<Item, int>> orderedStoreStock;
            IOrderedEnumerable<KeyValuePair<Item, int>> orderedNonStoreStock;

            if (OrderBy == OrderBy.SellingInStockQty)
            {
                orderedStoreStock = storeStock.OrderBy(x => x.Value);
                orderedNonStoreStock = nonStoreStock.OrderBy(x => x.Value);
            }
            else
            {
                orderedStoreStock = storeStock.OrderBy(x => x.Key.DisplayName);
                orderedNonStoreStock = nonStoreStock.OrderBy(x => x.Key.DisplayName);
            }

            StringBuilder sb = new();
            if (orderedStoreStock.Any())
            {
                // Create the store stock string part
                sb.AppendLine(WhiteText("STORE STOCK:"));

                foreach (var item in orderedStoreStock)
                {
                    if (item.Value == 0) { sb.AppendLine(RedText($"{item.Key.UILink()} : {item.Value}")); continue; }
                    if (item.Value < 10) { sb.AppendLine(OrangeText($"{item.Key.UILink()} : {item.Value}")); continue; }
                    sb.AppendLine(GreenText($"{item.Key.UILink()} : {item.Value}"));
                }

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
                foreach (var sellOffer in store.StoreData.SellOffers)
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

        protected virtual void BuildStorageContents()
        {
            storages = new Dictionary<LocString, Dictionary<Item, int>>();

            foreach (var inv in inventories)
            {
                var storageContents = new Dictionary<Item, int>();
                var storageName = inv.Parent.UILink();

                foreach (var stack in inv.Inventory.Stacks)
                {
                    // protection for null stacks
                    if (stack.Item == null) { continue; }
                    if (!storageContents.ContainsKey(stack.Item)) { storageContents.Add(stack.Item, 0); }
                    storageContents[stack.Item] += stack.Quantity;
                }
                storages.Add(storageName, storageContents);
            }
        }

        protected virtual void DisplayStorageContents(Player player)
        {
            var sortedStorages = storages.OrderBy(x => x.Key);

            StringBuilder sb = new();
            sb.AppendLine(WhiteText("STORAGES:"));
            foreach (var storage in sortedStorages)
            {
                sb.AppendLine(storage.Key);
                IOrderedEnumerable<KeyValuePair<Item, int>> sortedInv = OrderBy == OrderBy.StoragesAlphabetical ? storage.Value.OrderBy(x => x.Key.DisplayName) : storage.Value.OrderBy(x => x.Value);

                foreach (var item in sortedInv) sb.AppendLine(WhiteText($"    - {item.Key.UILink()} : {item.Value}"));
                sb.AppendLine(WhiteText(" "));
            }
            player.OpenInfoPanel("Storage Terminal Display", sb.ToString(), "StorageTerminal");
        }

        protected virtual void QueryWorldObjects(Player player)
        {
            inventories = new List<PublicStorageComponent>();
            stores = new List<StoreComponent>();

            foreach (var worldObject in ServiceHolder<IWorldObjectManager>.Obj.GetObjectsWithin(this.Parent.Position, this.Radius))
            {
                // Any object that contains an inventory where our player is an owner add to the list of inventories.
                var storageComponent = worldObject.GetComponent<PublicStorageComponent>();
                var isAuthorized = ServiceHolder<IAuthManager>.Obj.IsAuthorized(worldObject, player.User);
                if (storageComponent != null && isAuthorized)
                {
                    inventories.Add(storageComponent);
                }

                // Any store where our player is an owner add to the list of stores.
                var storeComponent = worldObject.GetComponent<StoreComponent>();
                if (storeComponent != null && isAuthorized)
                {
                    stores.Add(storeComponent);
                }
            }
        }

        static string WhiteText(string s) => $"<color=#ffffff>{s}</color>";
        static string RedText(string s) => $"<color=#ff0000>{s}</color>";
        static string OrangeText(string s) => $"<color=#ffa31a>{s}</color>";
        static string GreenText(string s) => $"<color=#66ff33>{s}</color>";
    }
}