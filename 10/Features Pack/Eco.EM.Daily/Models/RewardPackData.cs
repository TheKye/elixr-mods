using Eco.Gameplay.Players;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Eco.EM.Daily
{
    public class RewardPackData
    {
        public Dictionary<string, RewardPack> Packs { get; private set; }

        public RewardPackData()
        {
            Packs = new Dictionary<string, RewardPack>();
        }

        public RewardPack GetRewardPack(User user)
        { 
            // Get gift and attempt to add to inventory
            var startTier = DailyManager.Data.GetHighestStartTier(user);
            RewardPack[] possibles = GetUsersGiftOptions(startTier);
            RewardPack chosen = GetGift(possibles);

            return chosen;
        }

        private RewardPack[] GetUsersGiftOptions(int startTier)
        {
            return Packs.Values.Where(x => x.Tier >= startTier).OrderBy(x => x.Tier).ThenByDescending(x => x.SelectionValue).ToArray();
        }

        /// <summary>
        /// Returns a random gift item if it is passed a list of possible gift items.
        /// </summary>
        /// <param name="possibleGifts"></param>
        /// <returns></returns>
        public RewardPack GetGift(RewardPack[] possibleGifts)
        {
            var rollTotal = GetRandomValueFromGiftsValue(possibleGifts);

            // get an enumerator of all gift items which have been ordered
            var enumerable = possibleGifts.GetEnumerator();
            int progress = 0;

            // pick a random number between 0 and the total of all the ranges
            int rand = RandomUtil.Next(rollTotal);

            if (!enumerable.MoveNext())
                return GetBestGiftOrDefault();

            // consume our first chance range
            progress += ((RewardPack)enumerable.Current).SelectionValue;

            // if our progress is less than our roll, move to the next GiftItem and consume it's chance range
            while (progress < rand)
            {
                if (!enumerable.MoveNext())
                    return (RewardPack)enumerable.Current;

                progress += ((RewardPack)enumerable.Current).SelectionValue;
            }

            // return the Gift Item we are at.
            return (RewardPack)enumerable.Current;
        }

        /// <summary>
        /// returns the highest tier gift item or null
        /// </summary>
        /// <returns></returns>
        private RewardPack GetBestGiftOrDefault()
        {
            return Packs.Values.OrderBy(x => x.Tier).ToArray().Last() ?? null;
        }

        /// <summary>
        /// Returns the total possible random range value from the list of possible gifts.
        /// </summary>
        /// <param name="possibleGifts"></param>
        /// <returns></returns>
        private int GetRandomValueFromGiftsValue(RewardPack[] possibleGifts)
        {
            int value = 0;

            possibleGifts.ForEach(x =>
            {
                value += x.SelectionValue;
            });

            return value;
        }
    }
}
