using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Furniture
{
    [Serialized, LocDisplayName("Bed Frame")]
    [MaxStackSize(100)]
    public partial class BedFrameItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Bed Frame For The Kings Bed");
    }

    [RequiresSkill(typeof(CarpentrySkill), 4)]
    public partial class BedFrameRecipe : RecipeFamily
    {
        public BedFrameRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Bed Frame",
                    Localizer.DoStr("Bed Frame"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Lumber", 25, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                        new IngredientElement(typeof(RivetItem), 50,typeof(CarpentrySkill),typeof(CarpentryLavishResourcesTalent))
                    },
                    new CraftingElement<BedFrameItem>()
                    )
                };
            this.ExperienceOnCraft = 15;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BedFrameRecipe), 10, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Bed Frame"), typeof(BedFrameRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}