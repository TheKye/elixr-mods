using System.Collections.Generic;

namespace Eco.EM.Daily
{
    public class RewardPack
    {
        // The tier for ordering the giftbox's. By Ascending from 0.
        public int Tier { get; set; }

        // The number of chances in the total amount that this box has of being selected.        
        public int SelectionValue { get; set; }

        // The items in the pack and their qty
        public List<RewardPackItem> Contents { get; set; }

        public RewardPack(int t, int cr, List<RewardPackItem> contents)
        {
            Tier = t;
            SelectionValue = cr;
            Contents = contents;
        }
    }
}
