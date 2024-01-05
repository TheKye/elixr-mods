using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;
using Eco.Gameplay.Skills;
using System.Linq;

namespace Eco.EM.Machines.Trucking
{
    public class DetatchSemiTrailerRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(DetatchSemiTrailerRecipe).Name,
            Assembly = typeof(DetatchSemiTrailerRecipe).AssemblyQualifiedName,
            HiddenName = "Detatch Semi Trailer",
            LocalizableName = Localizer.DoStr("Detatch Semi Trailer"),
            IngredientList = new()
            {
                new EMIngredient("SemiTruckItem", false, 1, true),

            },
            ProductList = new()
            {
                new EMCraftable("SemiTrailerItem"),
                new EMCraftable("PrimeMoverItem"),
            },
            BaseExperienceOnCraft = 0f,
            BaseLabor = 0,
            LaborIsStatic = false,
            BaseCraftTime = 0,
            CraftTimeIsStatic = false,
            CraftingStation = "RoboticAssemblyLineItem",
        };

        static DetatchSemiTrailerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public DetatchSemiTrailerRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    public class DetatchBDoubleTrailerRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(DetatchBDoubleTrailerRecipe).Name,
            Assembly = typeof(DetatchBDoubleTrailerRecipe).AssemblyQualifiedName,
            HiddenName = "Detatch B-Double Trailer",
            LocalizableName = Localizer.DoStr("Detatch B-Double Trailer"),
            IngredientList = new()
            {
                new EMIngredient("BDoubleTruckItem", false, 1, true),

            },
            ProductList = new()
            {
                new EMCraftable("BDoubleTrailerItem"),
                new EMCraftable("PrimeMoverItem"),
            },
            BaseExperienceOnCraft = 0f,
            BaseLabor = 0,
            LaborIsStatic = false,
            BaseCraftTime = 0,
            CraftTimeIsStatic = false,
            CraftingStation = "RoboticAssemblyLineItem",
        };

        static DetatchBDoubleTrailerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public DetatchBDoubleTrailerRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(DetatchSemiTrailerRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    public class DetatchLoggingTrailerRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(DetatchLoggingTrailerRecipe).Name,
            Assembly = typeof(DetatchLoggingTrailerRecipe).AssemblyQualifiedName,
            HiddenName = "Detatch Logging Trailer",
            LocalizableName = Localizer.DoStr("Detatch Logging Trailer"),
            IngredientList = new()
            {
                new EMIngredient("SemiTruckLoggingItem", false, 1, true),

            },
            ProductList = new()
            {
                new EMCraftable("LoggingTrailerItem"),
                new EMCraftable("PrimeMoverItem"),
            },
            BaseExperienceOnCraft = 0f,
            BaseLabor = 0,
            LaborIsStatic = false,
            BaseCraftTime = 0,
            CraftTimeIsStatic = false,
            CraftingStation = "RoboticAssemblyLineItem",
        };

        static DetatchLoggingTrailerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public DetatchLoggingTrailerRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(DetatchSemiTrailerRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    public class DetatchMiningTrailerRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(DetatchMiningTrailerRecipe).Name,
            Assembly = typeof(DetatchMiningTrailerRecipe).AssemblyQualifiedName,
            HiddenName = "Detatch Mining Trailer",
            LocalizableName = Localizer.DoStr("Detatch Mining Trailer"),
            IngredientList = new()
            {
                new EMIngredient("SemiTruckMiningItem", false, 1, true),

            },
            ProductList = new()
            {
                new EMCraftable("MiningTrailerItem"),
                new EMCraftable("PrimeMoverItem"),
            },
            BaseExperienceOnCraft = 0f,
            BaseLabor = 0,
            LaborIsStatic = false,
            BaseCraftTime = 0,
            CraftTimeIsStatic = false,
            CraftingStation = "RoboticAssemblyLineItem",
        };

        static DetatchMiningTrailerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public DetatchMiningTrailerRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(DetatchSemiTrailerRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    public class DetatchPlantTrailerRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(DetatchPlantTrailerRecipe).Name,
            Assembly = typeof(DetatchPlantTrailerRecipe).AssemblyQualifiedName,
            HiddenName = "Detatch Plant Trailer",
            LocalizableName = Localizer.DoStr("Detatch Plant Trailer"),
            IngredientList = new()
            {
                new EMIngredient("SemiTruckPlantItem", false, 1, true),

            },
            ProductList = new()
            {
                new EMCraftable("PlantTrailerItem"),
                new EMCraftable("PrimeMoverItem"),
            },
            BaseExperienceOnCraft = 0f,
            BaseLabor = 0,
            LaborIsStatic = false,
            BaseCraftTime = 0,
            CraftTimeIsStatic = false,
            CraftingStation = "RoboticAssemblyLineItem",
        };

        static DetatchPlantTrailerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public DetatchPlantTrailerRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(DetatchSemiTrailerRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}
