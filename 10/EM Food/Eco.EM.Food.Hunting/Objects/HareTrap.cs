using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Components;

namespace Eco.EM.Food.Hunting
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]

    [RequireComponent(typeof(BaitableAnimalTrapComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(StatusComponent))]
    public partial class HareTrapObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Hare Trap");

        public virtual Type RepresentedItemType => typeof(HareTrapItem);

        static HareTrapObject() { AddOccupancy<HareTrapObject>(new List<BlockOccupancy>() { new BlockOccupancy(new Vector3i(0, 0, 0)) }); }

        protected override void PostInitialize()
        {
            var comp = GetComponent<BaitableAnimalTrapComponent>();
            comp.Initialize(new List<string>() { "Hare" });
            comp.AddBait(Item.Get(typeof(BeetItem)));
        }
    }

    [Serialized, LocDisplayName("Hare Trap"), Weight(250), MaxStackSize(10)]
    public class HareTrapItem : WorldObjectItem<HareTrapObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Be very, very quiet...");
    }

    [RequiresSkill(typeof(HuntingSkill), 2)]
    public partial class HareTrapRecipe : RecipeFamily
    {
        public HareTrapRecipe()
        {
            var product = new Recipe(
                "HareTrap",
                Localizer.DoStr("Hare Trap"),
                new IngredientElement[]
                {
                    new IngredientElement("WoodBoard", 3, false),
                    new IngredientElement(typeof(PlantFibersItem), 20, false),
                },
                new CraftingElement<HareTrapItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(150f, typeof(HuntingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(HareTrapRecipe), 2f, typeof(HuntingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Hare Trap"), typeof(HareTrapRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}