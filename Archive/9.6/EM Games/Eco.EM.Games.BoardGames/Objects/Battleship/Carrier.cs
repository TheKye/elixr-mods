using System;
using System.Collections.Generic;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Games.BoardGames
{
    [Serialized, LocDisplayName("Carrier"), MaxStackSize(100)]
    public partial class CarrierItem : WorldObjectItem<CarrierObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("The Carrier for playing Battleship");
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class CarrierObject : BattleshipBase, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Carrier");

        public Type RepresentedItemType => typeof(CarrierItem);

        static CarrierObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = 0; x <= 0; x++)
                for (int y = 0; y <= 0; y++)
                    for (int z = -4; z <= 0; z++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, z), typeof(WorldObjectBlock)));

            AddOccupancy<CarrierObject>(BlockOccupancyList);
        }


    }

    //Todo Add Recipe
    public partial class CarrierRecipe : RecipeFamily
    {

    }
}
