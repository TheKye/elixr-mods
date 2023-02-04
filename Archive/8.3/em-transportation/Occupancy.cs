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
            WorldObject.AddOccupancy<AheadSignObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(0, 2, 0)),
            });

            WorldObject.AddOccupancy<CustomerParkingSignObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(0, 2, 0)),
            });

            WorldObject.AddOccupancy<LeftSignObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(0, 2, 0)),
            });

           // WorldObject.AddOccupancy<NoEntrySignObject>(new List<BlockOccupancy>(){
           //     new BlockOccupancy(new Vector3i(0, 0, 0)),
           //     new BlockOccupancy(new Vector3i(0, 1, 0)),
           //     new BlockOccupancy(new Vector3i(0, 2, 0)),
           // });
           //
           // WorldObject.AddOccupancy<NoParkingSignObject>(new List<BlockOccupancy>(){
           //     new BlockOccupancy(new Vector3i(0, 0, 0)),
           //     new BlockOccupancy(new Vector3i(0, 1, 0)),
           //     new BlockOccupancy(new Vector3i(0, 2, 0)),
           // });

            WorldObject.AddOccupancy<RightSignObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(0, 2, 0)),
            });

            WorldObject.AddOccupancy<StopSignObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(0, 2, 0)),
            });

            WorldObject.AddOccupancy<TrafficConeObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
            });

            WorldObject.AddOccupancy<RoadBarricadeObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(-1, 0, 0)),
            });
        }
    }
}
