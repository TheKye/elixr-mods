﻿using System;
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
    public partial class StreetLightsCanvasObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName =>Localizer.DoStr("Street Lights Canvas");

        public Type RepresentedItemType => typeof(StreetLightsCanvasItem);

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().HomeValue = StreetLightsCanvasItem.HousingVal;
        }

        public override void Destroy() { base.Destroy(); }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class StreetLightsCanvasRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(StreetLightsCanvasRecipe).Name,
            Assembly = typeof(StreetLightsCanvasRecipe).AssemblyQualifiedName,
            HiddenName = "Street Lights Canvas",
            LocalizableName = Localizer.DoStr("Street Lights Canvas"),
            IngredientList = new()
            {
                new EMIngredient("GreenPaintItem", false, 1, true),
                new EMIngredient("GreyPaintItem", false, 1, true),
                new EMIngredient("BluePaintItem", false, 1, true),
                new EMIngredient("YellowPaintItem", false, 1, true),
                new EMIngredient("PaintBrushItem", false, 5),
                new EMIngredient("PaintPaletteItem", false, 5),
                new EMIngredient("EmptyCanvasItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("StreetLightsCanvasItem"),
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

        static StreetLightsCanvasRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public StreetLightsCanvasRecipe()
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
    [LocDisplayName("Street Lights Canvas")]
    public partial class StreetLightsCanvasItem : WorldObjectItem<StreetLightsCanvasObject>, IConfigurableHousing
    {
        public override LocString DisplayDescription => Localizer.DoStr("An artwork of street lights.");

        private static readonly HousingModel defaults = new(
        typeof(StreetLightsCanvasItem),
        "Street Lights Canvas",
        roomType: HomeFurnishingValue.RoomCategory.General,
        skillValue: 3,
        typeForRoomLimit: "Wall Painting",
        diminishingReturn: 0.3f);

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren]
        public static HomeFurnishingValue HousingVal => EMHousingResolver.Obj.ResolveHomeValue(typeof(StreetLightsCanvasItem));

        static StreetLightsCanvasItem() => EMHousingResolver.AddDefaults(defaults);
    }
}
