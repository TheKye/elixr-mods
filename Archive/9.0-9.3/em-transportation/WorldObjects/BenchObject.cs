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
    public partial class BenchObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Bench"); } }

        public virtual Type RepresentedItemType { get { return typeof(BenchItem); } }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();

    }

    [Serialized, Weight(6000), LocDisplayName("Park Bench"), MaxStackSize(100)]
    public partial class BenchItem : WorldObjectItem<BenchObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Beautiful Parck Bench."); } }

        static BenchItem() { }
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class BenchRecipe : RecipeFamily
    {
        public BenchRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Park Bench",
                    Localizer.DoStr("Park Bench"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Lumber", 20, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                        new IngredientElement(typeof(IronBarItem), 4, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                        new IngredientElement(typeof(RivetItem), 20, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                        new IngredientElement(typeof(BrownDyeItem), 3,typeof(CarpentrySkill),typeof(CarpentryLavishResourcesTalent))
                    },
                    new CraftingElement<BenchItem>()
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BenchRecipe), 5, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Park Bench"), typeof(BenchRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}