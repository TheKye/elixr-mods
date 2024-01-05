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
    public partial class PropaneTank15Recipe : RecipeFamily
    {
        public PropaneTank15Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Propane Tank - 15KG",
                    Localizer.DoStr("Propane Tank - 15KG"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(IronBarItem), 1, true),
                        new IngredientElement(typeof(IronPlateItem), 1, true)
                    },
                    new CraftingElement<PropaneTank15Item>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(IndustrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PropaneTank15Recipe), 1, typeof(IndustrySkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Propane Tank - 15KG"), typeof(PropaneTank15Recipe));
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
    public partial class PropaneTank15Block : PickupableBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PropaneTank15Item);
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(20000)]
    [Currency]
    [LocDisplayName("Propane Tank - 15KG")]
    public partial class PropaneTank15Item : BlockItem<PropaneTank15Block>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("15KG Propane Tanks");
        public override LocString DisplayDescription => Localizer.DoStr("An empty propane tank ready to hold natural gas.");

        public override bool CanStickToWalls => false;
    }
}