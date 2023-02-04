namespace Eco.EM.Informatics
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
    using Eco.EM.Framework.ChatBase;
    using Eco.Shared.Localization;
    using Eco.Gameplay.Utils;

    public class Informatics : IModKitPlugin, IChatCommandHandler
    {
        [ChatCommand("prices", "Get deals across the globe for the mentioned item type.")]
        public static void Prices(User user, string ItemType)
        {
                var type = CommandsUtil.ClosestMatchingEntity(user.Player, ItemType, Item.AllItems, x => x.GetType().Name, x => x.DisplayName).GetType();
            //var type = GetTypeFromString(ItemType.Replace(" ", "").Trim() + "item", user);

            if (type == null)
            {
                ChatBaseExtended.CBError($"[Informatics] Error: Unable to find item {ItemType}");
                return;
            }

            var sellOffers = ShopInformatics.GetSellingByItemType(user.Player, type);
            var buyOffers = ShopInformatics.GetBuyingByItemType(user.Player, type);
            var message = string.Empty;

            if (sellOffers.Count > 0)
            {
                message += $"{ItemType} can be bought from:\n";
                sellOffers.OrderBy(o => o.Price).ForEach(o =>
                {
                    if (o.Quantity > 0)
                    {
                        message += $"{o.Quantity} In Stock at {o.Price} {o.Currency} \tStore Name: <color=green>{o.StoreName}</color>\tStore Owner: {o.StoreOwner}\n";
                    }
                    else
                    {
                        message += $"<color=red>Out of Stock</color>, was at {o.Price} {o.Currency}\tStore Name: <color=green>{o.StoreName}</color>\tStore Owner: {o.StoreOwner}\n";
                    }
                });
            }

            if (buyOffers.Count > 0)
            {
                message += $"{ItemType} can be sold at:\n";
                buyOffers.OrderBy(o => o.Price).ForEach(o =>
                {
                    message += $"Buying {o.Quantity} for {o.Price} {o.Currency} \t <color=green>{o.StoreName}</color>\t{o.StoreOwner}\n";
                });
            }

            if (message == string.Empty)
                message = "Unable to find anyone selling this item.";

            ChatBaseExtended.CBInfoPane($"Deals around for {type.GetLocDisplayName()}", message, "Informatics", user);
        }

        public static Type GetTypeFromString(string ItemType, User user)
        {
            return CommandsUtil.ClosestMatchingEntity(user.Player, ItemType, Item.AllItems, x => x.GetType().Name, x => x.DisplayName).GetType();
        }

        public string GetStatus()
        {
            return "Active";
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM - Informatics");
        }
    }
}