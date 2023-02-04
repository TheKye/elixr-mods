using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Shared.Localization;
using Eco.EM.Artistry;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;

namespace Eco.EM.Transportation
{
    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class WaterTankWhiteBarrierObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("White Water Tank Barrier"); } }
        public virtual Type RepresentedItemType { get { return typeof(WaterTankWhiteBarrierItem); } }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(600), LocDisplayName("White Water Tank Barrier"), MaxStackSize(100)]
    public partial class WaterTankWhiteBarrierItem : WorldObjectItem<WaterTankWhiteBarrierObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A White Water Tank Type Barrier."); } }

        static WaterTankWhiteBarrierItem() { }
    }

    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class WaterTankWhiteBarrierRecipe : RecipeFamily
    {
        public WaterTankWhiteBarrierRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "White Water Tank Barrier",
                    Localizer.DoStr("White Water Tank Barrier"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(CementItem), 5, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                        new IngredientElement(typeof(GreyDyeItem), 2, typeof(PaintingSkill), typeof(PaintingLavishResourcesTalent)),
                        new IngredientElement(typeof(BucketOfWaterItem), 5, true),
                    },
                    new CraftingElement<WaterTankWhiteBarrierItem>(),
                    new CraftingElement<BucketItem>(5)
                    )
            };
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(WaterTankWhiteBarrierRecipe), 2, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Water Tank Barrier - White"), typeof(WaterTankWhiteBarrierRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CementKilnObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}