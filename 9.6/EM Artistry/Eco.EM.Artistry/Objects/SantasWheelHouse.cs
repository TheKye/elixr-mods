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
using Eco.Core.Items;

namespace Eco.EM.Artistry
{
    [Serialized, Weight(600), LocDisplayName("Santas Wheel House"), MaxStackSize(10)]
    [Tag("Housing", 1)]
    public partial class SantasWheelHouseCanvasItem : WorldObjectItem<SantasWheelHouseCanvasObject>, IConfigurableHousing
    {
        public override LocString DisplayDescription => Localizer.DoStr("A beautiful artwork of Santa's Wheelhouse.");
        public override DirectionAxisFlags RequiresSurfaceOnSides { get; } = DirectionAxisFlags.All;
        private static readonly HousingModel defaults = new(
        typeof(SantasWheelHouseCanvasItem),
        "Santa's Wheelhouse",
        "Kitchen",
        skillValue: 5,
        typeForRoomLimit: "Wall Painting",
        diminishingReturn: 0.1f);

        public override HomeFurnishingValue HomeValue => HousingVal;
        
        public static HomeFurnishingValue HousingVal => EMHousingResolver.Obj.ResolveHomeValue(typeof(SantasWheelHouseCanvasItem));

        static SantasWheelHouseCanvasItem() => EMHousingResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(PaintingSkill), 4)]
    public partial class SantasWheelHouseCanvasRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SantasWheelHouseCanvasRecipe).Name,
            Assembly = typeof(SantasWheelHouseCanvasRecipe).AssemblyQualifiedName,
            HiddenName = "Santa's Wheelhouse",
            LocalizableName = Localizer.DoStr("Santa's Wheelhouse"),
            IngredientList = new()
            {
                new EMIngredient("BlackPaintItem", false, 1, true),
                new EMIngredient("BrownPaintItem", false, 4, true),
                new EMIngredient("WhitePaintItem",  false, 3, true),
                new EMIngredient("BluePaintItem", false, 3, true),
                new EMIngredient("GreyPaintItem", false, 5, true),
                new EMIngredient("PaintBrushPackItem", false, 1, true),
                new EMIngredient("PaintPaletteItem", false, 1, true),
                new EMIngredient("EmptyCanvasItem", false,  4, true),
            },
            ProductList = new()
            {
                new EMCraftable("SantasWheelHouseCanvasItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 500,
            LaborIsStatic = false,
            BaseCraftTime = 15,
            CraftTimeIsStatic = false,
            CraftingStation = "ArtStationItem",
            RequiredSkillType = typeof(PaintingSkill),
            RequiredSkillLevel = 4,
            IngredientImprovementTalents = typeof(PaintingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) },
        };

        static SantasWheelHouseCanvasRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SantasWheelHouseCanvasRecipe()
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
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class SantasWheelHouseCanvasObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Santa's Wheelhouse");
        public virtual Type RepresentedItemType => typeof(SantasWheelHouseCanvasItem);

        static SantasWheelHouseCanvasObject()
        {
            AddOccupancy<SantasWheelHouseCanvasObject>(new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            });
        }

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().HomeValue = SantasWheelHouseCanvasItem.HousingVal;
        }

    }
}