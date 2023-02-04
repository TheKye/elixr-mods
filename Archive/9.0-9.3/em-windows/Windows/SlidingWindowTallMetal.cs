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
    public partial class SlidingWindowTallMetalObject : WindowObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Metal Sliding Window"); } }
        public virtual Type RepresentedItemType { get { return typeof(SlidingWindowTallMetalItem); } }

        protected override void Initialize() { }

        static SlidingWindowTallMetalObject()
        {
            AddOccupancy<SlidingWindowTallMetalObject>(new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            });
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [Tier(2)]
    [Weight(600)]
    [LocDisplayName("Tall Metal Sliding Window")]
    [Wall, Solid]
    public partial class SlidingWindowTallMetalItem : WorldObjectItem<SlidingWindowTallMetalObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A vertical sliding window made out of metal and glass."); } }

        static SlidingWindowTallMetalItem() { }
    }

    [RequiresSkill(typeof(SmeltingSkill), 3)]
    public partial class SlidingWindowTallMetalRecipe : RecipeFamily
    {
        public SlidingWindowTallMetalRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Tall Metal Sliding Window",
                    Localizer.DoStr("Tall Metal Sliding Window"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(IronBarItem), 8, typeof(SmeltingSkill)),
                        new IngredientElement(typeof(GlassItem), 4,typeof(SmeltingSkill))
                    },
                    new CraftingElement<SlidingWindowTallMetalItem>()
                    )
                };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SlidingWindowTallMetalRecipe), 10, typeof(SmeltingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Tall Metal Sliding Window"), typeof(SlidingWindowTallMetalRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}