namespace Eco.CTK.Items
{
    using Eco.Core.Utils;
    using Eco.CTK;
    using Eco.Gameplay.Interactions;
    using Eco.Mods.TechTree;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using static Eco.Shared.Utils.Text;

    public class GiftItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("A Gift Box"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Open to reveal a surprise!"); } }

        [Tooltip(500, typeof(Controls))]
        public string ControlsTooltip => Style(Styles.Controls, Localizer.Do($"[Right-click to open]"));

        public virtual bool Open(Player player) => false;

        public override void OnUsed(Player player, ItemStack itemStack) => itemStack.TryModifyStack(player.User, -1, () => Open(player));
    }

    [Serialized]
    [Weight(1)]
    [Priority(PriorityAttribute.High)]
    public class CTKGift000Item : GiftItem
    {
        public override bool Open(Player player)
        {
            var rand = Shared.Utils.RandomUtil.Range(1, 100);
            int Amount = (rand < 90) ? (rand < 60) ? 1 : 2 : 3;

            if (!player.User.Inventory.TryAddItems<TokenItem> (Amount , player.User))
            {
                ChatBase.Send ( new ChatBase.Message ( "Error: Unable to give you the reward(s), perhaps your inventory is full?" ) );
                return false;
            }

            return true;
        }
	}

    [Serialized]
    [Weight(1)]
    [Priority(PriorityAttribute.High)]
    public class CTKGift001Item : GiftItem
    {
        public override bool Open(Player player)
        {
            var rand = Shared.Utils.RandomUtil.Range(1, 100);
            int Amount = (rand < 70) ? 3 : 5;
            bool GiveMeat = (rand % 2 == 0 && rand / 2 % 2 == 0);

            var Inventory = InventoryChangeSet.New(player.User.Inventory, player.User);
            Inventory.AddItems(typeof(TokenItem), Amount);
            if (GiveMeat)
                Inventory.AddItems(typeof(SimmeredMeatItem), 2);

            if (!Inventory.TryApply().Success)
            {
                ChatBase.Send ( new ChatBase.Message ( "Error: Unable to give you the reward(s), perhaps your inventory is full?" ) );
                return false;
            }

            return true;
        }
	}

    [Serialized]
    [Weight(1)]
    [Priority(PriorityAttribute.High)]
    public class CTKGift002Item : GiftItem
    {
        public override bool Open(Player player)
        {
            var rand = Shared.Utils.RandomUtil.Range(1, 100);
            int Amount = (rand < 70) ? 10 : (rand % 2 == 0) ? 15 : 20;

            if (!player.User.Inventory.TryAddItems<LogItem> (Amount, player.User))
            {
                ChatBase.Send ( new ChatBase.Message ( "Error: Unable to give you the reward(s), perhaps your inventory is full?" ) );
                return false;
            }

            return true;
        }
	}
    
    [Serialized]
    [Weight(1)]
    [Priority(PriorityAttribute.High)]
    public class CTKGift003Item : GiftItem
    {
        public override bool Open(Player player)
        {
            var rand = Shared.Utils.RandomUtil.Range(1, 1000);
            int Amount = (rand % 2 == 0) ? 2 : 1;
            bool GiveSpecial = (rand == 28);

            var Inventory = InventoryChangeSet.New(player.User.Inventory, player.User);
            Inventory.AddItems(typeof(TokenItem), Amount);
            if (GiveSpecial)
                Inventory.AddItems(typeof(StrangeFuelItem), 1);

            if (!Inventory.TryApply().Success)
            {
                ChatBase.Send ( new ChatBase.Message ( "Error: Unable to give you the reward(s), perhaps your inventory is full?" ) );
                return false;
            }

            return true;
        }
	}

    [Serialized]
    [Weight(1)]
    [Priority(PriorityAttribute.High)]
    public class CTKGift004Item : GiftItem
    {
        public override bool Open(Player player)
        {
            var rand = Shared.Utils.RandomUtil.Range(1, 1000);
            bool GiveSpecial = (rand == 28);

            var Inventory = InventoryChangeSet.New(player.User.Inventory, player.User);
            Inventory.AddItems(typeof(TokenItem), 1);
            if (GiveSpecial)
                Inventory.AddItems(typeof(EcoylentItem), 1);

            if (!Inventory.TryApply().Success)
            {
                ChatBase.Send ( new ChatBase.Message ( "Error: Unable to give you the reward(s), perhaps your inventory is full?" ) );
                return false;
            }

            return true;
        }
	}

    [Serialized]
    [Weight(1)]
    [Priority(PriorityAttribute.High)]
    public class CTKGift005Item : GiftItem
    {
        public override bool Open(Player player)
        {
            if (!player.User.Inventory.TryAddItems<GoldOreItem> (10, player.User))
            {
                ChatBase.Send ( new ChatBase.Message ( "Error: Unable to give you the reward(s), perhaps your inventory is full?" ) );
                return false;
            }

            return true;
        }
	}

    [Serialized]
    [Weight(10)]
    [Priority(PriorityAttribute.High)]
    public class CTKGift006Item : GiftItem
    {
        public override bool Open(Player player)
        {
            if (!player.User.Inventory.TryAddItems<TokenItem> (10, player.User))
            {
                ChatBase.Send ( new ChatBase.Message ( "Error: Unable to give you the reward(s), perhaps your inventory is full?" ) );
                return false;
            }

            return true;
        }
	}
}