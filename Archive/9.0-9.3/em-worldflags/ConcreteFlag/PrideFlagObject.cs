using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Mods.TechTree;
using System;
using Eco.Shared.Math;

namespace Eco.EM.Flags
{
    [Serialized]
    [RequireComponent(typeof(PrideFlagComponent))]
    public partial class PrideFlagObject : BaseFlagObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Pride Flag"); } }
        public Type RepresentedItemType => typeof(PrideFlagItem);
    }

    [Serialized]
    [LocDisplayName("Pride Flag")]
    [Ecopedia("Flags", "Flags", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Weight(10)]
    public partial class PrideFlagItem : WorldObjectItem<PrideFlagObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A flag on a beautifuly hand crafted piece of cloth held up by a well crafted iron stand. Display it out front of your house, on your town hall or wherever you like!"); } }

        static PrideFlagItem()
        {
            WorldObject.AddOccupancy<PrideFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    public partial class PrideFlagRecipe : RecipeFamily
    {
        public PrideFlagRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Pride Flag",
                    Localizer.DoStr("Pride Flag"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 10),
                    new IngredientElement(typeof(ClothItem), 5)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<PrideFlagItem>(),
                    }
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(30);
            this.CraftMinutes = CreateCraftTimeValue(0.1f);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Pride Flag"), typeof(PrideFlagRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}