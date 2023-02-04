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

namespace Eco.Mods.TechTree
{
    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class HandWaterPumpObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Hand Water Pump");
        public Type RepresentedItemType => typeof(HandWaterPumpItem);

        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Crafting"));
        }

        static HandWaterPumpObject()
        {
            WorldObject.AddOccupancy<HandWaterPumpObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            });
        }

        public override void Destroy() { base.Destroy(); }
    }

    [Serialized]
    [LocDisplayName("Hand Water Pump")]
    [MaxStackSize(10)]
    public partial class HandWaterPumpItem : WorldObjectItem<HandWaterPumpObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Hand pump used for gathering water."); } }

        static HandWaterPumpItem() { }
    }

    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class HandWaterPumpRecipe : RecipeFamily
    {
        public HandWaterPumpRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Hand Water Pump",
                    Localizer.DoStr("Hand Water Pump"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(HewnLogItem), 20),
                    new IngredientElement(typeof(MortaredStoneItem), 30)
                    },
                    new CraftingElement<HandWaterPumpItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(HandWaterPumpRecipe), 0.5f, typeof(LoggingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Hand Water Pump"), typeof(HandWaterPumpRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}