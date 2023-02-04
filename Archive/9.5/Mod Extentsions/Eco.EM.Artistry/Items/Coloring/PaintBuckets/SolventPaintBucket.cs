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
    [LocDisplayName("Solvent Paint Bucket")]
    public partial class SolventPaintBucketItem : DurabilityItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Solvent used for cleaning off paint");
        public override IDynamicValue SkilledRepairCost => new ConstantValue(0);
    }

    [RequiresSkill(typeof(PaintingSkill), 4)]
    public partial class SolventPaintBucketRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SolventPaintBucketRecipe).Name,
            Assembly = typeof(SolventPaintBucketRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Bucket - Solvent",
            LocalizableName = Localizer.DoStr("Paint Bucket - Solvent"),
            IngredientList = new()
            {
                new EMIngredient("PaintBaseItem", false, 2, true),
                new EMIngredient("EmptyPaintBucketItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("SolventPaintBucketItem", 1)
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

        static SolventPaintBucketRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SolventPaintBucketRecipe()
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
