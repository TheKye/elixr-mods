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
    [LocDisplayName("Chicken Feed")]
    [Tag("Feed")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class ChickenFeedItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("Chicken Feed, used to feed your chickens, Not for you");
    }

    [RequiresSkill(typeof(FarmingSkill), 1)]
    public partial class ChickenFeedRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType                      = typeof(ChickenFeedRecipe).Name,
            Assembly                       = typeof(ChickenFeedRecipe).AssemblyQualifiedName,
            HiddenName                     = "Chicken Feed",
            LocalizableName                = Localizer.DoStr("Chicken Feed"),
            IngredientList                 = new()
            {
                new EMIngredient(item: "Vegetable", true, 5),
                new EMIngredient(item: "PlantFibersItem", isTag: false, amount: 20, isStatic: false),
            },
            ProductList                    = new()
            {
                new EMCraftable("ChickenFeedItem"),
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

        static ChickenFeedRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ChickenFeedRecipe()
        {
            this.Recipes                   = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories           = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes              = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft         = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
