using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;
using System;
using System.Linq;
 
namespace Eco.EM.Building.Bricks
{
    #region Black
    [RequiresSkill(typeof(PotterySkill), 0)]
    public partial class PaintBlackBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintBlackBrickRecipe).Name,
            Assembly = typeof(PaintBlackBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bricks - Black",
            LocalizableName = Localizer.DoStr("Paint Bricks - Black"),
            IngredientList = new()
            {
                new EMIngredient("BrickItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("BlackBrickItem", 1),
            },
            CraftingStation = "KilnItem",

            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static PaintBlackBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintBlackBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Blue
    [RequiresSkill(typeof(PotterySkill), 0)]
    public partial class PaintBlueBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintBlueBrickRecipe).Name,
            Assembly = typeof(PaintBlueBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bricks - Blue",
            LocalizableName = Localizer.DoStr("Paint Bricks - Blue"),
            IngredientList = new()
            {
                new EMIngredient("BrickItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("BlueBrickItem", 1),
            },
            CraftingStation = "KilnItem",

            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static PaintBlueBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintBlueBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Brown
    [RequiresSkill(typeof(PotterySkill), 0)]
    public partial class PaintBrownBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintBrownBrickRecipe).Name,
            Assembly = typeof(PaintBrownBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bricks - Brown",
            LocalizableName = Localizer.DoStr("Paint Bricks - Brown"),
            IngredientList = new()
            {
                new EMIngredient("BrickItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("BrownBrickItem", 1),
            },
            CraftingStation = "KilnItem",

            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static PaintBrownBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintBrownBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Dark Red
    [RequiresSkill(typeof(PotterySkill), 0)]
    public partial class PaintDarkRedBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintDarkRedBrickRecipe).Name,
            Assembly = typeof(PaintDarkRedBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bricks - Dark Red",
            LocalizableName = Localizer.DoStr("Paint Bricks - Dark Red"),
            IngredientList = new()
            {
                new EMIngredient("BrickItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("DarkRedBrickItem", 1),
            },
            CraftingStation = "KilnItem",

            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static PaintDarkRedBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintDarkRedBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Green
    [RequiresSkill(typeof(PotterySkill), 0)]
    public partial class PaintGreenBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintGreenBrickRecipe).Name,
            Assembly = typeof(PaintGreenBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bricks - Green",
            LocalizableName = Localizer.DoStr("Paint Bricks - Green"),
            IngredientList = new()
            {
                new EMIngredient("BrickItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("GreenBrickItem", 1),
            },
            CraftingStation = "KilnItem",

            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static PaintGreenBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintGreenBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Grey
    [RequiresSkill(typeof(PotterySkill), 0)]
    public partial class PaintGreyBrickRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintGreyBrickRecipe).Name,
            Assembly = typeof(PaintGreyBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bricks",
            LocalizableName = Localizer.DoStr("Paint Bricks"),
            IngredientList = new()
            {
                new EMIngredient("BrickItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("GreyBrickItem", 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 40,
            LaborIsStatic = false,
            BaseCraftTime = 0,
            CraftTimeIsStatic = false,
            CraftingStation = "KilnItem",
            RequiredSkillType = typeof(PotterySkill),
            RequiredSkillLevel = 0,

            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static PaintGreyBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintGreyBrickRecipe()
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
    [RequiresSkill(typeof(PotterySkill), 0)]
    public partial class PaintOrangeBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintOrangeBrickRecipe).Name,
            Assembly = typeof(PaintOrangeBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bricks - Orange",
            LocalizableName = Localizer.DoStr("Paint Bricks - Orange"),
            IngredientList = new()
            {
                new EMIngredient("BrickItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("OrangeBrickItem", 1),
            },
            CraftingStation = "KilnItem",

            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static PaintOrangeBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintOrangeBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Pink
    [RequiresSkill(typeof(PotterySkill), 0)]
    public partial class PaintPinkBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintPinkBrickRecipe).Name,
            Assembly = typeof(PaintPinkBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bricks - Pink",
            LocalizableName = Localizer.DoStr("Paint Bricks - Pink"),
            IngredientList = new()
            {
                new EMIngredient("BrickItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("PinkBrickItem", 1),
            },
            CraftingStation = "KilnItem",

            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static PaintPinkBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintPinkBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Purple
    [RequiresSkill(typeof(PotterySkill), 0)]
    public partial class PaintPurpleBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintPurpleBrickRecipe).Name,
            Assembly = typeof(PaintPurpleBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bricks - Purple",
            LocalizableName = Localizer.DoStr("Paint Bricks - Purple"),
            IngredientList = new()
            {
                new EMIngredient("BrickItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("PurpleBrickItem", 1),
            },
            CraftingStation = "KilnItem",

            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static PaintPurpleBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintPurpleBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Red
    [RequiresSkill(typeof(PotterySkill), 0)]
    public partial class PaintRedBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintRedBrickRecipe).Name,
            Assembly = typeof(PaintRedBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bricks - Red",
            LocalizableName = Localizer.DoStr("Paint Bricks - Red"),
            IngredientList = new()
            {
                new EMIngredient("BrickItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("RedBrickItem", 1),
            },
            CraftingStation = "KilnItem",

            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static PaintRedBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintRedBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Yellow
    [RequiresSkill(typeof(PotterySkill), 0)]
    public partial class PaintYellowBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintYellowBrickRecipe).Name,
            Assembly = typeof(PaintYellowBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bricks - Yellow",
            LocalizableName = Localizer.DoStr("Paint Bricks - Yellow"),
            IngredientList = new()
            {
                new EMIngredient("BrickItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("YellowBrickItem", 1),
            },
            CraftingStation = "KilnItem",

            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static PaintYellowBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintYellowBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region White
    [RequiresSkill(typeof(PotterySkill), 0)]
    public partial class PaintWhiteBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintWhiteBrickRecipe).Name,
            Assembly = typeof(PaintWhiteBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bricks - White",
            LocalizableName = Localizer.DoStr("Paint Bricks - White"),
            IngredientList = new()
            {
                new EMIngredient("BrickItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("WhiteBrickItem", 1),
            },
            CraftingStation = "KilnItem",

            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static PaintWhiteBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintWhiteBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintGreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
}
