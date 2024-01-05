using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.EM.Framework.Components;

namespace Eco.EM.Food.Hunting
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]

    [RequireComponent(typeof(SettableAnimalTrapComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(StatusComponent))]
    public partial class DeerTrapObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Deer Trap"); 
        public virtual Type RepresentedItemType => typeof(DeerTrapItem);

        static DeerTrapObject()
        {
            AddOccupancy<DeerTrapObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(0, 2, 0)),
                new BlockOccupancy(new Vector3i(0, 0, -1)),
                new BlockOccupancy(new Vector3i(0, 1, -1)),
                new BlockOccupancy(new Vector3i(0, 2, -1)),
                new BlockOccupancy(new Vector3i(0, 0, -2)),
                new BlockOccupancy(new Vector3i(0, 1, -2)),
                new BlockOccupancy(new Vector3i(0, 2, -2)),
                });
        }

        protected override void PostInitialize()
        {
            GetComponent<SettableAnimalTrapComponent>().Initialize(new List<string>() { "Deer" });
        }
    }

    [Serialized, LocDisplayName("Deer Trap"), Weight(250), MaxStackSize(10)]
    public class DeerTrapItem : WorldObjectItem<DeerTrapObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Be very, very quiet...");
    }

    [RequiresSkill(typeof(HuntingSkill), 2)]
    public partial class DeerTrapRecipe : RecipeFamily
    {
        public DeerTrapRecipe()
        {
            var product = new Recipe(
                "DeerTrap",
                Localizer.DoStr("Deer Trap"),
                new IngredientElement[]
                {
                    new IngredientElement("WoodBoard", 3, false),
                    new IngredientElement(typeof(PlantFibersItem), 20, false),
                },
                new CraftingElement<DeerTrapItem>(1f)
            );

            Recipes = new List<Recipe> { product };
            LaborInCalories = CreateLaborInCaloriesValue(150f, typeof(HuntingSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(DeerTrapRecipe), 2f, typeof(HuntingSkill));
            Initialize(Localizer.DoStr("Deer Trap"), typeof(DeerTrapRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
}