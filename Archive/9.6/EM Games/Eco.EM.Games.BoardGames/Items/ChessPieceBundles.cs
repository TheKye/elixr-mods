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
    [LocDisplayName("Chess Piece Bundle - Stone")]
    public partial class ChessPieceBundleItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Bundle Containing all the Chess Pieces for the White Chess Pieces");
        static ChessPieceBundleItem() { }

        public override InteractResult OnActRight(InteractionContext context)
        {
            var inventory = context.Player.User.Inventory.ToolbarBackpack;

            var success1 = inventory.TryAddItems(typeof(StonePawnItem), 8);
            var success2 = inventory.TryAddItems(typeof(StoneQueenItem), 1);
            var success3 = inventory.TryAddItems(typeof(StoneKnightItem), 2);
            var success4 = inventory.TryAddItems(typeof(StoneBishopItem), 2);
            var success5 = inventory.TryAddItems(typeof(StoneRookItem), 2);
            var success6 = inventory.TryAddItems(typeof(StoneKingItem), 1);

            if (success1.Success && success2.Success && success3.Success && success4.Success && success5.Success && success6.Success)
            {
                inventory.TryRemoveItem(typeof(ChessPieceBundleItem));
                return InteractResult.Success;
            }
            else
            {
                inventory.TryRemoveItems(typeof(StonePawnItem), 8);
                inventory.TryRemoveItems(typeof(StoneQueenItem), 1);
                inventory.TryRemoveItems(typeof(StoneKnightItem), 2);
                inventory.TryRemoveItems(typeof(StoneBishopItem), 2);
                inventory.TryRemoveItems(typeof(StoneRookItem), 2);
                inventory.TryRemoveItems(typeof(StoneKingItem), 1);

                return InteractResult.Fail;
            }
        }
        public override InteractResult OnActInteract(InteractionContext context)
        {
            return OnActRight(context);
        }
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

        public override InteractResult OnActRight(InteractionContext context)
        {
            var inventory = context.Player.User.Inventory.ToolbarBackpack;

            var success1 = inventory.TryAddItems(typeof(WoodPawnItem), 8);
            var success2 = inventory.TryAddItems(typeof(WoodQueenItem), 1);
            var success3 = inventory.TryAddItems(typeof(WoodKnightItem), 2);
            var success4 = inventory.TryAddItems(typeof(WoodBishopItem), 2);
            var success5 = inventory.TryAddItems(typeof(WoodRookItem), 2);
            var success6 = inventory.TryAddItems(typeof(WoodKingItem), 1);

            if (success1.Success && success2.Success && success3.Success && success4.Success && success5.Success && success6.Success)
            {
                inventory.TryRemoveItem(typeof(ChessPieceBundle2Item));
                return InteractResult.Success;
            }
            else
            {
                inventory.TryRemoveItems(typeof(WoodPawnItem), 8);
                inventory.TryRemoveItems(typeof(WoodQueenItem), 1);
                inventory.TryRemoveItems(typeof(WoodKnightItem), 2);
                inventory.TryRemoveItems(typeof(WoodBishopItem), 2);
                inventory.TryRemoveItems(typeof(WoodRookItem), 2);
                inventory.TryRemoveItems(typeof(WoodKingItem), 1);

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
