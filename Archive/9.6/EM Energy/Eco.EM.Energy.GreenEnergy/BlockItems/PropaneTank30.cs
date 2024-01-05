using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;

namespace Eco.EM.Energy.GreenEnergy
{
    [RequiresSkill(typeof(IndustrySkill), 0)]
    public partial class PropaneTank30Recipe : RecipeFamily
    {
        public PropaneTank30Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Propane Tank - 30KG",
                    Localizer.DoStr("Propane Tank - 30KG"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(IronBarItem), 2, true),
                        new IngredientElement(typeof(IronPlateItem), 2, true)
                    },
                    new CraftingElement<PropaneTank30Item>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(IndustrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PropaneTank30Recipe), 2, typeof(IndustrySkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Propane Tank - 30KG"), typeof(PropaneTank30Recipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid]
    [RequiresSkill(typeof(IndustrySkill), 1)]
    public partial class PropaneTank30Block : PickupableBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PropaneTank30Item);
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(20000)]
    [Currency]
    [LocDisplayName("Propane Tank - 30KG")]
    public partial class PropaneTank30Item : BlockItem<PropaneTank30Block>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("30KG Propane Tanks");
        public override LocString DisplayDescription => Localizer.DoStr("An empty propane tank ready to hold natural gas.");

        public override bool CanStickToWalls => false;
    }
}