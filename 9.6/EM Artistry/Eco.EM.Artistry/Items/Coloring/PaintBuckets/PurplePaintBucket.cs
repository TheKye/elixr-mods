using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using Eco.EM.Framework.Extentsions.Items;

namespace Eco.EM.Artistry
{
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Purple Paint Bucket")]
    public partial class PurplePaintBucketItem : RepairableItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Purple Paint Used for Painting Surfaces.");
        public override IDynamicValue SkilledRepairCost => new ConstantValue(0);
    }

    [RequiresSkill(typeof(PaintingSkill), 4)]
    public partial class PurplePaintBucketRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PurplePaintBucketRecipe).Name,
            Assembly = typeof(PurplePaintBucketRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bucket - Purple",
            LocalizableName = Localizer.DoStr("Paint Bucket - Purple"),
            IngredientList = new()
            {
                new EMIngredient("PurplePaintItem", false, 2, true),
                new EMIngredient("PaintBaseItem", false, 2, true),
                new EMIngredient("EmptyPaintBucketItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("PurplePaintBucketItem", 1),
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

        static PurplePaintBucketRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PurplePaintBucketRecipe()
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
