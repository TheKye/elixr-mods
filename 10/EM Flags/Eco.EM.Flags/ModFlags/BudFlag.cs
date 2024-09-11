using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using Eco.Shared.Math;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Mods.TechTree;
using System;
using Eco.Shared.Networking;
using Eco.Core.Controller;
using Eco.Gameplay.Players;

namespace Eco.EM.Flags.ModFlags
{
    [Serialized]

    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class BudFlagObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("BudBrownbeard - Flag #01"); } }
        public Type RepresentedItemType => typeof(BudFlagItem);

    }

    [Serialized]
    [LocDisplayName("BudBrownbeard - Flag #01")]
    [Ecopedia("Flags", "Flags", createAsSubPage: true)]
    [Weight(10)]
    public partial class BudFlagItem : WorldObjectItem<BudFlagObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("The BudBrownbeard - Flag #01 on a beautifully hand crafted piece of cloth held up by a well crafted stand. Display it out front of your house, on your town hall or wherever you like!"); } }

        static BudFlagItem()
        {
            WorldObject.AddOccupancy<BudFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    public partial class BudFlagRecipe : RecipeFamily
    {
        public BudFlagRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "BudBrownbeard - Flag #01",
                    Localizer.DoStr("BudBrownbeard - Flag #01"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 10),
                    new IngredientElement(typeof(ClothItem), 5)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<BudFlagItem>(2),
                    }
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(30);
            this.CraftMinutes = CreateCraftTimeValue(0.1f);
            this.Initialize(Localizer.DoStr("BudBrownbeard - Flag #01"), typeof(BudFlagRecipe));

            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }

    [Serialized]

    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class BudRWFlagObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("RW BudBrownbeard - Flag #01 "); } }
        public Type RepresentedItemType => typeof(BudRWFlagItem);

    }

    [Serialized]
    [LocDisplayName("RW BudBrownbeard - Flag #01")]
    [Ecopedia("Flags", "Flags", createAsSubPage: true)]
    [Weight(10)]
    public partial class BudRWFlagItem : WorldObjectItem<BudRWFlagObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("The BudBrownbeard - Flag #01 on a beautifully hand crafted piece of cloth held up by a well crafted Redwood and Gold stand. Display it out front of your house, on your town hall or wherever you like!"); } }

        static BudRWFlagItem()
        {
            WorldObject.AddOccupancy<BudRWFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    public partial class BudRWFlagRecipe : RecipeFamily
    {
        public BudRWFlagRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "BudRWBrownbeard - Flag #01",
                    Localizer.DoStr("BudRWBrownbeard - Flag #01"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 10),
                    new IngredientElement(typeof(ClothItem), 5)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<BudRWFlagItem>(2),
                    }
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(30);
            this.CraftMinutes = CreateCraftTimeValue(0.1f);
            this.Initialize(Localizer.DoStr("BudRWBrownbeard - Flag #01"), typeof(BudRWFlagRecipe));

            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
}