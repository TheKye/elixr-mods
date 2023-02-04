using Eco.Gameplay.Objects;
using Eco.Mods.TechTree;
using Eco.Shared.Math;
using System.Collections.Generic;
using Eco.Gameplay.Items;

namespace Eco.Mods
{
    public class RecycleInitItem : Item
    {
        static RecycleInitItem()
        {
            WorldObject.AddOccupancy<CompostBinObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }
}
