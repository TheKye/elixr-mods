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
    [LocDisplayName("Carried Items Filter")]
    [MaxStackSize(100)]
    [FilterModule]
    public partial class CarriedFilterItem : FilterModuleItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Selects for all carried items.");

        private static List<Item> filterList;
        public override List<Item> FilterList => filterList;

        public override void Init()
        {
            List<Item> returnList = new();
            foreach (Item i in AllItems)
            {
                if (i.IsCarried)
                    returnList.Add(i);
            }
            filterList = returnList;
        }

        static CarriedFilterItem() { }
    }

    [RequiresSkill(typeof(ElectronicsSkill), 1)]
    public partial class CarriedFilterRecipe : RecipeFamily
    {
        public CarriedFilterRecipe()
        {
            var product = new Recipe(
                    "Carried Filter",
                    Localizer.DoStr("Carried Filter"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(CopperWiringItem), 2 ,typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                        new IngredientElement(typeof(GoldFlakesItem), 1 ,typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    },

                    new CraftingElement<CarriedFilterItem>(1f)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, typeof(ElectronicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CarriedFilterRecipe), 1f, typeof(ElectronicsSkill), typeof(ElectronicsParallelSpeedTalent), typeof(ElectronicsFocusedSpeedTalent));

            this.Initialize(Localizer.DoStr("Carried Filter"), typeof(CarriedFilterRecipe));
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }
}
