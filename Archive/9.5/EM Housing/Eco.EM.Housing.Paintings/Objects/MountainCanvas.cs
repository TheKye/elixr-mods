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
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.EM.Artistry;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Housing.Paintings
{
    [Serialized, Weight(600), LocDisplayName("Mountain Canvas")]
    [MaxStackSize(10)]
    public partial class MountainCanvasItem : WorldObjectItem<MountainCanvasObject>, IConfigurableHousing
    {
        public override LocString DisplayDescription => Localizer.DoStr("An artwork of some mountains.");

        private static readonly HousingModel defaults = new(
        typeof(MountainCanvasItem),
        "Mountain Canvas",
        roomType: HomeFurnishingValue.RoomCategory.General,
        skillValue: 3,
        typeForRoomLimit: "Wall Painting",
        diminishingReturn: 0.3f);

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren]
        public static HomeFurnishingValue HousingVal => EMHousingResolver.Obj.ResolveHomeValue(typeof(MountainCanvasItem));

        static MountainCanvasItem() => EMHousingResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class MountainCanvasRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(MountainCanvasRecipe).Name,
            Assembly = typeof(MountainCanvasRecipe).AssemblyQualifiedName,
            HiddenName = "Mountain Canvas",
            LocalizableName = Localizer.DoStr("Mountain Canvas"),
            IngredientList = new()
            {
                new EMIngredient("PinkPaintItem", false, 2, true),
                new EMIngredient("PurplePaintItem", false, 2, true),
                new EMIngredient("BluePaintItem", false, 2, true),
                new EMIngredient("OrangePaintItem", false, 2, true),
                new EMIngredient("PaintBrushPackItem", false, 1, true),
                new EMIngredient("PaintPaletteItem", false, 1, true),
                new EMIngredient("EmptyCanvasItem", false, 2, true),
            },
            ProductList = new()
            {
                new EMCraftable("MountainCanvasItem"),
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

        static MountainCanvasRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public MountainCanvasRecipe()
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
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class MountainCanvasObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Mountain Canvas");
        public virtual Type RepresentedItemType => typeof(MountainCanvasItem);

        static MountainCanvasObject()
        {
            AddOccupancy<MountainCanvasObject>(new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i( 0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            });
        }

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().HomeValue = MountainCanvasItem.HousingVal;
        }

        public override void Destroy() => base.Destroy();
    }
}