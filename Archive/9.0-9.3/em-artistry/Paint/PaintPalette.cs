using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Artistry
{
    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class PaintPaletteRecipe : RecipeFamily
    {
        private string rName = "Paint Palette";
        private Type skillBase = typeof(PaintingSkill);
        private Type ingTalent = typeof(PaintingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) };

        public PaintPaletteRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(OilItem), 2, skillBase, ingTalent),
                    new IngredientElement("WoodBoard", 5, skillBase, ingTalent)
                },
                 new CraftingElement<PaintPaletteItem>(2)
            );
            this.ExperienceOnCraft = 2;
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(50f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ArtStationObject), this);      
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Weight(100)]
    [MaxStackSize(10)]
    [LocDisplayName("Paint Pallette")]
    public partial class PaintPaletteItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Can be used in simple art."); } }
    }
}
