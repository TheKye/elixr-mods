namespace Eco.CTK.Items
{
    using Eco.Core.Utils;
    using Eco.CTK;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using static Eco.Shared.Utils.Text;

    [Serialized]
    [Weight(1)]
    [Priority(PriorityAttribute.High)]
    public class TokenItem : Item
    {
		public override LocString DisplayName { get { return Localizer.DoStr("Token"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A token that can be exchanged into " + Base.Config.TokenValue + " skill points."); } }

        [Tooltip(500, typeof(Controls))]
        public string ControlsTooltip => Style(Styles.Controls, Localizer.Do($"[Right-click to consume]"));

        public bool Consume(Player player)
        {
            player.User.UseXP(Base.Config.TokenValue * -1);
            return true;
        }

        public override void OnUsed(Player player, ItemStack itemStack) => itemStack.TryModifyStack(player.User, -1, () => Consume(player));
	}
}