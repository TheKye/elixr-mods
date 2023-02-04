using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Artistry
{
    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class EmptyCanvasRecipe : RecipeFamily
    {
        private string rName = "Empty Canvas";
        private Type skillBase = typeof(PaintingSkill);
        private Type ingTalent = typeof(PaintingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) };

        public EmptyCanvasRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("WoodBoard", 4, skillBase, ingTalent),
                    new IngredientElement(typeof(ClothItem), 6, skillBase, ingTalent),
                },
                 new CraftingElement<EmptyCanvasItem>(1f)
            );
            this.ExperienceOnCraft = 1;
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(200f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 2f, skillBase, speedTalents);
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

    [Serialized, Weight(500), MaxStackSize(10), LocDisplayName("Empty Canvas")]
    public partial class EmptyCanvasItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Can be used in simple art."); } }
    }
}
