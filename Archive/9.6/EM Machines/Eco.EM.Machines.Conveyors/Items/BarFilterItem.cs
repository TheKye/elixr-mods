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
    [LocDisplayName("Bar Filter")]
    [MaxStackSize(100)]
    [FilterModule]
    public partial class BarFilterItem : FilterModuleItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Selects for all metal ingots.");

        private static List<Item> filterList;
        public override List<Item> FilterList => filterList;

        public override void Init()
        {
            List<Item> returnList = new()
            {
                Get("IronBarItem"),
                Get("CopperBarItem"),
                Get("GoldBarItem"),
                Get("SteelBarItem"),
            };
            filterList = returnList;
        }
    }

    [RequiresSkill(typeof(ElectronicsSkill), 1)]
    public partial class BarFilterRecipe : RecipeFamily
    {
        public BarFilterRecipe()
        {
            var product = new Recipe(
               "Bar Filter",
               Localizer.DoStr("Bar Filter"),
               new IngredientElement[]
               {
                    new IngredientElement(typeof(CopperWiringItem), 2 ,typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(GoldFlakesItem), 1 ,typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
               },

               new CraftingElement<BarFilterItem>(1f)
           );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, typeof(ElectronicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BarFilterRecipe), 1f, typeof(ElectronicsSkill), typeof(ElectronicsParallelSpeedTalent), typeof(ElectronicsFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Bar Filter"), typeof(BarFilterRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
