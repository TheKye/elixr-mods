using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.Mods.TechTree
{
    public partial class RecyclePrimitiveHandleRecipe : RecipeFamily
    {
        public RecyclePrimitiveHandleRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Recycle Primitive Handle",
                    Localizer.DoStr("Recycle Primitive Handle"),
                        new IngredientElement[]
                    {
                    new IngredientElement(typeof(PrimitiveWoodHandleItem), 1, true)
                    },
                        new CraftingElement<WoodPulpItem>(5)
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(0);
            this.CraftMinutes = CreateCraftTimeValue(0.01f);
            Initialize(Localizer.DoStr("Recycle Primitive Handle"), typeof(PrimitiveWoodHandleRecipe));

            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }

    }
    public partial class RecycleBasicHandleRecipe : RecipeFamily
    {
        public RecycleBasicHandleRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Recycle Basic Handle",
                    Localizer.DoStr("Recycle Basic Handle"),
                        new IngredientElement[]
                    {
                    new IngredientElement(typeof(BasicWoodHandleItem), 1, true)
                    },
                        new CraftingElement<WoodPulpItem>(15)
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(0);
            this.CraftMinutes = CreateCraftTimeValue(0.01f);
            Initialize(Localizer.DoStr("Recycle Basic Handle"), typeof(BasicWoodHandleRecipe));

            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }

    }

    public partial class RecyclePrimitiveHeadsRecipe : RecipeFamily
    {
        public RecyclePrimitiveHeadsRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Recycle Primitive Head",
                    Localizer.DoStr("Recycle Primitive Head"),
                        new IngredientElement[]
                    {
                    new IngredientElement("PrimitiveHead", 1, true)
                    },
                        new CraftingElement<CrushedBasaltItem>(1)
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(0);
            this.CraftMinutes = CreateCraftTimeValue(0.01f);
            Initialize(Localizer.DoStr("Recycle Primitive Head"), typeof(RecyclePrimitiveHeadsRecipe));

            CraftingComponent.AddRecipe(typeof(JawCrusherObject), this);
        }
    }

    public partial class RecycleIronHeadsRecipe : RecipeFamily
    {
        public RecycleIronHeadsRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Recycle Iron Head",
                    Localizer.DoStr("Recycle Iron Head"),
                        new IngredientElement[]
                    {
                    new IngredientElement("IronHead", 1, true)
                    },
                        new CraftingElement<IronBarItem>(1)
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(0);
            this.CraftMinutes = CreateCraftTimeValue(0.01f);
            Initialize(Localizer.DoStr("Recycle Iron Head"), typeof(RecycleIronHeadsRecipe));

            CraftingComponent.AddRecipe(typeof(BloomeryObject), this);
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }

    public partial class RecycleSteelHeadsRecipe : RecipeFamily
    {
        public RecycleSteelHeadsRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Recycle Steel Head",
                    Localizer.DoStr("Recycle Steel Head"),
                        new IngredientElement[]
                    {
                    new IngredientElement("SteelHead", 1, true)
                    },
                        new CraftingElement<SteelBarItem>(1)
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(0);
            this.CraftMinutes = CreateCraftTimeValue(0.01f);
            Initialize(Localizer.DoStr("Recycle Steel Head"), typeof(RecycleSteelHeadsRecipe));

            CraftingComponent.AddRecipe(typeof(BloomeryObject), this);
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }
}
