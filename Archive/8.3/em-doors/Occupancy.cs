namespace Eco.EM.Occupancy
{
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Mods.TechTree;
    using Eco.Shared.Math;
    using System.Collections.Generic;

    class DoorsOccupancy : Item
    {
        static DoorsOccupancy()
        {
            WorldObject.AddOccupancy<SlidingDoorObject>(new List<BlockOccupancy>()
            {
               new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 1, -0), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 1, -1), typeof(BuildingWorldObjectBlock)),
            });

            var BlockOccupancyList = new List<BlockOccupancy>( );

            //for (int z = 0; z <= 5; z++)
            //    for (int y = -5; y <= 0; y++)
            //        BlockOccupancyList.Add( new BlockOccupancy( new Vector3i( 0, z, y ), typeof(DoubleGreatHallDoorObjectBlock) ) );
            //
            //WorldObject.AddOccupancy<DoubleGreatHallDoorObject>( BlockOccupancyList );
            //BlockOccupancyList.Clear();

            BlockOccupancyList.Clear();

            for (int x = 0; x <= 0; x++)
                for (int z = 0; z <= 5; z++)
                    for (int y = -2; y <= 0; y++)
                        BlockOccupancyList.Add( new BlockOccupancy( new Vector3i( x, z, y ), typeof(BuildingWorldObjectBlock) ) );

            WorldObject.AddOccupancy<GreatHallDoorObject>( BlockOccupancyList );
            
          WorldObject.AddOccupancy<LargeCorrugatedSteelDoorObject>(new List<BlockOccupancy>(){
           new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 3, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 2, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 0, 4), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 1, 4), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 3, 4), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 2, 4), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 3, 3), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 3, 2), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 3, 1), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 0, 3), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 0, 2), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 0, 1), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 2, 3), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 2, 2), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 2, 1), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 1, 3), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 1, 2), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           new BlockOccupancy(new Vector3i(0, 1, 1), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
           });
            // LargeLumberDoorObject
            WorldObject.AddOccupancy<LargeLumberDoorObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 3, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 2, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 0, 4), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 4), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 3, 4), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 2, 4), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 3, 3), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 3, 2), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 3, 1), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 0, 3), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 0, 2), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 0, 1), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 3), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 2), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 1), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 2, 3), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 2, 2), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 2, 1), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(1, 0, 0)),
            new BlockOccupancy(new Vector3i(1, 0, 1)),
            new BlockOccupancy(new Vector3i(1, 0, 2)),
            new BlockOccupancy(new Vector3i(1, 0, 3)),
            new BlockOccupancy(new Vector3i(1, 0, 4)),
            new BlockOccupancy(new Vector3i(1, 1, 0)),
            new BlockOccupancy(new Vector3i(1, 1, 1)),
            new BlockOccupancy(new Vector3i(1, 1, 2)),
            new BlockOccupancy(new Vector3i(1, 1, 3)),
            new BlockOccupancy(new Vector3i(1, 1, 4)),
            new BlockOccupancy(new Vector3i(1, 2, 0)),
            new BlockOccupancy(new Vector3i(1, 2, 1)),
            new BlockOccupancy(new Vector3i(1, 2, 2)),
            new BlockOccupancy(new Vector3i(1, 2, 3)),
            new BlockOccupancy(new Vector3i(1, 2, 4)),
            new BlockOccupancy(new Vector3i(1, 3, 0)),
            new BlockOccupancy(new Vector3i(1, 3, 1)),
            new BlockOccupancy(new Vector3i(1, 3, 2)),
            new BlockOccupancy(new Vector3i(1, 3, 3)),
            new BlockOccupancy(new Vector3i(1, 3, 4)),
            new BlockOccupancy(new Vector3i(2, 0, 0)),
            new BlockOccupancy(new Vector3i(2, 0, 1)),
            new BlockOccupancy(new Vector3i(2, 0, 2)),
            new BlockOccupancy(new Vector3i(2, 0, 3)),
            new BlockOccupancy(new Vector3i(2, 0, 4)),
            new BlockOccupancy(new Vector3i(2, 1, 0)),
            new BlockOccupancy(new Vector3i(2, 1, 1)),
            new BlockOccupancy(new Vector3i(2, 1, 2)),
            new BlockOccupancy(new Vector3i(2, 1, 3)),
            new BlockOccupancy(new Vector3i(2, 1, 4)),
            new BlockOccupancy(new Vector3i(2, 2, 0)),
            new BlockOccupancy(new Vector3i(2, 2, 1)),
            new BlockOccupancy(new Vector3i(2, 2, 2)),
            new BlockOccupancy(new Vector3i(2, 2, 3)),
            new BlockOccupancy(new Vector3i(2, 2, 4)),
            new BlockOccupancy(new Vector3i(2, 3, 0)),
            new BlockOccupancy(new Vector3i(2, 3, 1)),
            new BlockOccupancy(new Vector3i(2, 3, 2)),
            new BlockOccupancy(new Vector3i(2, 3, 3)),
            new BlockOccupancy(new Vector3i(2, 3, 4)),
            new BlockOccupancy(new Vector3i(3, 0, 0)),
            new BlockOccupancy(new Vector3i(3, 0, 1)),
            new BlockOccupancy(new Vector3i(3, 0, 2)),
            new BlockOccupancy(new Vector3i(3, 0, 3)),
            new BlockOccupancy(new Vector3i(3, 0, 4)),
            new BlockOccupancy(new Vector3i(3, 1, 0)),
            new BlockOccupancy(new Vector3i(3, 1, 1)),
            new BlockOccupancy(new Vector3i(3, 1, 2)),
            new BlockOccupancy(new Vector3i(3, 1, 3)),
            new BlockOccupancy(new Vector3i(3, 1, 4)),
            new BlockOccupancy(new Vector3i(3, 2, 0)),
            new BlockOccupancy(new Vector3i(3, 2, 1)),
            new BlockOccupancy(new Vector3i(3, 2, 2)),
            new BlockOccupancy(new Vector3i(3, 2, 3)),
            new BlockOccupancy(new Vector3i(3, 2, 4)),
            new BlockOccupancy(new Vector3i(3, 3, 0)),
            new BlockOccupancy(new Vector3i(3, 3, 1)),
            new BlockOccupancy(new Vector3i(3, 3, 2)),
            new BlockOccupancy(new Vector3i(3, 3, 3)),
            new BlockOccupancy(new Vector3i(3, 3, 4)),
            });
            // LargeWindowedLumberDoorObject
            WorldObject.AddOccupancy<LargeWindowedLumberDoorObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 3, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 2, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 0, 4), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 4), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 3, 4), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 2, 4), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 3, 3), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 3, 2), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 3, 1), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 0, 3), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 0, 2), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 0, 1), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 3), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 2), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 1), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 2, 3), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 2, 2), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 2, 1), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(1, 0, 0)),
            new BlockOccupancy(new Vector3i(1, 0, 1)),
            new BlockOccupancy(new Vector3i(1, 0, 2)),
            new BlockOccupancy(new Vector3i(1, 0, 3)),
            new BlockOccupancy(new Vector3i(1, 0, 4)),
            new BlockOccupancy(new Vector3i(1, 1, 0)),
            new BlockOccupancy(new Vector3i(1, 1, 1)),
            new BlockOccupancy(new Vector3i(1, 1, 2)),
            new BlockOccupancy(new Vector3i(1, 1, 3)),
            new BlockOccupancy(new Vector3i(1, 1, 4)),
            new BlockOccupancy(new Vector3i(1, 2, 0)),
            new BlockOccupancy(new Vector3i(1, 2, 1)),
            new BlockOccupancy(new Vector3i(1, 2, 2)),
            new BlockOccupancy(new Vector3i(1, 2, 3)),
            new BlockOccupancy(new Vector3i(1, 2, 4)),
            new BlockOccupancy(new Vector3i(1, 3, 0)),
            new BlockOccupancy(new Vector3i(1, 3, 1)),
            new BlockOccupancy(new Vector3i(1, 3, 2)),
            new BlockOccupancy(new Vector3i(1, 3, 3)),
            new BlockOccupancy(new Vector3i(1, 3, 4)),
            new BlockOccupancy(new Vector3i(2, 0, 0)),
            new BlockOccupancy(new Vector3i(2, 0, 1)),
            new BlockOccupancy(new Vector3i(2, 0, 2)),
            new BlockOccupancy(new Vector3i(2, 0, 3)),
            new BlockOccupancy(new Vector3i(2, 0, 4)),
            new BlockOccupancy(new Vector3i(2, 1, 0)),
            new BlockOccupancy(new Vector3i(2, 1, 1)),
            new BlockOccupancy(new Vector3i(2, 1, 2)),
            new BlockOccupancy(new Vector3i(2, 1, 3)),
            new BlockOccupancy(new Vector3i(2, 1, 4)),
            new BlockOccupancy(new Vector3i(2, 2, 0)),
            new BlockOccupancy(new Vector3i(2, 2, 1)),
            new BlockOccupancy(new Vector3i(2, 2, 2)),
            new BlockOccupancy(new Vector3i(2, 2, 3)),
            new BlockOccupancy(new Vector3i(2, 2, 4)),
            new BlockOccupancy(new Vector3i(2, 3, 0)),
            new BlockOccupancy(new Vector3i(2, 3, 1)),
            new BlockOccupancy(new Vector3i(2, 3, 2)),
            new BlockOccupancy(new Vector3i(2, 3, 3)),
            new BlockOccupancy(new Vector3i(2, 3, 4)),
            new BlockOccupancy(new Vector3i(3, 0, 0)),
            new BlockOccupancy(new Vector3i(3, 0, 1)),
            new BlockOccupancy(new Vector3i(3, 0, 2)),
            new BlockOccupancy(new Vector3i(3, 0, 3)),
            new BlockOccupancy(new Vector3i(3, 0, 4)),
            new BlockOccupancy(new Vector3i(3, 1, 0)),
            new BlockOccupancy(new Vector3i(3, 1, 1)),
            new BlockOccupancy(new Vector3i(3, 1, 2)),
            new BlockOccupancy(new Vector3i(3, 1, 3)),
            new BlockOccupancy(new Vector3i(3, 1, 4)),
            new BlockOccupancy(new Vector3i(3, 2, 0)),
            new BlockOccupancy(new Vector3i(3, 2, 1)),
            new BlockOccupancy(new Vector3i(3, 2, 2)),
            new BlockOccupancy(new Vector3i(3, 2, 3)),
            new BlockOccupancy(new Vector3i(3, 2, 4)),
            new BlockOccupancy(new Vector3i(3, 3, 0)),
            new BlockOccupancy(new Vector3i(3, 3, 1)),
            new BlockOccupancy(new Vector3i(3, 3, 2)),
            new BlockOccupancy(new Vector3i(3, 3, 3)),
            new BlockOccupancy(new Vector3i(3, 3, 4)),
            });
            // DoorObject
            WorldObject.AddOccupancy<DoorObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            });
            // DoubleDoorObject
            WorldObject.AddOccupancy<DoubleDoorObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(1, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(1, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            });
            // FramedGlassDoorObject
            WorldObject.AddOccupancy<FramedGlassDoorObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            });
            // DoubleFramedGlassDoorObject
            WorldObject.AddOccupancy<DoubleFramedGlassDoorObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(1, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(1, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            });
            // HewnLogDoorObject
            WorldObject.AddOccupancy<HewnLogDoorObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            });
            // DoubleHewnLogDoorObject
            WorldObject.AddOccupancy<DoubleHewnLogDoorObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(1, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(1, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            });
            // StoneDoorObject
            WorldObject.AddOccupancy<StoneDoorObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            });
            // DoubleStoneDoorObject
            WorldObject.AddOccupancy<DoubleStoneDoorObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(1, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(1, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            });
            // LumberDoorObject
            WorldObject.AddOccupancy<LumberDoorObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            });
            // DoubleLumberDoorObject
            WorldObject.AddOccupancy<DoubleLumberDoorObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(1, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            new BlockOccupancy(new Vector3i(1, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
            });
        }
        
    }
}