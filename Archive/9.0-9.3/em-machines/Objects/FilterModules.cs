using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace Eco.EM.Industry
{
    public class ItemFilterManager : IModKitPlugin, IInitializablePlugin
    {
        public string GetStatus()
        {
            return "Filtering";
        }

        public void Initialize(TimedTask timer)
        {
            var filters = Item.AllItems.OfType<FilterModuleItem>();
            foreach (var filter in filters)
            {
                filter.Init();
            }
        }
    }

    public class FilterModuleAttribute : ItemAttribute { }

    [Serialized]
    public abstract class FilterModuleItem : Item
    {
        public abstract List<Item> FilterList { get; }
        public abstract void Init();
    }

    [Serialized]
    [Weight(50)]
    [LocDisplayName("All Items Filter")]
    [MaxStackSize(100)]
    [FilterModule]
    public partial class AllFilterItem : FilterModuleItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Makes an inserter move all items from the extraction inventory."); } }

        private List<Item> filterList;
        public override List<Item> FilterList { get { return filterList; } }

        public override void Init()
        {
            List<Item> returnList = new List<Item>();
            foreach (var i in AllItems)
            {
                returnList.Add(i);
            }
            filterList = returnList;
        }
    }

    [RequiresSkill(typeof(ElectronicsSkill), 1)]
    public partial class AllFilterRecipe : RecipeFamily
    {
        public AllFilterRecipe()
        {
            var product = new Recipe(
                    "All Filter",
                    Localizer.DoStr("All Filter"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(CopperWiringItem), 2 ,typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                        new IngredientElement(typeof(GoldFlakesItem), 1 ,typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    },

                    new CraftingElement<AllFilterItem>(1f)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, typeof(ElectronicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AllFilterRecipe), 1f, typeof(ElectronicsSkill), typeof(ElectronicsParallelSpeedTalent), typeof(ElectronicsFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("All Filter"), typeof(AllFilterRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Weight(50)]
    [LocDisplayName("Carried Items Filter")]
    [MaxStackSize(100)]
    [FilterModule]
    public partial class CarriedFilterItem : FilterModuleItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Selects for all carried items."); } }

        private static List<Item> filterList;
        public override List<Item> FilterList { get { return filterList; } }

        public override void Init()
        {
            List<Item> returnList = new List<Item>();
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

    [Serialized]
    [Weight(50)]
    [LocDisplayName("Fuel Items Filter")]
    [MaxStackSize(100)]
    [FilterModule]
    public partial class FuelFilterItem : FilterModuleItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Selects for all fuel items."); } }

        private static List<Item> filterList;
        public override List<Item> FilterList { get { return filterList; } }

        public override void Init()
        {
            List<Item> returnList = new List<Item>();
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

    [Serialized]
    [Weight(50)]
    [LocDisplayName("Food Items Filter")]
    [MaxStackSize(100)]
    [FilterModule]
    public partial class FoodFilterItem : FilterModuleItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Selects for all food items."); } }

        private static List<Item> filterList;
        public override List<Item> FilterList { get { return filterList; } }

        public override void Init()
        {
            List<Item> returnList = new List<Item>();
            foreach (Item i in AllItems)
            {
                if (i.Group == "Food")
                    returnList.Add(i);
            }
            filterList = returnList;
        }
    }

    [RequiresSkill(typeof(ElectronicsSkill), 1)]
    public partial class FoodFilterRecipe : RecipeFamily
    {
        public FoodFilterRecipe()
        {
            var product = new Recipe(
                "Food Filter",
                Localizer.DoStr("Food Filter"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CopperWiringItem), 2 ,typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(GoldFlakesItem), 1 ,typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                },

                new CraftingElement<FoodFilterItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, typeof(ElectronicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FoodFilterRecipe), 1f, typeof(ElectronicsSkill), typeof(ElectronicsParallelSpeedTalent), typeof(ElectronicsFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Food Filter"), typeof(FoodFilterRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Weight(50)]
    [LocDisplayName("Tool Items Filter")]
    [MaxStackSize(100)]
    [FilterModule]
    public partial class ToolFilterItem : FilterModuleItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Selects for all tool items."); } }

        private static List<Item> filterList;
        public override List<Item> FilterList { get { return filterList; } }

        public override void Init()
        {      
            List<Item> returnList = new List<Item>();
            foreach (Item i in AllItems)
            {
                if (i.IsTool)
                    returnList.Add(i);
            }
            filterList = returnList;
        }
    }

    [RequiresSkill(typeof(ElectronicsSkill), 1)]
    public partial class ToolFilterRecipe : RecipeFamily
    {
        public ToolFilterRecipe()
        {
            var product = new Recipe(
                "Tool Filter",
                Localizer.DoStr("Tool Filter"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CopperWiringItem), 2 ,typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(GoldFlakesItem), 1 ,typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                },

                new CraftingElement<ToolFilterItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, typeof(ElectronicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ToolFilterRecipe), 1f, typeof(ElectronicsSkill), typeof(ElectronicsParallelSpeedTalent), typeof(ElectronicsFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Tool Filter"), typeof(ToolFilterRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Weight(50)]
    [LocDisplayName("Bar Filter")]
    [MaxStackSize(100)]
    [FilterModule]
    public partial class BarFilterItem : FilterModuleItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Selects for all metal ingots."); } }

        private static List<Item> filterList;
        public override List<Item> FilterList { get { return filterList; } }

        public override void Init()
        {
            List<Item> returnList = new List<Item>()
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
