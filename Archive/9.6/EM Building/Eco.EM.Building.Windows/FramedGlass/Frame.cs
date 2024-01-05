using Eco.Gameplay.Components;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System.Collections.Generic;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;
using System;
using System.Linq;

namespace Eco.EM.Building.Windows
{
    #region Frame 1x1
    [Serialized, Weight(10), MaxStackSize(500), LocDisplayName("Frame"), Currency]
    public partial class FrameItem : Item
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Frames");
        public override LocString DisplayDescription => Localizer.DoStr("A Small Frame For Stained Glass.");
    }

    [RequiresSkill(typeof(SmeltingSkill), 3)]
    public partial class FrameRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(FrameRecipe).Name,
            Assembly = typeof(FrameRecipe).AssemblyQualifiedName,
            HiddenName = "Frame",
            LocalizableName = Localizer.DoStr("Frame"),
            IngredientList = new()
            {
                new EMIngredient("SteelBarItem", false, 5),
            },
            ProductList = new()
            {
                new EMCraftable("FrameItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "AnvilItem",
            RequiredSkillType = typeof(SmeltingSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(SmeltingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent) },
        };

        static FrameRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public FrameRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
    #endregion
    #region Frame Long 1x2
    [Serialized, Weight(10), MaxStackSize(500), LocDisplayName("Long Frame"), Currency]
    public partial class LongFrameItem : Item
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Long Frames");
        public override LocString DisplayDescription => Localizer.DoStr("A Wide Frame For Stained Glass");
    }

    [RequiresSkill(typeof(SmeltingSkill), 4)]
    public partial class LongFrameRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LongFrameRecipe).Name,
            Assembly = typeof(LongFrameRecipe).AssemblyQualifiedName,
            HiddenName = "Long Frame",
            LocalizableName = Localizer.DoStr("Long Frame"),
            IngredientList = new()
            {
                new EMIngredient("SteelBarItem", false, 8),
            },
            ProductList = new()
            {
                new EMCraftable("LongFrameItem"),
            },
            CraftingStation = "AnvilItem",
            RequiredSkillType = typeof(SmeltingSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(SmeltingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent) },
        };

        static LongFrameRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LongFrameRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(FrameRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Frame Large 2x2
    [Serialized, Weight(10), MaxStackSize(500), LocDisplayName("Large Frame"), Currency]
    public partial class LargeFrameItem : Item
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Large Frames");
        public override LocString DisplayDescription => Localizer.DoStr("A Large Frame For Stained Glass.");
    }

    [RequiresSkill(typeof(SmeltingSkill), 5)]
    public partial class LargeFrameRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LargeFrameRecipe).Name,
            Assembly = typeof(LargeFrameRecipe).AssemblyQualifiedName,
            HiddenName = "Large Frame",
            LocalizableName = Localizer.DoStr("Large Frame"),
            IngredientList = new()
            {
                new EMIngredient("SteelBarItem", false, 12),
            },
            ProductList = new()
            {
                new EMCraftable("LargeFrameItem"),
            },
            CraftingStation = "AnvilItem",
            RequiredSkillType = typeof(SmeltingSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(SmeltingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent) },
        };

        static LargeFrameRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LargeFrameRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(FrameRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Frame Tall 2x1
    [Serialized, Weight(10), MaxStackSize(500), LocDisplayName("Tall Frame"), Currency]
    public partial class TallFrameItem : Item
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Tall Frames");
        public override LocString DisplayDescription => Localizer.DoStr("A Tall Frame For Stained Glass.");
    }

    [RequiresSkill(typeof(SmeltingSkill), 4)]
    public partial class TallFrameRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TallFrameRecipe).Name,
            Assembly = typeof(TallFrameRecipe).AssemblyQualifiedName,
            HiddenName = "Tall Frame",
            LocalizableName = Localizer.DoStr("Tall Frame"),
            IngredientList = new()
            {
                new EMIngredient("SteelBarItem", false, 8),
            },
            ProductList = new()
            {
                new EMCraftable("TallFrameItem"),
            },
            CraftingStation = "AnvilItem",
            RequiredSkillType = typeof(SmeltingSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(SmeltingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent) },
        };

        static TallFrameRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TallFrameRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(FrameRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
}
