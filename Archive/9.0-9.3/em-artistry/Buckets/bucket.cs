using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Gameplay.Components;
using Eco.Gameplay.Skills;
using System.Collections.Generic;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [Weight(5000)]
    [MaxStackSize(10)]
    [LocDisplayName("A Bucket Of Water")]
    public partial class BucketOfWaterItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Bucket of water"); } }
    }

    public partial class BucketOfWater1Recipe : RecipeFamily
    {
        public BucketOfWater1Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Bucket of Water",
                    Localizer.DoStr("Bucket of Water"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(BucketItem), 1, true),
                    },
                    new CraftingElement<BucketOfWaterItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BucketOfWater1Recipe), 0.5f, typeof(LoggingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Bucket of Water"), typeof(BucketOfWater1Recipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(HandWaterPumpObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class BucketOfWater2Recipe : RecipeFamily
    {
        public BucketOfWater2Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Bucket of Water",
                    Localizer.DoStr("Bucket of Water"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(BucketItem), 1, true),
                    },
                    new CraftingElement<BucketOfWaterItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BucketOfWater2Recipe), 0.05f, typeof(SmeltingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Bucket of Water"), typeof(BucketOfWater2Recipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized, Weight(1000), MaxStackSize(10), LocDisplayName("Wooden Bucket")]
    public partial class BucketItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A bucket for holding liquids in."); } }
    }

    [RequiresSkill(typeof(LoggingSkill), 0)]
    public partial class BucketRecipe : RecipeFamily
    {
        public BucketRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Wooden Bucket",
                    Localizer.DoStr("Wooden Bucket"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Wood", 8, typeof(LoggingSkill)),
                    },
                new CraftingElement<BucketItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BucketRecipe), 0.5f, typeof(LoggingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Wooden Bucket"), typeof(BucketRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
