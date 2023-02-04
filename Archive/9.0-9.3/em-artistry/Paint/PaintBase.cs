using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;

namespace Eco.EM.Artistry
{
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Paint Base")]
    public partial class PaintBaseItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("This is the base used to make paint from dyes"); } }

        static PaintBaseItem()
        {

        }
    }

    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class PaintBaseRecipe : RecipeFamily
    {
        public PaintBaseRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Base",
                    Localizer.DoStr("Paint Base"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(CerealGermItem), 10),
                new IngredientElement(typeof(BucketOfWaterItem), 1, true),
                    },
                 new CraftingElement<PaintBaseItem>(4),
                 new CraftingElement<BucketItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(CookingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(PaintBaseRecipe), 2, typeof(CookingSkill), typeof(CookingFocusedSpeedTalent), typeof(CookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Paint Base"), typeof(PaintBaseRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
