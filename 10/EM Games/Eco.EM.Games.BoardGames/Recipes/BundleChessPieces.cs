using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Games.BoardGames
{
    public partial class BundleChessPiecesRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BundleChessPiecesRecipe).Name,
            Assembly = typeof(BundleChessPiecesRecipe).AssemblyQualifiedName,
            HiddenName = "Bundle Chess Pieces - Stone",
            LocalizableName = Localizer.DoStr("Bundle Chess Pieces - Stone"),
            IngredientList = new()
            {
                new EMIngredient("StonePawnItem", false, 8, true),
                new EMIngredient("StoneKingItem", false, 1, true),
                new EMIngredient("StoneQueenItem", false, 1, true),
                new EMIngredient("StoneKnightItem", false, 2, true),
                new EMIngredient("StoneBishopItem", false, 2, true),
                new EMIngredient("StoneRookItem", false, 2, true),
            },
            ProductList = new()
            {
                new EMCraftable("ChessPieceBundleItem"),
            },
            BaseExperienceOnCraft = 0,
            BaseLabor = 0,
            LaborIsStatic = false,
            BaseCraftTime = 0,
            CraftTimeIsStatic = false,
            CraftingStation = "CarvingTableItem",
        };

        static BundleChessPiecesRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BundleChessPiecesRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    public partial class BundleChessPieces2Recipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BundleChessPieces2Recipe).Name,
            Assembly = typeof(BundleChessPieces2Recipe).AssemblyQualifiedName,
            HiddenName = "Bundle Chess Pieces - Wood",
            LocalizableName = Localizer.DoStr("Bundle Chess Pieces - Wood"),
            IngredientList = new()
            {
                new EMIngredient("WoodPawnItem", false, 8, true),
                new EMIngredient("WoodKingItem", false, 1, true),
                new EMIngredient("WoodQueenItem", false, 1, true),
                new EMIngredient("WoodKnightItem", false, 2, true),
                new EMIngredient("WoodBishopItem", false, 2, true),
                new EMIngredient("WoodRookItem", false, 2, true),
            },
            ProductList = new()
            {
                new EMCraftable("ChessPieceBundle2Item"),
            },
            BaseExperienceOnCraft = 0,
            BaseLabor = 0,
            LaborIsStatic = false,
            BaseCraftTime = 0,
            CraftTimeIsStatic = false,
            CraftingStation = "CarvingTableItem",
        };

        static BundleChessPieces2Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BundleChessPieces2Recipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
