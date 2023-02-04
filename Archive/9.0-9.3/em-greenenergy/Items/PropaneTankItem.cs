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

namespace Eco.EM.GreenEnergy
{
    [RequiresSkill(typeof(IndustrySkill), 0)]
    public partial class PropaneTankRecipe : RecipeFamily
    {
        public PropaneTankRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Propane Tank",
                    Localizer.DoStr("Propane Tank"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 4, true)
                    },
                    new CraftingElement<PropaneTankItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(IndustrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PropaneTankRecipe), 3, typeof(IndustrySkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Propane Tank"), typeof(PropaneTankRecipe));
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
    public partial class PropaneTankBlock : PickupableBlock, IRepresentsItem
    {
        public Type RepresentedItemType
        {
            get
            {
                return typeof(PropaneTankItem);

            }
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(20000)]
    [Currency]
    [LocDisplayName("Propane Tank")]
    public partial class PropaneTankItem : BlockItem<PropaneTankBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Propane Tanks"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("An empty propane tank ready to hold natural gas."); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}