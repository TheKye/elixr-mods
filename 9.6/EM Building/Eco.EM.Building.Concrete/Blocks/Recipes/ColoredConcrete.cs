using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;
using System.Linq;
using System;

namespace Eco.EM.Building.Concrete
{
    #region Black
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class BlackReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlackReinforcedConcreteRecipe).Name,
            Assembly = typeof(BlackReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Black Reinforced Concrete",
            LocalizableName = Localizer.DoStr("Black Reinforced Concrete"),
            IngredientList = new()
            {
                new EMIngredient("CementItem", false, 1),
                new EMIngredient("RebarItem", false, 2),
                new EMIngredient("SandItem", false, 2),
                new EMIngredient("CrushedRock", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("BlackReinforcedConcreteItem", 4),
            },
            RequiredSkillType = typeof(MasonrySkill),
            CraftingStation = "CementKilnItem",
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static BlackReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlackReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Blue
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class BlueReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlueReinforcedConcreteRecipe).Name,
            Assembly = typeof(BlueReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Blue Reinforced Concrete",
            LocalizableName = Localizer.DoStr("Blue Reinforced Concrete"),
            IngredientList = new()
            {
                new EMIngredient("CementItem", false, 1),
                new EMIngredient("RebarItem", false, 2),
                new EMIngredient("SandItem", false, 2),
                new EMIngredient("CrushedRock", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("BlueReinforcedConcreteItem", 4),
            },
            RequiredSkillType = typeof(MasonrySkill),
            CraftingStation = "CementKilnItem",
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static BlueReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlueReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Brown
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class BrownReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BrownReinforcedConcreteRecipe).Name,
            Assembly = typeof(BrownReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Brown Reinforced Concrete",
            LocalizableName = Localizer.DoStr("Brown Reinforced Concrete"),
            IngredientList = new()
            {
                new EMIngredient("CementItem", false, 1),
                new EMIngredient("RebarItem", false, 2),
                new EMIngredient("SandItem", false, 2),
                new EMIngredient("CrushedRock", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("BrownReinforcedConcreteItem", 4),
            },
            RequiredSkillType = typeof(MasonrySkill),
            CraftingStation = "CementKilnItem",
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static BrownReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BrownReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Green
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class GreenReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GreenReinforcedConcreteRecipe).Name,
            Assembly = typeof(GreenReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Green Reinforced Concrete",
            LocalizableName = Localizer.DoStr("Green Reinforced Concrete"),
            IngredientList = new()
            {
                new EMIngredient("CementItem", false, 1),
                new EMIngredient("RebarItem", false, 2),
                new EMIngredient("SandItem", false, 2),
                new EMIngredient("CrushedRock", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("GreenReinforcedConcreteItem", 4),
            },
            RequiredSkillType = typeof(MasonrySkill),
            CraftingStation = "CementKilnItem",
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static GreenReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GreenReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Grey
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public class GreyReinforcedConcreteRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GreyReinforcedConcreteRecipe).Name,
            Assembly = typeof(GreyReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Colored Reinforced Concrete",
            LocalizableName = Localizer.DoStr("Colored Reinforced Concrete"),
            IngredientList = new()
            {
                new EMIngredient("CementItem", false, 1),
                new EMIngredient("RebarItem", false, 2),
                new EMIngredient("SandItem", false, 2),
                new EMIngredient("CrushedRock", true, 5),

            },
            ProductList = new()
            {
                new EMCraftable("GreyReinforcedConcreteItem", 4),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 40,
            LaborIsStatic = false,
            BaseCraftTime = 4,
            CraftTimeIsStatic = false,
            CraftingStation = "CementKilnItem",
            RequiredSkillType = typeof(MasonrySkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static GreyReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GreyReinforcedConcreteRecipe()
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
    #region Orange
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class OrangeReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(OrangeReinforcedConcreteRecipe).Name,
            Assembly = typeof(OrangeReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Orange Reinforced Concrete",
            LocalizableName = Localizer.DoStr("Orange Reinforced Concrete"),
            IngredientList = new()
            {
                new EMIngredient("CementItem", false, 1),
                new EMIngredient("RebarItem", false, 2),
                new EMIngredient("SandItem", false, 2),
                new EMIngredient("CrushedRock", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("OrangeReinforcedConcreteItem", 4),
            },
            RequiredSkillType = typeof(MasonrySkill),
            CraftingStation = "CementKilnItem",
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static OrangeReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public OrangeReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Purple
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PurpleReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PurpleReinforcedConcreteRecipe).Name,
            Assembly = typeof(PurpleReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Purple Reinforced Concrete",
            LocalizableName = Localizer.DoStr("Purple Reinforced Concrete"),
            IngredientList = new()
            {
                new EMIngredient("CementItem", false, 1),
                new EMIngredient("RebarItem", false, 2),
                new EMIngredient("SandItem", false, 2),
                new EMIngredient("CrushedRock", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("PurpleReinforcedConcreteItem", 4),
            },
            RequiredSkillType = typeof(MasonrySkill),
            CraftingStation = "CementKilnItem",
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static PurpleReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PurpleReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Pink
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PinkReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PinkReinforcedConcreteRecipe).Name,
            Assembly = typeof(PinkReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Pink Reinforced Concrete",
            LocalizableName = Localizer.DoStr("Pink Reinforced Concrete"),
            IngredientList = new()
            {
                new EMIngredient("CementItem", false, 1),
                new EMIngredient("RebarItem", false, 2),
                new EMIngredient("SandItem", false, 2),
                new EMIngredient("CrushedRock", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("PinkReinforcedConcreteItem", 4),
            },
            RequiredSkillType = typeof(MasonrySkill),
            CraftingStation = "CementKilnItem",
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static PinkReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PinkReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Red
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class RedReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RedReinforcedConcreteRecipe).Name,
            Assembly = typeof(RedReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Red Reinforced Concrete",
            LocalizableName = Localizer.DoStr("Red Reinforced Concrete"),
            IngredientList = new()
            {
                new EMIngredient("CementItem", false, 1),
                new EMIngredient("RebarItem", false, 2),
                new EMIngredient("SandItem", false, 2),
                new EMIngredient("CrushedRock", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("RedReinforcedConcreteItem", 4),
            },
            RequiredSkillType = typeof(MasonrySkill),
            CraftingStation = "CementKilnItem",
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static RedReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RedReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region White
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class WhiteReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WhiteReinforcedConcreteRecipe).Name,
            Assembly = typeof(WhiteReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "White Reinforced Concrete",
            LocalizableName = Localizer.DoStr("White Reinforced Concrete"),
            IngredientList = new()
            {
                new EMIngredient("CementItem", false, 1),
                new EMIngredient("RebarItem", false, 2),
                new EMIngredient("SandItem", false, 2),
                new EMIngredient("CrushedRock", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("WhiteReinforcedConcreteItem", 4),
            },
            RequiredSkillType = typeof(MasonrySkill),
            CraftingStation = "CementKilnItem",
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static WhiteReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WhiteReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Yellow
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class YellowReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(YellowReinforcedConcreteRecipe).Name,
            Assembly = typeof(YellowReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Yellow Reinforced Concrete",
            LocalizableName = Localizer.DoStr("Yellow Reinforced Concrete"),
            IngredientList = new()
            {
                new EMIngredient("CementItem", false, 1),
                new EMIngredient("RebarItem", false, 2),
                new EMIngredient("SandItem", false, 2),
                new EMIngredient("CrushedRock", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("YellowReinforcedConcreteItem", 4),
            },
            RequiredSkillType = typeof(MasonrySkill),
            CraftingStation = "CementKilnItem",
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static YellowReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public YellowReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
}
