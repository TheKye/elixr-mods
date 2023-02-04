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
    public partial class TTTCanvasObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Tiny Tina's Treats Canvas"); 

        public Type RepresentedItemType => typeof(TTTCanvasItem);

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().HomeValue = TTTCanvasItem.HousingVal;
        }

        public override void Destroy() => base.Destroy();
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class TTTCanvasRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TTTCanvasRecipe).Name,
            Assembly = typeof(TTTCanvasRecipe).AssemblyQualifiedName,
            HiddenName = "Tiny Tina's Treats Canvas",
            LocalizableName = Localizer.DoStr("Tiny Tina's Treats Canvas"),
            IngredientList = new()
            {
                new EMIngredient("GreenPaintItem", false, 1, true),
                new EMIngredient("BrownPaintItem", false, 1, true),
                new EMIngredient("BluePaintItem", false, 1, true),
                new EMIngredient("WhitePaintItem", false, 1, true),
                new EMIngredient("PaintBrushItem", false, 5),
                new EMIngredient("PaintPaletteItem", false, 5),
                new EMIngredient("EmptyCanvasItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("TTTCanvasItem"),
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

        static TTTCanvasRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TTTCanvasRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [Serialized, Weight(500), MaxStackSize(10), LocDisplayName("Tiny Tinas Treats Canvas")]
    public partial class TTTCanvasItem : WorldObjectItem<TTTCanvasObject>, IConfigurableHousing
    {
        public override LocString DisplayDescription => Localizer.DoStr("An artwork of Tiny Tina's Treats Shop.");

        private static readonly HousingModel defaults = new(
        typeof(TTTCanvasItem),
        "Tiny Tina's Treats Canvas",
        roomType: HomeFurnishingValue.RoomCategory.General,
        skillValue: 3,
        typeForRoomLimit: "Wall Painting",
        diminishingReturn: 0.3f);

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren]
        public static HomeFurnishingValue HousingVal => EMHousingResolver.Obj.ResolveHomeValue(typeof(TTTCanvasItem));

        static TTTCanvasItem() => EMHousingResolver.AddDefaults(defaults);
    }
}
