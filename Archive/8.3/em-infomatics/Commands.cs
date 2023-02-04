namespace Eco.EM
{
    using Eco.Gameplay.Players;
    using Eco.Gameplay;
    using Eco.Gameplay.Systems.Chat;
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
    using Eco.Core.Utils.Items;
    using Eco.Gameplay.Items;
    using System.ComponentModel;

    public class Informatics : IModKitPlugin, IChatCommandHandler
    {
        [ChatCommand("prices", "Get deals across the globe for the mentioned item type.")]
        public static void Prices(User user, string ItemType)
        {
            var type = GetTypeFromString(ItemType);
            if (type == null)
            {
                ChatBase.Send(new ChatBase.Message(Text.Error("Error: Unable to find such item")));
                return;
            }

            var sellOffers = ShopInformatics.GetSellingByItemType(user.Player, type);
            var buyOffers  = ShopInformatics.GetBuyingByItemType(user.Player, type);
            var message    = string.Empty;

            if (sellOffers.Count > 0)
            {
                message += $"{type.Name} can be bought from:\n";
                sellOffers.OrderBy(o => o.Price).ForEach(o =>
                {
                    message += $"{o.Quantity} In Stock at {o.Price} {o.Currency} \t {o.StoreName}\t{o.StoreOwner}\n";
                });
            }

            if (buyOffers.Count > 0)
            {
                message += $"{type.Name} can be sold at:\n";
                sellOffers.OrderBy(o => o.Price).ForEach(o =>
                {
                    message += $"{o.Price} {o.Currency} \t {o.StoreName}\t{o.StoreOwner}\n";
                });
            }

            if (message == string.Empty)
                message = "Unable to find anyone selling this item.";

            user.Player.OpenInfoPanel($"Deals around for {type.Name}", message);
        }

        public static Type GetTypeFromString(string ItemType)
        {
            var items = typeof(Item).CreatableTypes().Where(x => x.Name.CompareCaseInsensitive(ItemType) == 0);
            if (!items.Any())
                items = typeof(Item).CreatableTypes().Where(x => x.Name.ContainsCaseInsensitive(ItemType));

            if (items.Count() > 1)
            {
                var lessItems = items.Where(i => i.Name.Remove(i.Name.Length - "Item".Length).CompareCaseInsensitive(ItemType) == 0);
                if (lessItems.Any())
                    items = lessItems;
            }

            if (items.Count() > 1)
                items = items.Where(x => x.Attribute<CategoryAttribute>() == null || x.Attribute<CategoryAttribute>().Category != "Hidden");

            if (items.Count() == 1)
            {
                return items.FirstOrDefault();
            }

            return null;
        }

        public string GetStatus()
        {
            return "Active";
        }
    }
}