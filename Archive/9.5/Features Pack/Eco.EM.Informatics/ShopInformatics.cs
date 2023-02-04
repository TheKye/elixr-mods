﻿namespace Eco.EM.Informatics
{
    using Eco.EM.Informatics.Models;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Networking;
    using Eco.Shared.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShopInformatics
    {
        static List<StoreObject> EnabledShops => NetObjectManager.Default.GetObjectsOfType<StoreObject>().Where(s => s.Operating).ToList();

        public static List<OfferedItem> GetSellingByItemType(Player player, Item ItemType)
        {
            var offers = new List<OfferedItem>();

            EnabledShops.ForEach(s =>
            {
                if (s.GetComponent<CreditComponent>().CreditData.Currency != null)
                    offers.AddRange(ToOfferedItems(GetSellOffersOfType(s, ItemType), s));
            });

            return offers;
        }

        public static List<OfferedItem> GetBuyingByItemType(Player player, Item ItemType)
        {
            var offers = new List<OfferedItem>();

            EnabledShops.ForEach(s =>
            {
                if (s.GetComponent<CreditComponent>().CreditData.Currency != null)
                    offers.AddRange(ToOfferedItems(GetBuyOffersOfType(s, ItemType), s));
            });

            return offers;
        }

        public static List<OfferedItem> GetSellingByItemType(Player player, List<Item> ItemType)
        {
            var offers = new List<OfferedItem>();

            EnabledShops.ForEach(s =>
            {
                foreach (var i in ItemType)
                {
                    if (s.GetComponent<CreditComponent>().CreditData.Currency != null)
                        offers.AddRange(ToOfferedItems(GetSellOffersOfType(s, i), s));

                }
            });

            return offers;
        }

        public static List<OfferedItem> GetBuyingByItemType(Player player, List<Item> ItemType)
        {
            var offers = new List<OfferedItem>();

            EnabledShops.ForEach(s =>
            {
                foreach (var i in ItemType)
                {
                    if (s.GetComponent<CreditComponent>().CreditData.Currency != null)
                        offers.AddRange(ToOfferedItems(GetBuyOffersOfType(s, i), s));
                }
            });

            return offers;
        }
        public static List<TradeOffer> GetBuyOffersOfType(StoreObject store, Item item)
            => store.GetComponent<StoreComponent>().AllOffers
                .Where(o => o != null && o.Buying && o.Stack.Item == item)
                .ToList();

        public static List<TradeOffer> GetSellOffersOfType(StoreObject store, Item item)
            => store.GetComponent<StoreComponent>().AllOffers
                .Where(o => o != null && !o.Buying && o.Stack.Item == item)
                .ToList();

        public static List<OfferedItem> ToOfferedItems(List<TradeOffer> tradeOffers, StoreObject store)
            => tradeOffers.Select(o => ToOfferedItem(o, store)).ToList();

        public static OfferedItem ToOfferedItem(TradeOffer tradeOffer, StoreObject store)
            => new()
            {
                Quantity = tradeOffer.Stack.Quantity,
                Price = tradeOffer.Price,
                tagItemName = tradeOffer.Stack.Item.DisplayName,
                Currency = store.GetComponent<CreditComponent>().CreditData.Currency.Name,
                StoreName = System.Text.RegularExpressions.Regex.Replace(store.Name, "<color[^>]*>", ""),
                StoreOwner = store.Owners.Name
            };

        public static List<StoreObject> GetShopsOf(Player player) => GetShopsOf(player.User);
        public static List<StoreObject> GetShopsOf(User user)
            => NetObjectManager.Default.GetObjectsOfType<StoreObject>().Where(s => s.Owners == user).ToList();
    }
}
