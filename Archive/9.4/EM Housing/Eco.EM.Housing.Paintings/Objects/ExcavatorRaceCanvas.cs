using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Gameplay.Housing.PropertyValues;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.EM.Artistry;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Housing.Paintings
{
    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class ExcavatorRaceCanvasObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Excavator Race Canvas");

        public Type RepresentedItemType => typeof(ExcavatorRaceCanvasItem);

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().HomeValue = ExcavatorRaceCanvasItem.HousingVal;
        }

        public override void Destroy() { base.Destroy(); }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class ExcavatorRaceCanvasRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ExcavatorRaceCanvasRecipe).Name,
            Assembly = typeof(ExcavatorRaceCanvasRecipe).AssemblyQualifiedName,
            HiddenName = "Excavator Race Canvas",
            LocalizableName = Localizer.DoStr("Excavator Race Canvas"),
            IngredientList = new()
            {
                new EMIngredient("GreenPaintItem", false, 1, true),
                new EMIngredient("YellowPaintItem", false, 1, true),
                new EMIngredient("GreyPaintItem", false, 1, true),
                new EMIngredient("WhitePaintItem", false, 1, true),
                new EMIngredient("PaintBrushItem", false, 5),
                new EMIngredient("PaintPaletteItem", false, 5),
                new EMIngredient("EmptyCanvasItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("ExcavatorRaceCanvasItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 500,
            LaborIsStatic = false,
            BaseCraftTime = 15,
            CraftTimeIsStatic = false,
            CraftingStation = "ArtStationItem",
            RequiredSkillType = typeof(PaintingSkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(PaintingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) },
        };

        static ExcavatorRaceCanvasRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ExcavatorRaceCanvasRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [Serialized]
    [Weight(500)]
    [MaxStackSize(10)]
    [LocDisplayName("Excavator Race Canvas")]
    public partial class ExcavatorRaceCanvasItem : WorldObjectItem<ExcavatorRaceCanvasObject>, IConfigurableHousing
    {
        public override LocString DisplayDescription => Localizer.DoStr("An artwork about a great Excavator Race.");

        private static readonly HousingModel defaults = new(
        typeof(ExcavatorRaceCanvasItem),
        "Excavator Race Canvas",
        roomType: HomeFurnishingValue.RoomCategory.General,
        skillValue: 3,
        typeForRoomLimit: "Wall Painting",
        diminishingReturn: 0.3f);

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren]
        public static HomeFurnishingValue HousingVal => EMHousingResolver.Obj.ResolveHomeValue(typeof(ExcavatorRaceCanvasItem));

        static ExcavatorRaceCanvasItem() => EMHousingResolver.AddDefaults(defaults);
    }
}
