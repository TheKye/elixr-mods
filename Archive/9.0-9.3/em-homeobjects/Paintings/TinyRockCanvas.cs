using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Tooltip;
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
    public partial class TinyRockFarmCanvasObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tiny Rock Farm Canvas"); } }

        public Type RepresentedItemType => typeof(TinyRockFarmCanvasItem);

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(TinyRockFarmCanvasItem.HousingVal);
        }

        public override void Destroy() => base.Destroy();
    }

    [RequiresSkill(typeof(PaintingSkill), 3)]
    public partial class TinyRockFarmCanvasRecipe : RecipeFamily
    {
        private string rName = "Tiny Rock Farm Canvas";
        private Type skillBase = typeof(PaintingSkill);
        private Type ingTalent = typeof(PaintingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) };

        public TinyRockFarmCanvasRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GreenPaintItem), 1, true),
                    new IngredientElement(typeof(BrownPaintItem), 1, true),
                    new IngredientElement(typeof(BluePaintItem), 1, true),
                    new IngredientElement(typeof(BlackPaintItem), 1, true),
                    new IngredientElement(typeof(PaintBrushItem), 5, skillBase, ingTalent),
                    new IngredientElement(typeof(PaintPaletteItem), 5, skillBase, ingTalent),
                    new IngredientElement(typeof(EmptyCanvasItem), 1, true),
                },
                 new CraftingElement<TinyRockFarmCanvasItem>(1f)
            );
            this.ExperienceOnCraft = 2;
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(300f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 10f, skillBase, speedTalents);
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
    [LocDisplayName("Tiny Rock Farm Canvas")]
    [MaxStackSize(10)]
    public partial class TinyRockFarmCanvasItem : WorldObjectItem<TinyRockFarmCanvasObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("An artwork of Tiny Rock Farm."); } }

        static TinyRockFarmCanvasItem() { }

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