using System;
using System.Collections.Generic;
using System.Linq;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.World.Blocks;

namespace Eco.EM.Energy.Fuel
{
    [Serialized]
    [MaxStackSize(20)]
    [Weight(20000)]
    [Tag("Fuel")][Fuel(5000)]
    [Tag("Biomass", 1)]
    [Tag("Burnable Fuel", 1)]
    [Currency][Tag("Currency")]
    [Ecopedia("Items", "Products", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [LocDisplayName("Biomass")]
    public partial class BiomassItem : BlockItem<BiomassBlock>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Lump of different plants, burns pretty quickly.");

        private static Type[] blockTypes = new Type[] {
            typeof(BiomassStacked1Block),
            typeof(BiomassStacked2Block),
            typeof(BiomassStacked3Block),
            typeof(BiomassStacked4Block)
        };

        public override Type[] BlockTypes => blockTypes;
    }


    [Serialized, Solid] public class       BiomassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class       BiomassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class       BiomassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BiomassStacked4Block : PickupableBlock { }

    [Serialized]
    [Solid, Wall]
    [RequiresSkill(typeof(FarmingSkill), 1)]
    public partial class BiomassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType              => typeof(BiomassItem);
    }

    [RequiresSkill(typeof(FarmingSkill), 1)]
    public partial class BiomassRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BiomassRecipe).Name,
            Assembly = typeof(BiomassRecipe).AssemblyQualifiedName,
            HiddenName = "Biomass",
            LocalizableName = Localizer.DoStr("Biomass"),
            IngredientList = new()
            {
                new EMIngredient("NaturalFiber", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("BiomassItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "FarmersTableItem",
            RequiredSkillType = typeof(FarmingSkill),
            RequiredSkillLevel = 1,
        };

        static BiomassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BiomassRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    public partial class BiomassAltRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BiomassAltRecipe).Name,
            Assembly = typeof(BiomassAltRecipe).AssemblyQualifiedName,
            HiddenName = "Biomass - Crops",
            LocalizableName = Localizer.DoStr("Biomass - Crops"),
            IngredientList = new()
            {
                new EMIngredient("Crop", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("BiomassItem"),
            },
            CraftingStation = "FarmersTableItem",
        };

        static BiomassAltRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BiomassAltRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(BiomassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    public partial class BiomassAlt2Recipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BiomassAlt2Recipe).Name,
            Assembly = typeof(BiomassAlt2Recipe).AssemblyQualifiedName,
            HiddenName = "Biomass - Raw Food",
            LocalizableName = Localizer.DoStr("Biomass - Raw Food"),
            IngredientList = new()
            {
                new EMIngredient("Raw Food", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("BiomassItem"),
            },
            CraftingStation = "FarmersTableItem",
        };

        static BiomassAlt2Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BiomassAlt2Recipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(BiomassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    public partial class BiomassAlt3Recipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BiomassAlt3Recipe).Name,
            Assembly = typeof(BiomassAlt3Recipe).AssemblyQualifiedName,
            HiddenName = "Biomass - Crop Seed",
            LocalizableName = Localizer.DoStr("Biomass - Crop Seed"),
            IngredientList = new()
            {
                new EMIngredient("Crop Seed", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("BiomassItem"),
            },
            CraftingStation = "FarmersTableItem",
        };

        static BiomassAlt3Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BiomassAlt3Recipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(BiomassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}
