using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;
using System;
using System.Linq;

namespace Eco.EM.Building.Concrete
{
    #region Black
    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class PaintBlackReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintBlackReinforcedConcreteRecipe).Name,
            Assembly = typeof(PaintBlackReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Reinforced Concrete - Black",
            LocalizableName = Localizer.DoStr("Paint Reinforced Concrete - Black"),
            IngredientList = new()
            {
                new EMIngredient("ReinforcedConcreteItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("BlackReinforcedConcreteItem", 1),
            },
            CraftingStation = "CementKilnItem",
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static PaintBlackReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintBlackReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Blue
    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class PaintBlueReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintBlueReinforcedConcreteRecipe).Name,
            Assembly = typeof(PaintBlueReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Reinforced Concrete - Blue",
            LocalizableName = Localizer.DoStr("Paint Reinforced Concrete - Blue"),
            IngredientList = new()
            {
                new EMIngredient("ReinforcedConcreteItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("BlueReinforcedConcreteItem", 1),
            },
            CraftingStation = "CementKilnItem",
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static PaintBlueReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintBlueReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Brown
    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class PaintBrownReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintBrownReinforcedConcreteRecipe).Name,
            Assembly = typeof(PaintBrownReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Reinforced Concrete - Brown",
            LocalizableName = Localizer.DoStr("Paint Reinforced Concrete - Brown"),
            IngredientList = new()
            {
                new EMIngredient("ReinforcedConcreteItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("BrownReinforcedConcreteItem", 1),
            },
            CraftingStation = "CementKilnItem",
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static PaintBrownReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintBrownReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Green
    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class PaintGreenReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintGreenReinforcedConcreteRecipe).Name,
            Assembly = typeof(PaintGreenReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Reinforced Concrete - Green",
            LocalizableName = Localizer.DoStr("Paint Reinforced Concrete - Green"),
            IngredientList = new()
            {
                new EMIngredient("ReinforcedConcreteItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("GreenReinforcedConcreteItem", 1),
            },
            CraftingStation = "CementKilnItem",
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static PaintGreenReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintGreenReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Grey
    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class PaintGreyReinforcedConcreteRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintGreyReinforcedConcreteRecipe).Name,
            Assembly = typeof(PaintGreyReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Reinforced Concrete",
            LocalizableName = Localizer.DoStr("Paint Reinforced Concrete"),
            IngredientList = new()
            {
                new EMIngredient("ReinforcedConcreteItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("GreyReinforcedConcreteItem", 1),
            },
            BaseExperienceOnCraft = 0,
            BaseLabor = 40,
            LaborIsStatic = false,
            BaseCraftTime = 0,
            CraftTimeIsStatic = false,
            CraftingStation = "CementKilnItem",
            RequiredSkillType = typeof(MasonrySkill),
            RequiredSkillLevel = 0,
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static PaintGreyReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintGreyReinforcedConcreteRecipe()
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
    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class PaintOrangeReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintOrangeReinforcedConcreteRecipe).Name,
            Assembly = typeof(PaintOrangeReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Reinforced Concrete - Orange",
            LocalizableName = Localizer.DoStr("Paint Reinforced Concrete - Orange"),
            IngredientList = new()
            {
                new EMIngredient("ReinforcedConcreteItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("OrangeReinforcedConcreteItem", 1),
            },
            CraftingStation = "CementKilnItem",
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static PaintOrangeReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintOrangeReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Pink
    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class PaintPinkReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintPinkReinforcedConcreteRecipe).Name,
            Assembly = typeof(PaintPinkReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Reinforced Concrete - Pink",
            LocalizableName = Localizer.DoStr("Paint Reinforced Concrete - Pink"),
            IngredientList = new()
            {
                new EMIngredient("ReinforcedConcreteItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("PinkReinforcedConcreteItem", 1),
            },
            CraftingStation = "CementKilnItem",
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static PaintPinkReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintPinkReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Purple
    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class PaintPurpleReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintPurpleReinforcedConcreteRecipe).Name,
            Assembly = typeof(PaintPurpleReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Reinforced Concrete - Purple",
            LocalizableName = Localizer.DoStr("Paint Reinforced Concrete - Purple"),
            IngredientList = new()
            {
                new EMIngredient("ReinforcedConcreteItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("PurpleReinforcedConcreteItem", 1),
            },
            CraftingStation = "CementKilnItem",
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static PaintPurpleReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintPurpleReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Red
    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class PaintRedReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintRedReinforcedConcreteRecipe).Name,
            Assembly = typeof(PaintRedReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Reinforced Concrete - Red",
            LocalizableName = Localizer.DoStr("Paint Reinforced Concrete - Red"),
            IngredientList = new()
            {
                new EMIngredient("ReinforcedConcreteItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("RedReinforcedConcreteItem", 1),
            },
            CraftingStation = "CementKilnItem",
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static PaintRedReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintRedReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Yellow
    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class PaintYellowReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintYellowReinforcedConcreteRecipe).Name,
            Assembly = typeof(PaintYellowReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Reinforced Concrete - Yellow",
            LocalizableName = Localizer.DoStr("Paint Reinforced Concrete - Yellow"),
            IngredientList = new()
            {
                new EMIngredient("ReinforcedConcreteItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("YellowReinforcedConcreteItem", 1),
            },
            CraftingStation = "CementKilnItem",
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static PaintYellowReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintYellowReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region White
    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class PaintWhiteReinforcedConcreteRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintWhiteReinforcedConcreteRecipe).Name,
            Assembly = typeof(PaintWhiteReinforcedConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Reinforced Concrete - White",
            LocalizableName = Localizer.DoStr("Paint Reinforced Concrete - White"),
            IngredientList = new()
            {
                new EMIngredient("ReinforcedConcreteItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("WhiteReinforcedConcreteItem", 1),
            },
            CraftingStation = "CementKilnItem",
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static PaintWhiteReinforcedConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintWhiteReinforcedConcreteRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyReinforcedConcreteRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
}
