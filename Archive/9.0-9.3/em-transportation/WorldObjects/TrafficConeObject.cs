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
    public partial class TrafficConeObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Traffic Cone"); } }
        public virtual Type RepresentedItemType { get { return typeof(TrafficConeItem); } }

        static TrafficConeObject()
        {
            AddOccupancy<TrafficConeObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
            });
        }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(600), LocDisplayName("Traffic Cone"), MaxStackSize(100)]
    public partial class TrafficConeItem : WorldObjectItem<TrafficConeObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Traffic Cone."); } }

        static TrafficConeItem() { }
    }

    [RequiresSkill(typeof(TailoringSkill), 1)]
    public partial class TrafficConeRecipe : RecipeFamily
    {
        public TrafficConeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Traffic Cone",
                    Localizer.DoStr("Traffic Cone"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(ClothItem), 15, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),
                        new IngredientElement("NaturalFiber", 10, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),
                        new IngredientElement(typeof(OrangeDyeItem), 2,typeof(TailoringSkill),typeof(TailoringLavishResourcesTalent))
                    },
                    new CraftingElement<TrafficConeItem>()
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(TrafficConeRecipe), 5, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Traffic Cone"), typeof(TrafficConeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}