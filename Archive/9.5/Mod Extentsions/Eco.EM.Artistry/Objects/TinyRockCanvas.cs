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

namespace Eco.EM.Artistry
{
    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class TinyRockFarmCanvasObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Tiny Rock Farm Canvas"); 

        public Type RepresentedItemType => typeof(TinyRockFarmCanvasItem);

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().HomeValue = TinyRockFarmCanvasItem.HousingVal;
        }

        public override void Destroy() => base.Destroy();
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class TinyRockFarmCanvasRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TinyRockFarmCanvasRecipe).Name,
            Assembly = typeof(TinyRockFarmCanvasRecipe).AssemblyQualifiedName,
            HiddenName = "Tiny Rock Farm Canvas",
            LocalizableName = Localizer.DoStr("Tiny Rock Farm Canvas"),
            IngredientList = new()
            {
                new EMIngredient("GreenPaintItem", false, 1, true),
                new EMIngredient("BrownPaintItem", false, 1, true),
                new EMIngredient("BluePaintItem", false, 1, true),
                new EMIngredient("BlackPaintItem", false, 1, true),
                new EMIngredient("PaintBrushPackItem", false, 1, true),
                new EMIngredient("PaintPaletteItem", false, 1, true),
                new EMIngredient("EmptyCanvasItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("TinyRockFarmCanvasItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 500,
            LaborIsStatic = false,
            BaseCraftTime = 15,
            CraftTimeIsStatic = false,
            CraftingStation = "ArtStationItem",
            RequiredSkillType = typeof(PaintingSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(PaintingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) },
        };

        static TinyRockFarmCanvasRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TinyRockFarmCanvasRecipe()
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
    [LocDisplayName("Tiny Rock Farm Canvas")]
    [MaxStackSize(10)]
    public partial class TinyRockFarmCanvasItem : WorldObjectItem<TinyRockFarmCanvasObject>, IConfigurableHousing
    {
        public override LocString DisplayDescription => Localizer.DoStr("An artwork of Tiny Rock Farm.");

        private static readonly HousingModel defaults = new(
        typeof(TinyRockFarmCanvasItem),
        "Tiny Rock Farm Canvas",
        roomType: HomeFurnishingValue.RoomCategory.General,
        skillValue: 3,
        typeForRoomLimit: "Wall Painting",
        diminishingReturn: 0.3f);

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren]
        public static HomeFurnishingValue HousingVal => EMHousingResolver.Obj.ResolveHomeValue(typeof(TinyRockFarmCanvasItem));

        static TinyRockFarmCanvasItem() => EMHousingResolver.AddDefaults(defaults);
    }
}