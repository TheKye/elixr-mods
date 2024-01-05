using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Farming
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Bird Feed")]
    [Tag("Feed")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class BirdFeedItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("Bird Feed, used to feed your chickens, Not for you");
    }

    [RequiresSkill(typeof(FarmingSkill), 1)]
    public partial class BirdFeedRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType                      = typeof(BirdFeedRecipe).Name,
            Assembly                       = typeof(BirdFeedRecipe).AssemblyQualifiedName,
            HiddenName                     = "Bird Feed",
            LocalizableName                = Localizer.DoStr("Bird Feed"),
            IngredientList                 = new()
            {
                new EMIngredient(item: "Vegetable", true, 5),
                new EMIngredient(item: "PlantFibersItem", isTag: false, amount: 20, isStatic: false),
            },
            ProductList                    = new()
            {
                new EMCraftable("BirdFeedItem"),
            },
            BaseExperienceOnCraft          = 1,
            BaseLabor                      = 20,
            LaborIsStatic                  = false,
            BaseCraftTime                  = 3,
            CraftTimeIsStatic              = false,
            CraftingStation                = "FarmersTableItem",
            RequiredSkillType              = typeof(FarmingSkill),
            RequiredSkillLevel             = 1,
            IngredientImprovementTalents   = typeof(FarmingLavishResourcesTalent),
            SpeedImprovementTalents        = new Type[] { typeof(FarmingFocusedSpeedTalent), typeof(FarmingParallelSpeedTalent) },
        };

        static BirdFeedRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BirdFeedRecipe()
        {
            this.Recipes                   = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories           = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes              = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft         = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
