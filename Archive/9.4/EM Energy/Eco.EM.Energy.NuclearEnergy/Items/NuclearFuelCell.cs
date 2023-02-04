using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Core.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;

namespace Eco.EM.Energy.NuclearEnergy
{
    [RequiresModule(typeof(ComputerLabObject))]
    [RequiresSkill(typeof(NuclearTechnitionSkill), 1)]
    public partial class NuclearFuelCellRecipe : RecipeFamily
    {
        public NuclearFuelCellRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Nuclear Fuel Cell",
                    Localizer.DoStr("Nuclear Fuel Cell"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(CopperBarItem), 100, typeof(NuclearTechnitionSkill)),
                    new IngredientElement(typeof(TailingsItem), 100, typeof(NuclearTechnitionSkill)),
                    new IngredientElement(typeof(BarrelItem), 1, typeof(NuclearTechnitionSkill)),
                    new IngredientElement(typeof(CopperOreItem), 500, typeof(NuclearTechnitionSkill)),
                    },
                    new CraftingElement<NuclearFuelCellItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(NuclearTechnitionSkill));
            this.ExperienceOnCraft = 20f;
            this.CraftMinutes = CreateCraftTimeValue(typeof(NuclearFuelCellRecipe), 0.8f, typeof(NuclearTechnitionSkill));
            this.Initialize(Localizer.DoStr("Nuclear Fuel Cell"), typeof(NuclearFuelCellRecipe));

            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Nuclear Fuel Cell")]
    [MaxStackSize(10)]
    [Weight(30000)]
    [Fuel(100000000)]
    [Tag("Fuel")]
    [Ecopedia("Blocks", "Liquids", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Nuclear Fuel Cell", 1)]
    public partial class NuclearFuelCellItem : Item
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Nuclear Fuel Cells");
        public override LocString DisplayDescription => Localizer.DoStr("Nuclear fuel cells conatain large amounts of energy. They can release this energy over a large period of time in a nuclear reactor");
    }
}
