namespace Eco.EM
{
    using Eco.Gameplay.Players;
    using Eco.Gameplay;
    using Eco.Gameplay.Systems.Chat;
    using Eco.EM;
    using System.Collections.Generic;
    using System;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Eco.Core.Plugins.Interfaces;
    using Eco.Shared.Networking;
    using Eco.Mods.TechTree;
    using Eco.Gameplay.Components;
    using Eco.Core.Utils;
    using System.Linq;

    public class ShopInformatics
    {
        public struct OfferedItem
        {
            public int Quantity;
            public float Price;
            public string Currency;
            public string StoreName;
            public string StoreOwner;
        }

        public static List<OfferedItem> GetSellingByItemType(Player player, Type ItemType)
        {
            var offers = new List<OfferedItem>();

            NetObjectManager
                .GetObjectsOfType<StoreObject>()
                .Where(s => s.Enabled == true)
                .ForEach(s =>
                {
                    var store = s.GetComponent<StoreComponent>();
                    var credit = s.GetComponent<CreditComponent>();
                    var offer = store.StoreData.SellOffers.Where(o => o.SingleItemAsEnumerable() == ItemType && !o.Buying).FirstOrDefault();

                    if (offer != null)
                        offers.Add(new OfferedItem()
                        {
                            Quantity    = offer.Stack.Quantity,
                            Price       = offer.Price,
                            Currency    = credit.CreditData.ToString(),
                            StoreName   = s.UILinkContent(),
                            StoreOwner  = s.Owners.Name
                        });
                });

            return offers;
        }

        public static List<OfferedItem> GetBuyingByItemType(Player player, Type ItemType)
        {
            var offers = new List<OfferedItem>();

            NetObjectManager
                .GetObjectsOfType<StoreObject>()
                .Where(s => s.Enabled == true)
                .ForEach(s =>
                {
                    var store = s.GetComponent<StoreComponent>();
                    var credit = s.GetComponent<CreditComponent>();
                    var offer = store.StoreData.BuyOffers.Where(o => o.SingleItemAsEnumerable() == ItemType && !o.Buying).FirstOrDefault();

            if (offer != null)
                        offers.Add(new OfferedItem()
                        {
                            Quantity = offer.Stack.Quantity,
                            Price = offer.Price,
                            Currency = credit.CreditData.ToString(),
                            StoreName = s.UILinkContent(),
                            StoreOwner = s.Owners.Name
                        });
                });

            return offers;
        }

        public static List<StoreObject> GetShopsOf(Player player) => GetShopsOf(player.User);
        public static List<StoreObject> GetShopsOf(User user)
        {
            return NetObjectManager.GetObjectsOfType<StoreObject>().Where(s => s.Owners == user).ToList();
        }
    }
}
