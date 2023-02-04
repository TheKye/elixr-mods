using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Artistry
{
    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class TTTCanvasObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tiny Tina's Treats Canvas"); } }

        public Type RepresentedItemType => typeof(TTTCanvasItem);

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(TTTCanvasItem.HousingVal);
        }

        public override void Destroy() => base.Destroy();
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class TTTCanvasRecipe : RecipeFamily
    {
        private string rName = "Tiny Tina's Treats Canvas";
        private Type skillBase = typeof(PaintingSkill);
        private Type ingTalent = typeof(PaintingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) };

        public TTTCanvasRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GreenPaintItem), 1, true),
                    new IngredientElement(typeof(BrownPaintItem), 1, true),
                    new IngredientElement(typeof(BluePaintItem), 1, true),
                    new IngredientElement(typeof(WhitePaintItem), 1, true),
                    new IngredientElement(typeof(PaintBrushItem), 5, skillBase, ingTalent),
                    new IngredientElement(typeof(PaintPaletteItem), 5, skillBase, ingTalent),
                    new IngredientElement(typeof(EmptyCanvasItem), 1, true),
                },
                 new CraftingElement<TTTCanvasItem>(1f)
            );
            this.ExperienceOnCraft = 2;
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(500f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(typeof(TTTCanvasRecipe), 15f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), typeof(TTTCanvasRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ArtStationObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized, Weight(500), MaxStackSize(10), LocDisplayName("Tiny Tinas Treats Canvas")]
    public partial class TTTCanvasItem : WorldObjectItem<TTTCanvasObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("An artwork of Tiny Tina's Treats Shop."); } }

        static TTTCanvasItem() { }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 3,
                    TypeForRoomLimit = "Wall Painting",
                    DiminishingReturnPercent = 0.7f
                };
            }
        }
    }

    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class ExcavatorRaceCanvasObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Excavator Race Canvas"); } }

        public Type RepresentedItemType => typeof(ExcavatorRaceCanvasItem);

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(ExcavatorRaceCanvasItem.HousingVal);
        }

        public override void Destroy() { base.Destroy(); }
    }

    [RequiresSkill(typeof(PaintingSkill), 3)]
    public partial class ExcavatorRaceCanvasRecipe : RecipeFamily
    {
        private string rName = "Excavator Race Canvas";
        private Type skillBase = typeof(PaintingSkill);
        private Type ingTalent = typeof(PaintingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) };

        public ExcavatorRaceCanvasRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GreenPaintItem), 1, true),
                    new IngredientElement(typeof(YellowPaintItem), 1, true),
                    new IngredientElement(typeof(GreyPaintItem), 1, true),
                    new IngredientElement(typeof(WhitePaintItem), 1, true),
                    new IngredientElement(typeof(PaintBrushItem), 5, skillBase, ingTalent),
                    new IngredientElement(typeof(PaintPaletteItem), 5, skillBase, ingTalent),
                    new IngredientElement(typeof(EmptyCanvasItem), 1, true),
                },
                 new CraftingElement<ExcavatorRaceCanvasItem>(1f)
            );
            this.ExperienceOnCraft = 2;
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(500f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 15f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ArtStationObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Weight(500)]
    [MaxStackSize(10)]
    [LocDisplayName("Excavator Race Canvas")]
    public partial class ExcavatorRaceCanvasItem : WorldObjectItem<ExcavatorRaceCanvasObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("An artwork about a great Excavator Race."); } }

        static ExcavatorRaceCanvasItem() { }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 3,
                    TypeForRoomLimit = "Wall Painting",
                    DiminishingReturnPercent = 0.7f
                };
            }
        }
    }

    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class StreetLightsCanvasObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Street Lights Canvas"); } }

        public Type RepresentedItemType => typeof(StreetLightsCanvasItem);

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(StreetLightsCanvasItem.HousingVal);
        }

        public override void Destroy() { base.Destroy(); }
    }

    [RequiresSkill(typeof(PaintingSkill), 4)]
    public partial class StreetLightsCanvasRecipe : RecipeFamily
    {
        private string rName = "Street Lights Canvas";
        private Type skillBase = typeof(PaintingSkill);
        private Type ingTalent = typeof(PaintingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) };

        public StreetLightsCanvasRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GreenPaintItem), 1, true),
                    new IngredientElement(typeof(GreyPaintItem), 1, true),
                    new IngredientElement(typeof(BluePaintItem), 1, true),
                    new IngredientElement(typeof(YellowPaintItem), 1, true),
                    new IngredientElement(typeof(PaintBrushItem), 5, skillBase, ingTalent),
                    new IngredientElement(typeof(PaintPaletteItem), 5, skillBase, ingTalent),
                    new IngredientElement(typeof(EmptyCanvasItem), 1, true),
                },
                 new CraftingElement<StreetLightsCanvasItem>(1f)
            );
            this.ExperienceOnCraft = 2;
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(500f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 15f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ArtStationObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Weight(500)]
    [MaxStackSize(10)]
    [LocDisplayName("Street Lights Canvas")]
    public partial class StreetLightsCanvasItem : WorldObjectItem<StreetLightsCanvasObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("An artwork of street lights."); } }

        static StreetLightsCanvasItem() { }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 3,
                    TypeForRoomLimit = "Wall Painting",
                    DiminishingReturnPercent = 0.7f
                };
            }
        }
    }
}
