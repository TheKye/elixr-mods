using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.EM.Artistry;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Housing.Paintings
{
    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class EmptyCanvasRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(EmptyCanvasRecipe).Name,
            Assembly = typeof(EmptyCanvasRecipe).AssemblyQualifiedName,
            HiddenName = "Empty Canvas",
            LocalizableName = Localizer.DoStr("Empty Canvas"),
            IngredientList = new()
            {
                new EMIngredient("WoodBoard", true, 4),
                new EMIngredient("ClothItem", false, 6),
            },
            ProductList = new()
            {
                new EMCraftable("EmptyCanvasItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 200,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "ArtStationItem",
            RequiredSkillType = typeof(PaintingSkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(PaintingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) },
        };

        static EmptyCanvasRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public EmptyCanvasRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [Serialized, Weight(500), MaxStackSize(10), LocDisplayName("Empty Canvas")]
    public partial class EmptyCanvasItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("Can be used in simple art.");
    }
}
