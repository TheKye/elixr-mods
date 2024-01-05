using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eco.EM.Framework;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Games.BoardGames
{

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class RedCheckerPieceObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Red Checker Piece");
        public virtual Type RepresentedItemType => typeof(RedCheckerPieceItem);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        static RedCheckerPieceObject()
        {
        }

        protected override void Initialize() { }
        protected override void PostInitialize() { }


    }

    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Red Checker Piece")]
    public partial class RedCheckerPieceItem : WorldObjectItem<RedCheckerPieceObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Basic Piece for Playing Checkers");
        static RedCheckerPieceItem() { }
    }

    // Skill requirements
    [RequiresSkill(typeof(CarpentrySkill), 0)]
    public partial class RedCheckerPieceRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RedCheckerPieceRecipe).Name,
            Assembly = typeof(RedCheckerPieceRecipe).AssemblyQualifiedName,
            HiddenName = "Red Checker Piece",
            LocalizableName = Localizer.DoStr("Red Checker Piece"),
            IngredientList = new()
            {
                new EMIngredient(item: "Wood", isTag: true, amount: 20, isStatic: false),
            },
            ProductList = new()
            {
                new EMCraftable(item: "RedCheckerPieceItem", amount: 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "CarvingTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static RedCheckerPieceRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RedCheckerPieceRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }


    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class RedCheckerKingObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Red Checker King");
        public virtual Type RepresentedItemType => typeof(RedCheckerKingItem);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        static RedCheckerKingObject()
        {
            // Occupancy
        }

        protected override void Initialize() { }
        protected override void PostInitialize() { }


    }

    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Red Checker King")]
    public partial class RedCheckerKingItem : WorldObjectItem<RedCheckerKingObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("The King Piece used in playing Checkers");
        static RedCheckerKingItem() { }
    }

    // Skill requirements
    [RequiresSkill(typeof(CarpentrySkill), 0)]
    public partial class RedCheckerKingRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RedCheckerKingRecipe).Name,
            Assembly = typeof(RedCheckerKingRecipe).AssemblyQualifiedName,
            HiddenName = "Red Checker King",
            LocalizableName = Localizer.DoStr("Red Checker King"),
            IngredientList = new()
            {
                new EMIngredient(item: "Wood", isTag: true, amount: 20, isStatic: false),
            },
            ProductList = new()
            {
                new EMCraftable(item: "RedCheckerKingItem", amount: 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "CarvingTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static RedCheckerKingRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RedCheckerKingRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }


    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class BlackCheckerPieceObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Black Checker Piece");
        public virtual Type RepresentedItemType => typeof(BlackCheckerPieceItem);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        static BlackCheckerPieceObject()
        {
        }

        protected override void Initialize() { }
        protected override void PostInitialize() { }


    }

    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Black Checker Piece")]
    public partial class BlackCheckerPieceItem : WorldObjectItem<BlackCheckerPieceObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Basic Piece for Playing Checkers");
        static BlackCheckerPieceItem() { }
    }

    // Skill requirements
    [RequiresSkill(typeof(CarpentrySkill), 0)]
    public partial class BlackCheckerPieceRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlackCheckerPieceRecipe).Name,
            Assembly = typeof(BlackCheckerPieceRecipe).AssemblyQualifiedName,
            HiddenName = "Black Checker Piece",
            LocalizableName = Localizer.DoStr("Black Checker Piece"),
            IngredientList = new()
            {
                new EMIngredient(item: "Wood", isTag: true, amount: 20, isStatic: false),
            },
            ProductList = new()
            {
                new EMCraftable(item: "BlackCheckerPieceItem", amount: 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "CarvingTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static BlackCheckerPieceRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlackCheckerPieceRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }


    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class BlackCheckerKingObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Black Checker King");
        public virtual Type RepresentedItemType => typeof(BlackCheckerKingItem);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        static BlackCheckerKingObject()
        {
            // Occupancy
        }

        protected override void Initialize() { }
        protected override void PostInitialize() { }


    }

    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Black Checker King")]
    public partial class BlackCheckerKingItem : WorldObjectItem<BlackCheckerKingObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("The King Piece used in playing Checkers");
        static BlackCheckerKingItem() { }
    }

    // Skill requirements
    [RequiresSkill(typeof(CarpentrySkill), 0)]
    public partial class BlackCheckerKingRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlackCheckerKingRecipe).Name,
            Assembly = typeof(BlackCheckerKingRecipe).AssemblyQualifiedName,
            HiddenName = "Black Checker King",
            LocalizableName = Localizer.DoStr("Black Checker King"),
            IngredientList = new()
            {
                new EMIngredient(item: "Wood", isTag: true, amount: 20, isStatic: false),
            },
            ProductList = new()
            {
                new EMCraftable(item: "BlackCheckerKingItem", amount: 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "CarvingTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static BlackCheckerKingRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlackCheckerKingRecipe()
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