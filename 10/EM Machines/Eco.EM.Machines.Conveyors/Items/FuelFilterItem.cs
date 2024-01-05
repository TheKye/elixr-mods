using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System.Collections.Generic;

namespace Eco.EM.Machines.Conveyors
{
    [Serialized]
    [Weight(50)]
    [LocDisplayName("Fuel Items Filter")]
    [MaxStackSize(100)]
    [FilterModule]
    public partial class FuelFilterItem : FilterModuleItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Selects for all fuel items.");

        private static List<Item> filterList;
        public override List<Item> FilterList => filterList;

        public override void Init()
        {
            List<Item> returnList = new();
            foreach (Item i in AllItems)
            {
                if (i.IsFuel)
                    returnList.Add(i);
            }
            filterList = returnList;
        }
    }

    [RequiresSkill(typeof(ElectronicsSkill), 1)]
    public partial class FuelFilterRecipe : RecipeFamily
    {
        public FuelFilterRecipe()
        {
            var product = new Recipe(
                    "Fuels Filter",
                    Localizer.DoStr("Fuels Filter"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(CopperWiringItem), 2 ,typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                        new IngredientElement(typeof(GoldFlakesItem), 1 ,typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    },

                    new CraftingElement<FuelFilterItem>(1f)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, typeof(ElectronicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FuelFilterRecipe), 1f, typeof(ElectronicsSkill), typeof(ElectronicsParallelSpeedTalent), typeof(ElectronicsFocusedSpeedTalent));

            this.Initialize(Localizer.DoStr("Fuels Filter"), typeof(FuelFilterRecipe));
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }
}
