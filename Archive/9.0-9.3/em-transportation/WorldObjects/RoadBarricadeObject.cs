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
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class RoadBarricadeObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Road Barricade"); } }
        public virtual Type RepresentedItemType { get { return typeof(RoadBarricadeItem); } }

        static RoadBarricadeObject()
        {
            AddOccupancy<RoadBarricadeObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(-1, 0, 0)),
            });
        }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(5000), MaxStackSize(20), LocDisplayName("Road Barricade")]
    public partial class RoadBarricadeItem : WorldObjectItem<RoadBarricadeObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Barricade for blocking off roads."); } }
        static RoadBarricadeItem() { }
    }

    [RequiresSkill(typeof(CarpentrySkill), 1)]
    public partial class RoadBarricadeRecipe : RecipeFamily
    {
        public RoadBarricadeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Road Barricade",
                    Localizer.DoStr("Road Barricade"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Lumber", 50, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                        new IngredientElement(typeof(BlackDyeItem), 2, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                        new IngredientElement(typeof(YellowDyeItem), 2,typeof(CarpentrySkill),typeof(CarpentryLavishResourcesTalent))
                    },
                    new CraftingElement<RoadBarricadeItem>()
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RoadBarricadeRecipe), 5, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Road Barricade"), typeof(RoadBarricadeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}