using System;
using System.Collections.Generic;
using Eco.EM.Artistry.UnityImageLoader;
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

namespace Eco.EM.Artistry
{
    [Serialized, Weight(600), LocDisplayName("Custom Canvas")]
    public partial class CustomCanvasItem : WorldObjectItem<CustomCanvasObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Blank Canvas Used to render Outside images on");
        [TooltipChildren] public HousingValue HousingTooltip => HousingVal;
        [TooltipChildren] public static HousingValue HousingVal => new HousingValue() { Category = HousingValue.RoomCategory.General, Val = 2, TypeForRoomLimit = "Wall Painting", DiminishingReturnPercent = 0.75f };
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public class CustomCanvasRecipe : RecipeFamily
    {
        private string rName = "Custom Canvas";
        private Type skillBase = typeof(PaintingSkill);
        private Type ingTalent = typeof(PaintingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) };

        public CustomCanvasRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    rName,
                    Localizer.DoStr(rName),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(BlackPaintItem), 2, true),
                        new IngredientElement(typeof(BluePaintItem), 8, true),
                        new IngredientElement(typeof(WhitePaintItem), 6, true),
                        new IngredientElement(typeof(PaintBrushItem), 5, skillBase, ingTalent),
                        new IngredientElement(typeof(PaintPaletteItem), 5, skillBase, ingTalent),
                        new IngredientElement("Wood", 4, true),
                        new IngredientElement(typeof(ClothItem), 5)
                    },
                    new CraftingElement<CustomCanvasItem>()
                    )
                };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(500f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 15f, skillBase, speedTalents);
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            CraftingComponent.AddRecipe(typeof(ArtStationObject), this);
        }
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class CustomCanvasObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Custom Canvas");
        public virtual Type RepresentedItemType => typeof(CustomCanvasItem);

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(CustomCanvasItem.HousingVal);
            GetComponent<CustomTextComponent>().Initialize();
        }

        public override void Destroy() { base.Destroy(); }
    }
}