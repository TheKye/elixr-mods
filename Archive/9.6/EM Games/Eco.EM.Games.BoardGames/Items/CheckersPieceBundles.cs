using Eco.EM.Framework;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Interactions;
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
    [LocDisplayName("Checkers Piece Bundle - Red")]
    public partial class CheckersPieceBundleItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Bundle Containing all the Checkers Pieces for the Red Checkers Pieces");
        static CheckersPieceBundleItem() { }

        public override InteractResult OnActRight(InteractionContext context)
        {
            var inventory = context.Player.User.Inventory.ToolbarBackpack;

            var success1 = inventory.TryAddItems(typeof(RedCheckerPieceItem), 12);
            var success2 = inventory.TryAddItems(typeof(RedCheckerKingItem), 6);
            if(success1.Success && success2.Success)
            {
                inventory.TryRemoveItem(typeof(CheckersPieceBundleItem));
                return InteractResult.Success;
            }
            else
            {
                inventory.TryRemoveItems(typeof(RedCheckerPieceItem), 12);
                inventory.TryRemoveItems(typeof(RedCheckerKingItem), 6);

                return InteractResult.Fail;
            }
        }

        public override InteractResult OnActInteract(InteractionContext context)
        {
            return OnActRight(context);
        }
    }

    // Skill requirements
    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class CheckersPieceBundleRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(CheckersPieceBundleRecipe).Name,
            Assembly = typeof(CheckersPieceBundleRecipe).AssemblyQualifiedName,
            HiddenName = "Checkers Piece Bundle - Red",
            LocalizableName = Localizer.DoStr("Checkers Piece Bundle - Red"),
            IngredientList = new()
            {

                new EMIngredient(item: "Wood", isTag: true, amount: 240, isStatic: false),
            },
            ProductList = new()
            {

                new EMCraftable(item: "CheckersPieceBundleItem", amount: 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "CarvingTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static CheckersPieceBundleRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public CheckersPieceBundleRecipe()
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
    [LocDisplayName("Checkers Piece Bundle - Black")]
    public partial class CheckersPieceBundle2Item : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Bundle Containing all the Checkers Pieces for the Black Checkers Pieces");
        static CheckersPieceBundle2Item() { }

        public override InteractResult OnActRight(InteractionContext context)
        {
            var inventory = context.Player.User.Inventory.ToolbarBackpack;

            var success1 = inventory.TryAddItems(typeof(BlackCheckerPieceItem), 12);
            var success2 = inventory.TryAddItems(typeof(BlackCheckerKingItem), 6);

            if (success1.Success && success2.Success)
            {
                inventory.TryRemoveItem(typeof(CheckersPieceBundle2Item));
                return InteractResult.Success;
            }
            else
            {
                inventory.TryRemoveItems(typeof(BlackCheckerPieceItem), 12);
                inventory.TryRemoveItems(typeof(BlackCheckerKingItem), 6);

                return InteractResult.Fail;
            }
        }

        public override InteractResult OnActInteract(InteractionContext context)
        {
            return OnActRight(context);
        }
    }

    // Skill requirements
    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class CheckersPieceBundle2Recipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(CheckersPieceBundle2Recipe).Name,
            Assembly = typeof(CheckersPieceBundle2Recipe).AssemblyQualifiedName,
            HiddenName = "Checkers Piece Bundle - Black",
            LocalizableName = Localizer.DoStr("Checkers Piece Bundle - Black"),
            IngredientList = new()
            {
                new EMIngredient(item: "Wood", isTag: true, amount: 240, isStatic: false),
            },
            ProductList = new()
            {
                new EMCraftable(item: "CheckersPieceBundle2Item", amount: 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "CarvingTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static CheckersPieceBundle2Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public CheckersPieceBundle2Recipe()
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
