using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Artistry
{
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Orange Dye")]
    public partial class OrangeDyeItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("Orange Dye Used for Dying Certain Items.");
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class OrangeDyeRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(OrangeDyeRecipe).Name,
            Assembly = typeof(OrangeDyeRecipe).AssemblyQualifiedName,
            HiddenName = "Dye Mix - Orange",
            LocalizableName = Localizer.DoStr("Dye Mix - Orange"),
            IngredientList = new()
            {
                new EMIngredient("RedDyeItem", false, 1, true),
                new EMIngredient("YellowDyeItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("OrangeDyeItem", 2),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "DyeTableItem",
            RequiredSkillType = typeof(PaintingSkill),
            RequiredSkillLevel = 2,
            SpeedImprovementTalents = new Type[] { typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent) },
        };

        static OrangeDyeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public OrangeDyeRecipe()
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
