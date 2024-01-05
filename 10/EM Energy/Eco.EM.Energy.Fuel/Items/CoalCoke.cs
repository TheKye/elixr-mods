using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.World.Blocks;

namespace Eco.EM.Energy.Fuel
{
    [Serialized]
    [MaxStackSize(100)]
    [Weight(500)]
    [Tag("Fuel")][Fuel(50000)]
    [Tag("Coal", 1)]
    [Tag("Burnable Fuel", 1)]
    [Currency][Tag("Currency")]
    [Ecopedia("Items", "Products", createAsSubPage: true)]
    [LocDisplayName("Coal Coke")]
    public partial class CoalCokeItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Very Refined Version of Coal, Last much longer then regular coal does");
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class CoalCokeRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(CoalCokeRecipe).Name,
            Assembly = typeof(CoalCokeRecipe).AssemblyQualifiedName,
            HiddenName = "Coal Coke",
            LocalizableName = Localizer.DoStr("Coal Coke"),
            IngredientList = new()
            {
                new EMIngredient("CoalItem", false, 2, true),
            },
            ProductList = new()
            {
                new EMCraftable("CoalCokeItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "BlastFurnaceItem",
            RequiredSkillType = typeof(SmeltingSkill),
            RequiredSkillLevel = 1,
            SpeedImprovementTalents = new Type[] { typeof(SmeltingParallelSpeedTalent), typeof(SmeltingFocusedSpeedTalent) },
        };

        static CoalCokeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public CoalCokeRecipe()
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
