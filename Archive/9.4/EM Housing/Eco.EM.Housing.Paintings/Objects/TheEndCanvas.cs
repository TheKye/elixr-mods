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
    [Serialized, Weight(500), LocDisplayName("The End Canvas")]
    [MaxStackSize(10)]
    public partial class TheEndCanvasItem : WorldObjectItem<TheEndCanvasObject>, IConfigurableHousing
    {
        public override LocString DisplayDescription => Localizer.DoStr("An artwork of the possible end.");

        private static readonly HousingModel defaults = new(
        typeof(TheEndCanvasItem),
        "The End Canvas",
        roomType: HomeFurnishingValue.RoomCategory.General,
        skillValue: 3,
        typeForRoomLimit: "Wall Painting",
        diminishingReturn: 0.3f);

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren]
        public static HomeFurnishingValue HousingVal => EMHousingResolver.Obj.ResolveHomeValue(typeof(TheEndCanvasItem));

        static TheEndCanvasItem() => EMHousingResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class TheEndCanvasRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TheEndCanvasRecipe).Name,
            Assembly = typeof(TheEndCanvasRecipe).AssemblyQualifiedName,
            HiddenName = "The End Canvas",
            LocalizableName = Localizer.DoStr("The End Canvas"),
            IngredientList = new()
            {
                new EMIngredient("YellowPaintItem", false, 1, true),
                new EMIngredient("OrangePaintItem", false, 2, true),
                new EMIngredient("BluePaintItem", false, 1, true),
                new EMIngredient("PaintBrushItem", false, 5),
                new EMIngredient("PaintPaletteItem", false, 5),
                new EMIngredient("EmptyCanvasItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("TheEndCanvasItem"),
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

        static TheEndCanvasRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TheEndCanvasRecipe()
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
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class TheEndCanvasObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("The End Canvas");
        public Type RepresentedItemType => typeof(TheEndCanvasItem);

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().HomeValue = TheEndCanvasItem.HousingVal;
        }

        public override void Destroy() => base.Destroy();
    }
}