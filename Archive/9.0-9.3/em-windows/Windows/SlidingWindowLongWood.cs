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
using Eco.World.Blocks;
using Eco.Mods.TechTree;

namespace Eco.EM.Windows
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [Wall, Solid]
    public partial class SlidingWindowLongWoodObject : WindowObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Wood Sliding Window"); } }
        public virtual Type RepresentedItemType { get { return typeof(SlidingWindowLongWoodItem); } }

        protected override void Initialize() { }

        static SlidingWindowLongWoodObject()
        {
            AddOccupancy<SlidingWindowLongWoodObject>(new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i(0, 0,  0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            });
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [Tier(2)]
    [Weight(600)]
    [Wall, Solid]
    [LocDisplayName("Long Wood Sliding Window")]
    public partial class SlidingWindowLongWoodItem : WorldObjectItem<SlidingWindowLongWoodObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A horizontal sliding window made out of wood and glass. Could be used as a shop window?"); } }

        static SlidingWindowLongWoodItem() { }
    }

    [RequiresSkill(typeof(CarpentrySkill), 0)]
    public partial class SlidingWindowLongWoodRecipe : RecipeFamily
    {
        public SlidingWindowLongWoodRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Long Wood Sliding Window",
                    Localizer.DoStr("Long Wood Sliding Window"),
                    new IngredientElement[]
                    {
                        new IngredientElement("WoodBoard", 10, typeof(CarpentrySkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(GlassItem), 4,typeof(CarpentrySkill),typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<SlidingWindowLongWoodItem>()
                    )
                };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SlidingWindowLongWoodRecipe), 10, typeof(CarpentrySkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Long Wood Sliding Window"), typeof(SlidingWindowLongWoodRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}