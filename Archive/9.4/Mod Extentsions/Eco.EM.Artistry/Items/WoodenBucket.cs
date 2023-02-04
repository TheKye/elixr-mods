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
    [Serialized, Weight(1000), MaxStackSize(10), LocDisplayName("Wooden Bucket")]
    public partial class BucketItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("A bucket for holding liquids in.");
    }

    [RequiresSkill(typeof(LoggingSkill), 0)]
    public partial class BucketRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BucketRecipe).Name,
            Assembly = typeof(BucketRecipe).AssemblyQualifiedName,
            HiddenName = "Wooden Bucket",
            LocalizableName = Localizer.DoStr("Wooden Bucket"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 8),
            },
            ProductList = new()
            {
                new EMCraftable("BucketItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 0.5f,
            CraftTimeIsStatic = false,
            CraftingStation = "CarpentryTableItem",
            RequiredSkillType = typeof(LoggingSkill),
            RequiredSkillLevel = 0,
        };

        static BucketRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BucketRecipe()
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
