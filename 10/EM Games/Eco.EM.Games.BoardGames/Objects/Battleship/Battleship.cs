using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Occupancy;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Games.BoardGames
{
    [Serialized]
    [LocDisplayName("Battleship")]
    [MaxStackSize(100)]
    [LocDescription("The Battle Ship for playing Battleship")]
    public partial class BattleshipItem : WorldObjectItem<BattleshipObject>
    {
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class BattleshipObject : BattleshipBase, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Battleship");

        public Type RepresentedItemType => typeof(BattleshipItem);

        static BattleshipObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = 0; x <= 0; x++)
                for (int y = 0; y <= 0; y++)
                    for (int z = -3; z <= 0; z++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, z), typeof(WorldObjectBlock)));

            AddOccupancy<BattleshipObject>(BlockOccupancyList);
        }


    }

    //Todo Add Recipe
    public partial class BattleshipRecipe : RecipeFamily
    {

    }
}
