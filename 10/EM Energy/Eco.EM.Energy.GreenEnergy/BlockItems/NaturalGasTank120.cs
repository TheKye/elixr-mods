using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Core.Items;
using Eco.Mods.TechTree;

namespace Eco.EM.Energy.GreenEnergy
{
    [RequiresSkill(typeof(OilDrillingSkill), 0)]
    public partial class NaturalGas120Recipe : RecipeFamily
    {
        public NaturalGas120Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Natural Gas Tank - 120KG",
                    Localizer.DoStr("Natural Gas Tank - 120KG"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(PropaneTank120Item), 1, typeof(OilDrillingSkill))
                    },
                    new CraftingElement<NaturalGas120Item>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(300, typeof(OilDrillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(NaturalGas120Recipe), 6, typeof(OilDrillingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Natural Gas Tank - 120KG"), typeof(NaturalGas120Recipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(GasPumpObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid]
    [RequiresSkill(typeof(OilDrillingSkill), 3)]
    public partial class NaturalGas120Block : PickupableBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(NaturalGas120Item);
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(20000)]
    [Fuel(80000)]
    [Tag("Fuel")]
    [Tag("Liquid Fuel", 1)]
    [Currency]
    [Tag("Currency")]
    [LocDisplayName("Natural Gas Tank - 120KG")]
    public partial class NaturalGas120Item : BlockItem<NaturalGas120Block>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Natural Gas Tanks");
        public override LocString DisplayDescription => Localizer.DoStr("A 120KG Bottle of Natural Gas, Provide Much More Fuel as it is a Really Large Bottle");

        public override bool CanStickToWalls => false;
    }
}
