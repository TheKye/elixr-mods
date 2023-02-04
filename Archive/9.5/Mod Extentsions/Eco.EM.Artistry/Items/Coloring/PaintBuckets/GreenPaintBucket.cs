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
    [LocDisplayName("Green Paint Bucket")]
    public partial class GreenPaintBucketItem : DurabilityItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Green Paint Used for Painting Surfaces.");
        public new float DurabilityMax => 100;
        public override IDynamicValue SkilledRepairCost => new ConstantValue(0);
    }

    [RequiresSkill(typeof(PaintingSkill), 4)]
    public partial class GreenPaintBucketRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GreenPaintBucketRecipe).Name,
            Assembly = typeof(GreenPaintBucketRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bucket - Green",
            LocalizableName = Localizer.DoStr("Paint Bucket - Green"),
            IngredientList = new()
            {
                new EMIngredient("GreenPaintItem", false, 2, true),
                new EMIngredient("PaintBaseItem", false, 2, true),
                new EMIngredient("EmptyPaintBucketItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("GreenPaintBucketItem", 1),
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

        static GreenPaintBucketRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GreenPaintBucketRecipe()
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
