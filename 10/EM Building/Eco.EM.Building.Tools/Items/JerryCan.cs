using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;

namespace Eco.EM.Building.Tools
{
    [Serialized]
    [LocDisplayName("Empty Jerry Can")]
    [Weight(500)]
    [Ecopedia("Items", "Products", createAsSubPage: true)]
    public partial class EmptyJerryCanItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("An Empty Jerry-can, Can store Gasoline in it, holds roughly 10 Liters");
    }

    [RequiresSkill(typeof(OilDrillingSkill), 1)]
    public partial class EmptyJerryCanRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(EmptyJerryCanRecipe).Name,
            Assembly = typeof(EmptyJerryCanRecipe).AssemblyQualifiedName,
            HiddenName = "JerryCan",
            LocalizableName = Localizer.DoStr("Jerry Can"),
            IngredientList = new()
            {
                new EMIngredient("EpoxyItem", false, 1, true),
                new EMIngredient("PlasticItem", false, 6)
            },
            ProductList = new()
            {
                new EMCraftable("EmptyJerryCanItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 500,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "AssemblyLineItem",
            RequiredSkillType = typeof(OilDrillingSkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(OilDrillingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(OilDrillingFocusedSpeedTalent), typeof(OilDrillingParallelSpeedTalent) },
        };

        static EmptyJerryCanRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public EmptyJerryCanRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
