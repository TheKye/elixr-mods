using Eco.Core.Items;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;

namespace Eco.EM.Games.BoardTools
{
    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class GameBoardBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GameBoardItem);
    }

    [Serialized]
    [LocDisplayName("Game Boards")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true)]
    [Currency]
    [Tag("Currency")]
    [Tag("Constructable")]
    [Tier(2)]
    [LocDescription("A Block That is used to place down game boards!")]
    public partial class GameBoardItem : BlockItem<GameBoardBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Game Boards");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
            typeof(GameBoardStacked1Block),
            typeof(GameBoardStacked2Block),
            typeof(GameBoardStacked3Block),
            typeof(GameBoardStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class GameBoardStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GameBoardStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GameBoardStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class GameBoardStacked4Block : PickupableBlock { } //Only a wall if it's all 4 GameBoard

    //todo Add Recipe
    public partial class BoardBlockRecipe : RecipeFamily
    {
    
    } 
}
