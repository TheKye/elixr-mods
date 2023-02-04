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
    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class BlackBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlackBrickRecipe).Name,
            Assembly = typeof(BlackBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Black Bricks",
            LocalizableName = Localizer.DoStr("Black Bricks"),
            IngredientList = new()
            {
                new EMIngredient("ClayItem", false, 1),
                new EMIngredient("MortarItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("BlackBrickItem"),
            },
            CraftingStation = "KilnItem",
            IngredientImprovementTalents = typeof(PotteryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static BlackBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlackBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Blue
    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class BlueBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlueBrickRecipe).Name,
            Assembly = typeof(BlueBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Blue Bricks",
            LocalizableName = Localizer.DoStr("Blue Bricks"),
            IngredientList = new()
            {
                new EMIngredient("ClayItem", false, 1),
                new EMIngredient("MortarItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("BlueBrickItem"),
            },
            CraftingStation = "KilnItem",
            IngredientImprovementTalents = typeof(PotteryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static BlueBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlueBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Brown
    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class BrownBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BrownBrickRecipe).Name,
            Assembly = typeof(BrownBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Brown Bricks",
            LocalizableName = Localizer.DoStr("Brown Bricks"),
            IngredientList = new()
            {
                new EMIngredient("ClayItem", false, 1),
                new EMIngredient("MortarItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("BrownBrickItem"),
            },
            CraftingStation = "KilnItem",
            IngredientImprovementTalents = typeof(PotteryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static BrownBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BrownBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Dark Red
    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class DarkRedBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(DarkRedBrickRecipe).Name,
            Assembly = typeof(DarkRedBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Dark Red Bricks",
            LocalizableName = Localizer.DoStr("Dark Red Bricks"),
            IngredientList = new()
            {
                new EMIngredient("ClayItem", false, 1),
                new EMIngredient("MortarItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("DarkRedBrickItem"),
            },
            CraftingStation = "KilnItem",
            IngredientImprovementTalents = typeof(PotteryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static DarkRedBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public DarkRedBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Green
    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class GreenBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GreenBrickRecipe).Name,
            Assembly = typeof(GreenBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Green Bricks",
            LocalizableName = Localizer.DoStr("Green Bricks"),
            IngredientList = new()
            {
                new EMIngredient("ClayItem", false, 1),
                new EMIngredient("MortarItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("GreenBrickItem"),
            },
            CraftingStation = "KilnItem",
            IngredientImprovementTalents = typeof(PotteryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static GreenBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GreenBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Grey
    [RequiresSkill(typeof(PotterySkill), 1)]
    public class GreyBrickRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GreyBrickRecipe).Name,
            Assembly = typeof(GreyBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Colored Bricks",
            LocalizableName = Localizer.DoStr("Colored Bricks"),
            IngredientList = new()
            {
                new EMIngredient("ClayItem", false, 1),
                new EMIngredient("MortarItem", false, 4),

            },
            ProductList = new()
            {
                new EMCraftable("GreyBrickItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 20,
            LaborIsStatic = false,
            BaseCraftTime = 0.5f,
            CraftTimeIsStatic = false,
            CraftingStation = "KilnItem",
            RequiredSkillType = typeof(PotterySkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(PotteryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static GreyBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GreyBrickRecipe()
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
    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class OrangeBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(OrangeBrickRecipe).Name,
            Assembly = typeof(OrangeBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Orange Bricks",
            LocalizableName = Localizer.DoStr("Orange Bricks"),
            IngredientList = new()
            {
                new EMIngredient("ClayItem", false, 1),
                new EMIngredient("MortarItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("OrangeBrickItem"),
            },
            CraftingStation = "KilnItem",
            IngredientImprovementTalents = typeof(PotteryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static OrangeBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public OrangeBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Purple
    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class PurpleBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PurpleBrickRecipe).Name,
            Assembly = typeof(PurpleBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Purple Bricks",
            LocalizableName = Localizer.DoStr("Purple Bricks"),
            IngredientList = new()
            {
                new EMIngredient("ClayItem", false, 1),
                new EMIngredient("MortarItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("PurpleBrickItem"),
            },
            CraftingStation = "KilnItem",
            IngredientImprovementTalents = typeof(PotteryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static PurpleBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PurpleBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Pink
    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class PinkBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PinkBrickRecipe).Name,
            Assembly = typeof(PinkBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Pink Bricks",
            LocalizableName = Localizer.DoStr("Pink Bricks"),
            IngredientList = new()
            {
                new EMIngredient("ClayItem", false, 1),
                new EMIngredient("MortarItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("PinkBrickItem"),
            },
            CraftingStation = "KilnItem",
            IngredientImprovementTalents = typeof(PotteryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static PinkBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PinkBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Red
    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class RedBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RedBrickRecipe).Name,
            Assembly = typeof(RedBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Red Bricks",
            LocalizableName = Localizer.DoStr("Red Bricks"),
            IngredientList = new()
            {
                new EMIngredient("ClayItem", false, 1),
                new EMIngredient("MortarItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("RedBrickItem"),
            },
            CraftingStation = "KilnItem",
            IngredientImprovementTalents = typeof(PotteryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static RedBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RedBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region White
    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class WhiteBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WhiteBrickRecipe).Name,
            Assembly = typeof(WhiteBrickRecipe).AssemblyQualifiedName,
            HiddenName = "White Bricks",
            LocalizableName = Localizer.DoStr("White Bricks"),
            IngredientList = new()
            {
                new EMIngredient("ClayItem", false, 1),
                new EMIngredient("MortarItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("WhiteBrickItem"),
            },
            CraftingStation = "KilnItem",
            IngredientImprovementTalents = typeof(PotteryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static WhiteBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WhiteBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Yellow
    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class YellowBrickRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(YellowBrickRecipe).Name,
            Assembly = typeof(YellowBrickRecipe).AssemblyQualifiedName,
            HiddenName = "Yellow Bricks",
            LocalizableName = Localizer.DoStr("Yellow Bricks"),
            IngredientList = new()
            {
                new EMIngredient("ClayItem", false, 1),
                new EMIngredient("MortarItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("YellowBrickItem"),
            },
            CraftingStation = "KilnItem",
            IngredientImprovementTalents = typeof(PotteryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PotteryParallelSpeedTalent), typeof(PotteryFocusedSpeedTalent) },
        };

        static YellowBrickRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public YellowBrickRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyBrickRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
}
