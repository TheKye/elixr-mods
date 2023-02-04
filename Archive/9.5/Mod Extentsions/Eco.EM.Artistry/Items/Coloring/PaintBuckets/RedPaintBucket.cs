using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;

namespace Eco.EM.Artistry
{
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Red Paint Bucket")]
    public partial class RedPaintBucketItem : DurabilityItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Red Paint Used for Painting Surfaces.");
        public new float DurabilityMax => 100;
        public override IDynamicValue SkilledRepairCost => new ConstantValue(0);
    }

    [RequiresSkill(typeof(PaintingSkill), 4)]
    public partial class RedPaintBucketRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RedPaintBucketRecipe).Name,
            Assembly = typeof(RedPaintBucketRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bucket - Red",
            LocalizableName = Localizer.DoStr("Paint Bucket - Red"),
            IngredientList = new()
            {
                new EMIngredient("RedPaintItem", false, 2, true),
                new EMIngredient("PaintBaseItem", false, 2, true),
                new EMIngredient("EmptyPaintBucketItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("RedPaintBucketItem", 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "DyeTableItem",
            RequiredSkillType = typeof(PaintingSkill),
            RequiredSkillLevel = 4,
            IngredientImprovementTalents = typeof(PaintingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent) },
        };

        static RedPaintBucketRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RedPaintBucketRecipe()
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
