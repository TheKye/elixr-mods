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
    [Serialized, LocDisplayName("Submarine"), MaxStackSize(100)]
    public partial class SubmarineItem : WorldObjectItem<SubmarineObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("The Submarine used for playing Battleship");
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class SubmarineObject : BattleshipBase, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Submarine");

        public Type RepresentedItemType => typeof(SubmarineItem);

        static SubmarineObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = 0; x <= 0; x++)
                for (int y = 0; y <= 0; y++)
                    for (int z = -2; z <= 0; z++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, z), typeof(WorldObjectBlock)));

            AddOccupancy<SubmarineObject>(BlockOccupancyList);
        }

    }

    //Todo Add Recipe
    public partial class SubmarineRecipe : RecipeFamily
    {

    }
}
