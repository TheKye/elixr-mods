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
    public partial class SlidingWindowTallWoodObject : WindowObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Wood Sliding Window"); } }
        public virtual Type RepresentedItemType { get { return typeof(SlidingWindowTallWoodItem); } }

        protected override void Initialize() { }

        static SlidingWindowTallWoodObject()
        {
            AddOccupancy<SlidingWindowTallWoodObject>(new List<BlockOccupancy>()
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
    [LocDisplayName("Tall Wood Sliding Window")]
    [Wall, Solid]
    public partial class SlidingWindowTallWoodItem : WorldObjectItem<SlidingWindowTallWoodObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A vertical sliding window made out of wood and glass."); } }
        
        static SlidingWindowTallWoodItem() { }
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class SlidingWindowTallWoodRecipe : RecipeFamily
    {
        public SlidingWindowTallWoodRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Tall Wood Sliding Window",
                    Localizer.DoStr("Tall Wood Sliding Window"),
                    new IngredientElement[]
                    {
                        new IngredientElement("WoodBoard", 8, typeof(CarpentrySkill)),
                        new IngredientElement(typeof(GlassItem), 4,typeof(CarpentrySkill))
                    },
                    new CraftingElement<SlidingWindowTallWoodItem>()
                    )
                };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SlidingWindowTallWoodRecipe), 10, typeof(CarpentrySkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Tall Wood Sliding Window"), typeof(SlidingWindowTallWoodRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}