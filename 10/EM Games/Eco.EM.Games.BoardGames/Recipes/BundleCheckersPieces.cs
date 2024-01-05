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
    public partial class BundleCheckersPiecesRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BundleCheckersPiecesRecipe).Name,
            Assembly = typeof(BundleCheckersPiecesRecipe).AssemblyQualifiedName,
            HiddenName = "Bundle Checkers Pieces - Red",
            LocalizableName = Localizer.DoStr("Bundle Checkers Pieces - Red"),
            IngredientList = new()
            {
                new EMIngredient("RedCheckerPieceItem", false, 12, true),
                new EMIngredient("RedCheckerKingItem", false, 6, true),
            },
            ProductList = new()
            {
                new EMCraftable("CheckersPieceBundleItem"),
            },
            BaseExperienceOnCraft = 0,
            BaseLabor = 0,
            LaborIsStatic = false,
            BaseCraftTime = 0,
            CraftTimeIsStatic = false,
            CraftingStation = "CarvingTableItem",
        };

        static BundleCheckersPiecesRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BundleCheckersPiecesRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    public partial class BundleCheckersPieces2Recipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BundleCheckersPieces2Recipe).Name,
            Assembly = typeof(BundleCheckersPieces2Recipe).AssemblyQualifiedName,
            HiddenName = "Bundle Checkers Pieces - Black",
            LocalizableName = Localizer.DoStr("Bundle Checkers Pieces - Black"),
            IngredientList = new()
            {
                new EMIngredient("BlackCheckerPieceItem", false, 12, true),
                new EMIngredient("BlackCheckerKingItem", false, 6, true),
            },
            ProductList = new()
            {
                new EMCraftable("CheckersPieceBundle2Item"),
            },
            BaseExperienceOnCraft = 0,
            BaseLabor = 0,
            LaborIsStatic = false,
            BaseCraftTime = 0,
            CraftTimeIsStatic = false,
            CraftingStation = "CarvingTableItem",
        };

        static BundleCheckersPieces2Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BundleCheckersPieces2Recipe()
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
