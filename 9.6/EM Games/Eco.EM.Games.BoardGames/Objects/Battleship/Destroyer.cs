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
    [Serialized, LocDisplayName("Destroyer"), MaxStackSize(100)]
    public partial class DestroyerItem : WorldObjectItem<DestroyerObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("The Destroyer for playing Battleship");
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class DestroyerObject : BattleshipBase, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Destroyer");

        public Type RepresentedItemType => typeof(DestroyerItem);

        static DestroyerObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = 0; x <= 0; x++)
                for (int y = 0; y <= 0; y++)
                    for (int z = -2; z <= 0; z++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, z), typeof(WorldObjectBlock)));

            AddOccupancy<DestroyerObject>(BlockOccupancyList);
        }


    }

    //Todo Add Recipe
    public partial class DestroyerRecipe : RecipeFamily
    {

    }
}
