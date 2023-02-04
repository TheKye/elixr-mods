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
    [Tag("Fuel")][Fuel(2000)]
    [Tag("Burnable Fuel", 1)]
    [Currency][Tag("Currency")]
    [Ecopedia("Items", "Products", createAsSubPage: true)]
    [LocDisplayName("Kindle")]
    public partial class KindleItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Bunch of sticks made from breaking down logs, burns really quickly");
    }

    [RequiresSkill(typeof(LoggingSkill), 1)]
    public partial class KindleRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(KindleRecipe).Name,
            Assembly = typeof(KindleRecipe).AssemblyQualifiedName,
            HiddenName = "Kindle",
            LocalizableName = Localizer.DoStr("Kindle"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 2, true),
            },
            ProductList = new()
            {
                new EMCraftable("KindleItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "WorkbenchItem",
            RequiredSkillType = typeof(LoggingSkill),
            RequiredSkillLevel = 1,
        };

        static KindleRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public KindleRecipe()
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
