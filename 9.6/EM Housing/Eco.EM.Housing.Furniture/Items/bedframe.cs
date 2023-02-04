using System;
using System.Collections.Generic;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Housing.Furniture
{
    [Serialized, LocDisplayName("Bed Frame")]
    [MaxStackSize(100)]
    public partial class BedFrameItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Bed Frame For The Kings Bed");
    }

    [RequiresSkill(typeof(CarpentrySkill), 4)]
    public partial class BedFrameRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BedFrameRecipe).Name,
            Assembly = typeof(BedFrameRecipe).AssemblyQualifiedName,
            HiddenName = "Bed Frame",
            LocalizableName = Localizer.DoStr("Bed Frame"),
            IngredientList = new()
            {
                new EMIngredient("Lumber", true, 25),
                new EMIngredient("RivetItem", false, 50)
            },
            ProductList = new()
            {
                new EMCraftable("BedFrameItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "SawmillItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 4,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static BedFrameRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BedFrameRecipe()
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