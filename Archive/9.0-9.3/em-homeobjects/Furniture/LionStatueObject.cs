using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Furniture
{
    [Serialized, Weight(500), MaxStackSize(50), LocDisplayName("Lion Statue")]
    [Tag("Housing", 1)]
    public partial class LionStatueItem : WorldObjectItem<LionStatueObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("What's more gauche than a giant cement lion?.");

        [TooltipChildren] public HousingValue HousingTooltip => HousingVal;
        [TooltipChildren] public static HousingValue HousingVal => new HousingValue() { Category = HousingValue.RoomCategory.General, Val = 5, TypeForRoomLimit = "Decoration", DiminishingReturnPercent = 0.2f };
    }

    [RequiresSkill(typeof(MasonrySkill), 2)]
    public partial class LionStatueRecipe : RecipeFamily
    {
        private string rName = "Lion Statue";
        private Type skillBase = typeof(MasonrySkill);
        private Type ingTalent = typeof(MasonryLavishResourcesTalent);
        private Type[] speedTalents = { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) };

        public LionStatueRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Rock", 40, skillBase, ingTalent),
                    new IngredientElement(typeof(ClothItem), 15, skillBase, ingTalent),
                    new IngredientElement(typeof(PlanterPotSquareItem), 1, false),
                },
                 new CraftingElement<LionStatueItem>(1f)
            );
            this.ExperienceOnCraft = 2;
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(300f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 10f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class LionStatueObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Lion Statue");
        public Type RepresentedItemType => typeof(LionStatueItem);

        static LionStatueObject()
        {
            AddOccupancy<LionStatueObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 0, -1)),
            });
        }

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(LionStatueItem.HousingVal);
        }

        public override void Destroy() => base.Destroy();
    }
}

