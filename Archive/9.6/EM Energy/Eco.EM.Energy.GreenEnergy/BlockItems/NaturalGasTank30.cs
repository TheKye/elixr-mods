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
    public partial class NaturalGas30Recipe : RecipeFamily
    {
        public NaturalGas30Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Natural Gas Tank - 30KG",
                    Localizer.DoStr("Natural Gas Tank - 30KG"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(PropaneTank30Item), 1, typeof(OilDrillingSkill))
                    },
                    new CraftingElement<NaturalGas30Item>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(300, typeof(OilDrillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(NaturalGas30Recipe), 2, typeof(OilDrillingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Natural Gas Tank - 30KG"), typeof(NaturalGas30Recipe));
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
    public partial class NaturalGas30Block : PickupableBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(NaturalGas30Item);
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(20000)]
    [Fuel(20000)]
    [Tag("Fuel")]
    [Tag("Liquid Fuel", 1)]
    [Currency]
    [Tag("Currency")]
    [LocDisplayName("Natural Gas Tank - 30KG")]
    public partial class NaturalGas30Item : BlockItem<NaturalGas30Block>
    {
        public override LocString DisplayNamePlural  => Localizer.DoStr("30KG Natural Gas Tanks");
        public override LocString DisplayDescription => Localizer.DoStr("A 30KG Bottle of Natural Gas, Provides a bit more Fuel as it is a slightly bigger Bottle");

        public override bool CanStickToWalls => false;
    }
}
