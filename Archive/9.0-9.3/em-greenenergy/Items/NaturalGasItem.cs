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

namespace Eco.EM.GreenEnergy
{
    [RequiresSkill(typeof(OilDrillingSkill), 0)]
    public partial class NaturalGasRecipe : RecipeFamily
    {
        public NaturalGasRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Natural Gas Tank",
                    Localizer.DoStr("Natural Gas Tank"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(PropaneTankItem), 1, typeof(OilDrillingSkill))
                    },
                    new CraftingElement<NaturalGasItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(300, typeof(OilDrillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(NaturalGasRecipe), 4, typeof(OilDrillingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Natural Gas"), typeof(NaturalGasRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(PumpJackObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid]
    [RequiresSkill(typeof(OilDrillingSkill), 3)]
    public partial class NaturalGasBlock : PickupableBlock, IRepresentsItem
    {
        public Type RepresentedItemType
        {
            get
            {
                return typeof(NaturalGasItem);

            }
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(20000)]
    [Fuel(60000)][Tag("Fuel")]
    [Tag("Liquid Fuel", 1)]
    [Currency][Tag("Currency")]
    [LocDisplayName("Natural Gas Tank")]
    public partial class NaturalGasItem : BlockItem<NaturalGasBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Natural Gas Tank"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Natural Gas which is pumped from deep within our planet to use as a cleaner fuel."); } }

        public override bool CanStickToWalls { get { return false; } }

    }

}