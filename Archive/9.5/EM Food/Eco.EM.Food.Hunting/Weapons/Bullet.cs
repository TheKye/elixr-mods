using Eco.Core.Items;
using Eco.Gameplay.Animals;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Simulation.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Food.Hunting.Weapons
{
    [Serialized]
    [LocDisplayName("Bullet")]
    [Weight(10)]
    [Fuel(500)]
    [Tag("Fuel")]
    [Tag("Currency")]
    [Currency]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Burnable Fuel", 1)]
    public partial class BulletItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Use with the bow to hunt for food (or amaze your friends by shooting apples off of their heads)."); } }
    }

    public class BulletEntity : ArrowEntity
    {
        private readonly double destroyTime;
        private const double LifeTime = 120f;
        private const float HeadDistance = 2f;

        public BulletEntity() => this.destroyTime = TimeUtil.Seconds + LifeTime;

        [RPC]
        public override void Destroy()
        {
            // let clients help decide when to destroy
            base.Destroy();
        }

        [RPC]
        public new void Hit(NetObjAttachInfo hitAttachInfo, Vector3 position, string location)
        {
            if (this.Controller is not Player player) return;

            var target = NetObjectManager.Default.GetObject<INetObject>(hitAttachInfo.ParentID);

            // Prevent attaching to targets that are not within accessible distance
            if (target is INetObjectPosition targetPosition && targetPosition.Position.WrappedDistance(position) > HeadDistance)
            {
                this.Destroy();
                return;
            }

            switch (target)
            {
                // bow only damages animals // Auth will be checked inside TryApplyDamage via HarvestOrHunt. Other cases are harmless.
                case AnimalEntity targetAnimal:
                    {
                        targetAnimal.AttachedEntities.Add(this);

                        var hitHead = location.Contains("Head");
                        // player will get x2.5 exp when hit head
                        var experienceMultiplier = hitHead ? 2.5f : 1f;
                        // player will do x2 damage when hit head and x2 again if they have HuntingDeadeyeTalent
                        var locationMultiplier = hitHead ? player.User.Talentset.HasTalent(typeof(HuntingDeadeyeTalent)) ? 4 : 2 : 1;
                        var interactionContext = new InteractionContext() { SelectedStack = new ItemStack(this.BowItem, 1) };
                        if (targetAnimal.Dead || targetAnimal.TryApplyDamageNow(player, this.Damage * locationMultiplier, interactionContext, this.BowItem, typeof(BulletItem), experienceMultiplier))
                            this.Attached = hitAttachInfo;
                        else
                            this.Destroy();
                        break;
                    }
                case Player targetPlayer:
                    // arrows look silly sticking in player capsule colliders
                    targetPlayer.User.ConsumeCalories(150);
                    targetPlayer.MsgLocStr($"{player} Just shot you.. RUN!");
                    this.Destroy();
                    break;
                default:
                    this.Attached = hitAttachInfo;
                    break;
            }

            Animal.AlertNearbyAnimals(this.Position, 15f);

            if (this.Attached != null)
                this.RPC("Attach", this.Attached);

            this.Position = position;
            this.Rotation = Quaternion.LookRotation(this.Velocity.Normalized);
            this.Velocity = Vector3.Zero;
        }
    }
}
