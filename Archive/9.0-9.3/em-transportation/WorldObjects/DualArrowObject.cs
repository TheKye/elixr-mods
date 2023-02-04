using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using Eco.Shared.Localization;
using Eco.EM.Artistry;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;

namespace Eco.EM.Transportation
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class DualArrowObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Dual Arrow"); } }
        public virtual Type RepresentedItemType { get { return typeof(DualArrowItem); } }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(10), MaxStackSize(500), LocDisplayName("Dual Arrow")]
    public partial class DualArrowItem : WorldObjectItem<DualArrowObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("An arrow for directing traffic."); } }
        static DualArrowItem() { }
    }

    [RequiresSkill(typeof(TailoringSkill), 1)]
    public partial class DualArrowRecipe : RecipeFamily
    {
        public DualArrowRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Dual Arrow",
                    Localizer.DoStr("Dual Arrow"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(ClothItem), 5, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),
                        new IngredientElement(typeof(GreyDyeItem), 1,typeof(TailoringSkill),typeof(TailoringLavishResourcesTalent))
                    },
                    new CraftingElement<DualArrowItem>()
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(DualArrowRecipe), 5, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Road Arrow - Dual"), typeof(DualArrowRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}