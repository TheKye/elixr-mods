using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Gameplay.Components;
using Eco.Gameplay.Skills;
using System.Collections.Generic;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Artistry
{
    [Serialized]
    [Weight(5000)]
    [MaxStackSize(10)]
    [LocDisplayName("A Bucket Of Water")]
    public partial class BucketOfWaterItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Bucket of water");
    }

    public partial class BucketOfWater1Recipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BucketOfWater1Recipe).Name,
            Assembly = typeof(BucketOfWater1Recipe).AssemblyQualifiedName,
            HiddenName = "Bucket Of Water",
            LocalizableName = Localizer.DoStr("Bucket Of Water"),
            IngredientList = new()
            {
                new EMIngredient("BucketItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("BucketOfWaterItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = true,
            BaseCraftTime = .5f,
            CraftTimeIsStatic = true,
            CraftingStation = "HandWaterPumpItem",
        };

        static BucketOfWater1Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BucketOfWater1Recipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    public partial class BucketOfWater2Recipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BucketOfWater2Recipe).Name,
            Assembly = typeof(BucketOfWater2Recipe).AssemblyQualifiedName,
            HiddenName = "Bucket Of Water",
            LocalizableName = Localizer.DoStr("Bucket Of Water"),
            IngredientList = new()
            {
                new EMIngredient("BucketItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("BucketOfWaterItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = true,
            BaseCraftTime = 0.05f,
            CraftTimeIsStatic = true,
            CraftingStation = "BlastFurnaceItem",
        };

        static BucketOfWater2Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BucketOfWater2Recipe()
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