using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;

namespace Eco.EM.Artistry
{
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Empty Paint Bucket")]
    public partial class EmptyPaintBucketItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("An Empty Paint Bucket. Can be used to store paint!");

    }

    [RequiresSkill(typeof(SmeltingSkill), 4)]
    public partial class EmptyPaintBucketRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(EmptyPaintBucketRecipe).Name,
            Assembly = typeof(EmptyPaintBucketRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bucket - Empty",
            LocalizableName = Localizer.DoStr("Paint Bucket - Empty"),
            IngredientList = new()
            {
                new EMIngredient("IronPlateItem", false, 2, true),
                new EMIngredient("IronBarItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("EmptyPaintBucketItem", 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "AnvilItem",
            RequiredSkillType = typeof(SmeltingSkill),
            RequiredSkillLevel = 4,
            IngredientImprovementTalents = typeof(SmeltingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent) },
        };

        static EmptyPaintBucketRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public EmptyPaintBucketRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Localizer.DoStr(Defaults.LocalizableName), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
