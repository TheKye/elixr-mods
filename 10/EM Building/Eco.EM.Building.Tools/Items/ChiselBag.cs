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
    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Chisel Bag")]
    [Currency, Tag("Currency")]
    [Ecopedia("Items", "Products", createAsSubPage: true)]
    public partial class ChiselBagItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("A bag to keep your chiseled bits in, Combine with the Chisel to improve the Chisels Storage capacity.");
        static ChiselBagItem() { }
    }

    // Skill requirements
    [RequiresSkill(typeof(TailoringSkill), 3)]
    public partial class ChiselBagRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ChiselBagRecipe).Name,
            Assembly = typeof(ChiselBagRecipe).AssemblyQualifiedName,
            HiddenName = "Chisel Bag",
            LocalizableName = Localizer.DoStr("Chisel Bag"),
            IngredientList = new()
            {
                new EMIngredient(item: "Fabric", isTag: true, amount: 30, isStatic: false),
            },
            ProductList = new()
            {
                new EMCraftable(item: "ChiselBagItem", amount: 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 350,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "TailoringTableItem",
            RequiredSkillType = typeof(TailoringSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(TailoringLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent) },
        };

        static ChiselBagRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ChiselBagRecipe()
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
