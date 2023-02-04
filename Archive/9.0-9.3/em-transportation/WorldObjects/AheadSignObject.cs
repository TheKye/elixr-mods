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
    public partial class AheadSignObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Ahead Sign"); } }
        public virtual Type RepresentedItemType { get { return typeof(AheadSignItem); } }

        static AheadSignObject()
        {
            AddOccupancy<AheadSignObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(0, 2, 0)),
            });
        }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(600), LocDisplayName("Ahead Sign"), MaxStackSize(100)]
    public partial class AheadSignItem : WorldObjectItem<AheadSignObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Sign For Something Ahead."); } }

        static AheadSignItem() { }
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class AheadSignRecipe : RecipeFamily
    {
        public AheadSignRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Sign - Ahead Sign",
                    Localizer.DoStr("Sign - Ahead"),
                    new IngredientElement[]
                    {
                        new IngredientElement("WoodBoard", 8, typeof(SmeltingSkill)),
                        new IngredientElement(typeof(IronBarItem), 4,typeof(SmeltingSkill)),
                        new IngredientElement(typeof(BlueDyeItem), 1)
                    },
                    new CraftingElement<AheadSignItem>()
                    )
                };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AheadSignRecipe), 5, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Sign - Ahead Sign"), typeof(AheadSignRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}