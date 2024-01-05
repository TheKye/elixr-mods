using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Artistry
{
    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class PaintPaletteRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintPaletteRecipe).Name,
            Assembly = typeof(PaintPaletteRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Palette",
            LocalizableName = Localizer.DoStr("Paint Palette"),
            IngredientList = new()
            {
                new EMIngredient("OilItem", false, 2),
                new EMIngredient("WoodBoard", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("PaintPaletteItem"),
            },
            BaseExperienceOnCraft = 2,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "ArtStationItem",
            RequiredSkillType = typeof(PaintingSkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(PaintingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PaintingLavishResourcesTalent) },
        };

        static PaintPaletteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintPaletteRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [Serialized]
    [Weight(100)]
    [MaxStackSize(10)]
    [LocDisplayName("Paint Palette")]
    public partial class PaintPaletteItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("Can be used in simple art.");
    }
}
