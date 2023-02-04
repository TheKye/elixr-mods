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
    [Serialized, Weight(500), LocDisplayName("The End Canvas")]
    [MaxStackSize(10)]
    public partial class TheEndCanvasItem : WorldObjectItem<TheEndCanvasObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("An artwork of the possible end.");

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal => new HousingValue() { Category = HousingValue.RoomCategory.General, Val = 3, TypeForRoomLimit = "Wall Painting", DiminishingReturnPercent = 0.75f };
    }

    [RequiresSkill(typeof(PaintingSkill), 4)]
    public partial class TheEndCanvasRecipe : RecipeFamily
    {
        private string rName = "The End Canvas";
        private Type skillBase = typeof(PaintingSkill);
        private Type ingTalent = typeof(PaintingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) };

        public TheEndCanvasRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(YellowPaintItem), 1, true),
                    new IngredientElement(typeof(OrangePaintItem), 2, true),
                    new IngredientElement(typeof(BluePaintItem), 1, true),
                    new IngredientElement(typeof(PaintBrushItem), 5, skillBase, ingTalent),
                    new IngredientElement(typeof(PaintPaletteItem), 5, skillBase, ingTalent),
                    new IngredientElement(typeof(EmptyCanvasItem), 1, true),
                },
                 new CraftingElement<TheEndCanvasItem>(1f)
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
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class TheEndCanvasObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("The End Canvas"); } }
        public Type RepresentedItemType => typeof(TheEndCanvasItem);

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(TheEndCanvasItem.HousingVal);
        }

        public override void Destroy() => base.Destroy();
    }
}