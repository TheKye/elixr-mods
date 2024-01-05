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
    using Eco.Gameplay.Systems.Messaging.Chat.Commands;

    [ChatCommandHandler]
    public class Informatics : IModKitPlugin
    {
        [ChatCommand("prices", "Get deals across the globe for the mentioned item type.")]
        public static void Prices(User user, string ItemType)
        {
            Tag tag = null;
            Item item = null;
            List<Item> tagItem = null;
            var itemType = char.ToUpper(ItemType[0]) + ItemType[1..];
            try
            {
                tag = TagManager.GetTagOrFail(itemType);
                tagItem = Item.AllItemsExceptHidden.Where(x => x.Tags().Contains(tag)).ToList();
            }
            catch (ArgumentException)
            {
                tag = null;
            }
            if (tag == null)
                item = CommandsUtil.ClosestMatchingEntity(user, itemType, Item.AllItemsExceptHidden, x => x.GetType().Name, x => x.DisplayName);

            if (item == null && tag == null)
            {
                ChatBaseExtended.CBError($"[Informatics] Error: Unable to find item {ItemType} or a Tag with that name", user);
                return;
            }
            var sellOffers = new List<Models.OfferedItem>();
            var buyOffers = new List<Models.OfferedItem>();
            if (tagItem != null)
            {
                sellOffers = ShopInformatics.GetSellingByItemType(user.Player, tagItem);
                buyOffers = ShopInformatics.GetBuyingByItemType(user.Player, tagItem);
            }
            else
            {
                sellOffers = ShopInformatics.GetSellingByItemType(user.Player, item);
                buyOffers = ShopInformatics.GetBuyingByItemType(user.Player, item);
            }
            var message = string.Empty;

            if (sellOffers.Count > 0)
            {
                if (tag != null)
                {
                    message += $"{tag.DisplayName} can be bought from:\n";
                    sellOffers.OrderBy(o => o.Price).ForEach(o =>
                    {
                        if (o.Quantity > 0)
                        {
                            message += $"({o.tagItemName}) {o.Quantity} In Stock, For: <color=green>{o.Price} {o.Currency}</color> \tAt Store: <color=green>{o.StoreName}</color>\tStore Owner: <color=green>{o.StoreOwner}</color>\n";
                        }
                        else
                        {
                            message += $"<color=red>Out of Stock</color> ({o.tagItemName}), was at <color=green>{o.Price} {o.Currency}</color> \tAt Store: <color=green>{o.StoreName}</color>\tStore Owner: <color=green>{o.StoreOwner}</color>\n";
                        }
                    });
                }
                else
                {
                    message += $"{ItemType} can be bought from:\n";
                    sellOffers.OrderBy(o => o.Price).ForEach(o =>
                    {
                        if (o.Quantity > 0)
                        {
                            message += $"{o.Quantity} In Stock, For: <color=green>{o.Price} {o.Currency}</color>, \tAt Store: <color=green>{o.StoreName}</color> \tStore Owner: <color=green>{o.StoreOwner}</color>\n";
                        }
                        else
                        {
                            message += $"<color=red>Out of Stock</color>, was at <color=green>{o.Price} {o.Currency}</color> \tAt Store: <color=green>{o.StoreName}</color>\tStore Owner: <color=green>{o.StoreOwner}</color>\n";
                        }
                    });
                }
                message += "\n\n<color=yellow>----------------</color>\n\n";
            }

            if (buyOffers.Count > 0)
            {
                if (tag != null)
                {
                    message += $"{tag.DisplayName} can be sold at:\n";
                    buyOffers.OrderBy(o => o.Price).ForEach(o =>
                    {
                        message += $"Buying ({o.tagItemName}) {o.Quantity} for {o.Price} {o.Currency} \t At Store: <color=green>{o.StoreName}</color>\t Owner: {o.StoreOwner}\n";
                    });
                }
                else
                {
                    message += $"{ItemType} can be sold at:\n";
                    buyOffers.OrderBy(o => o.Price).ForEach(o =>
                    {
                        message += $"Buying {o.Quantity} for {o.Price} {o.Currency} \t  At Store: <color=green>{o.StoreName}</color>\t Owner: {o.StoreOwner}\n";
                    });
                }
            }

            if (message == string.Empty)
                message = "Unable to find anyone selling this item.";
            if (tag != null)
                ChatBaseExtended.CBInfoPane($"Deals around for {tag.DisplayName}", message, "Informatics", user);
            else
                ChatBaseExtended.CBInfoPane($"Deals around for {item.DisplayName}", message, "Informatics", user);
        }

        public string GetCategory() => "Elixr Mods";

        public string GetStatus() => "Active";

        public override string ToString() => Localizer.DoStr("EM - Informatics");
    }
}