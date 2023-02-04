using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using Eco.Shared.Localization;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;

namespace Eco.EM.Transportation
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class RoadMetalBarrierObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Metal Barrier"); } }
        public virtual Type RepresentedItemType { get { return typeof(RoadMetalBarrierItem); } }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(600), LocDisplayName("Metal Barrier"), MaxStackSize(100)]
    public partial class RoadMetalBarrierItem : WorldObjectItem<RoadMetalBarrierObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Metal Barrier To Work as A Boundry."); } }

        static RoadMetalBarrierItem() { }
    }

    [RequiresSkill(typeof(SmeltingSkill), 3)]
    public partial class RoadMetalBarrierRecipe : RecipeFamily
    {
        public RoadMetalBarrierRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Metal Barrier",
                    Localizer.DoStr("Metal Barrier"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(IronBarItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                    },
                    new CraftingElement<RoadMetalBarrierItem>()
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RoadMetalBarrierRecipe), 5, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Metal Barrier"), typeof(RoadMetalBarrierRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}