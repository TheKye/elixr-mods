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
    public partial class PropaneTank60Recipe : RecipeFamily
    {
        public PropaneTank60Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Propane Tank - 60KG",
                    Localizer.DoStr("Propane Tank - 60KG"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(IronBarItem), 4, true),
                        new IngredientElement(typeof(IronPlateItem), 4, true)
                    },
                    new CraftingElement<PropaneTank60Item>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(IndustrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PropaneTank60Recipe), 4, typeof(IndustrySkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Propane Tank - 60KG"), typeof(PropaneTank60Recipe));
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
    public partial class PropaneTank60Block : PickupableBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PropaneTank60Item);
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(20000)]
    [Currency]
    [LocDisplayName("Propane Tank - 60KG")]
    public partial class PropaneTank60Item : BlockItem<PropaneTank60Block>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("60KG Propane Tanks");
        public override LocString DisplayDescription => Localizer.DoStr("An empty propane tank ready to hold natural gas.");

        public override bool CanStickToWalls => false;
    }
}