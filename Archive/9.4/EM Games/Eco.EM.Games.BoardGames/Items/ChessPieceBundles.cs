using Eco.EM.Framework;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Games.BoardGames
{
    [Serialized, Weight(50), MaxStackSize(10)]
    [LocDisplayName("Chess Piece Bundle - Stone")]
    public partial class ChessPieceBundleItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Bundle Containing all the Chess Pieces for the White Chess Pieces");
        static ChessPieceBundleItem() { }
    }

    // Skill requirements
    [RequiresSkill(typeof(MasonrySkill), 3)]
    public partial class ChessPieceBundleRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ChessPieceBundleRecipe).Name,
            Assembly = typeof(ChessPieceBundleRecipe).AssemblyQualifiedName,
            HiddenName = "Chess Piece Bundle - Stone",
            LocalizableName = Localizer.DoStr("Chess Piece Bundle - Stone"),
            IngredientList = new()
            {

                new EMIngredient(item: "Rock", isTag: true, amount: 320, isStatic: false),
            },
            ProductList = new()
            {

                new EMCraftable(item: "ChessPieceBundleItem", amount: 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "CarvingTableItem",
            RequiredSkillType = typeof(MasonrySkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static ChessPieceBundleRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ChessPieceBundleRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [Serialized, Weight(50), MaxStackSize(10)]
    [LocDisplayName("Chess Piece Bundle - Wood")]
    public partial class ChessPieceBundle2Item : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Bundle Containing all the Chess Pieces for the Black Chess Pieces");
        static ChessPieceBundle2Item() { }
    }

    // Skill requirements
    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class ChessPieceBundle2Recipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ChessPieceBundle2Recipe).Name,
            Assembly = typeof(ChessPieceBundle2Recipe).AssemblyQualifiedName,
            HiddenName = "Chess Piece Bundle - Wood",
            LocalizableName = Localizer.DoStr("Chess Piece Bundle - Wood"),
            IngredientList = new()
            {
                new EMIngredient(item: "Wood", isTag: true, amount: 320, isStatic: false),
            },
            ProductList = new()
            {
                new EMCraftable(item: "ChessPieceBundle2Item", amount: 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 3,
            CraftTimeIsStatic = false,
            CraftingStation = "CarvingTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static ChessPieceBundle2Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ChessPieceBundle2Recipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
