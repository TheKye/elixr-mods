namespace Eco.EM.Informatics
{
    using Eco.EM.Informatics.Models;
    using Eco.Gameplay.Components;
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

        static List<StoreObject> EnabledShops => NetObjectManager.GetObjectsOfType<StoreObject>().Where(s => s.Operating).ToList();
        public static List<OfferedItem> GetSellingByItemType(Player player, Type ItemType)
        {
            var offers = new List<OfferedItem>();

            EnabledShops.ForEach(s =>
            {
                if(s.GetComponent<CreditComponent>().CreditData.Currency != null)
                    offers.AddRange(ToOfferedItems(GetSellOffersOfType(s, ItemType), s));
            });

            return offers;
        }

        public static List<OfferedItem> GetBuyingByItemType(Player player, Type ItemType)
        {
            var offers = new List<OfferedItem>();

            EnabledShops.ForEach(s =>
            {
                if(s.GetComponent<CreditComponent>().CreditData.Currency != null)
                    offers.AddRange(ToOfferedItems(GetBuyOffersOfType(s, ItemType), s));
            });

            return offers;
        }

        public static List<TradeOffer> GetBuyOffersOfType(StoreObject store, Type itemType)
            => store.GetComponent<StoreComponent>().AllOffers
                .Where(o => o != null && o.Buying && o.Stack.Item.Type == itemType)
                .ToList();

        public static List<TradeOffer> GetSellOffersOfType(StoreObject store, Type itemType)
            => store.GetComponent<StoreComponent>().AllOffers
                .Where(o => o != null && !o.Buying && o.Stack.Item.Type == itemType)
                .ToList();

        public static List<OfferedItem> ToOfferedItems(List<TradeOffer> tradeOffers, StoreObject store)
            => tradeOffers.Select(o => ToOfferedItem(o, store)).ToList();

        public static OfferedItem ToOfferedItem(TradeOffer tradeOffer, StoreObject store)
            => new OfferedItem()
            {
                Quantity = tradeOffer.Stack.Quantity,
                Price = tradeOffer.Price,
                Currency = store.GetComponent<CreditComponent>().CreditData.Currency.Name,
                StoreName = store.Name,
                StoreOwner = store.Owners.Name
            };

        public static List<StoreObject> GetShopsOf(Player player) => GetShopsOf(player.User);
        public static List<StoreObject> GetShopsOf(User user)
            => NetObjectManager.GetObjectsOfType<StoreObject>().Where(s => s.Owners == user).ToList();
    }
}
