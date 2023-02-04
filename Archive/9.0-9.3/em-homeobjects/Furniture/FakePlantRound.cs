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
    [Serialized, Weight(200), MaxStackSize(50), LocDisplayName("Fake Plant Round")]
    [Tag("Housing", 1)]
    public partial class FakePlantRoundItem : WorldObjectItem<FakePlantRoundObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Sometimes you just don't want the real nature inside your house.");

        [TooltipChildren] public HousingValue HousingTooltip => HousingVal;
        [TooltipChildren] public static HousingValue HousingVal => new HousingValue() {Category = HousingValue.RoomCategory.General, Val = 2, TypeForRoomLimit = "Decoration", DiminishingReturnPercent = 0.8f};
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class FakePlantRoundRecipe : RecipeFamily
    {
        private string rName = "Fake Plant";
        private Type skillBase = typeof(TailoringSkill);
        private Type ingTalent = typeof(TailoringLavishResourcesTalent);
        private Type[] speedTalents = { typeof(TailoringParallelSpeedTalent), typeof(TailoringFocusedSpeedTalent) };

        public FakePlantRoundRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(DirtItem), 1, false),
                    new IngredientElement(typeof(PlantFibersItem), 25, skillBase, ingTalent),
                    new IngredientElement(typeof(ClothItem), 15, skillBase, ingTalent),
                    new IngredientElement(typeof(PlanterPotSquareItem), 1, false),
                },
                 new CraftingElement<FakePlantRoundItem>(1f)
            );
            this.ExperienceOnCraft = 2;
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(300f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 10f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
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
    public partial class FakePlantRoundObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Fake Plant");
        public Type RepresentedItemType => typeof(FakePlantRoundItem);

        static FakePlantRoundObject()
        {
            AddOccupancy<FakePlantRoundObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
            });
        }

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(FakePlantRoundItem.HousingVal);
        }

        public override void Destroy() => base.Destroy();
    }
}
