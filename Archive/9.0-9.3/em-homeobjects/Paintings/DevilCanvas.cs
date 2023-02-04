using System;
using System.Collections.Generic;
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
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Artistry
{
    [Serialized, Weight(600), LocDisplayName("Devil Canvas")]
    [MaxStackSize(10)]
    public partial class DevilCanvasItem : WorldObjectItem<DevilCanvasObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("An artwork of a hellish devil.");

        [TooltipChildren] public HousingValue HousingTooltip => HousingVal;
        [TooltipChildren] public static HousingValue HousingVal => new HousingValue() 
        {
            Category = HousingValue.RoomCategory.General,
            Val = 5,
            TypeForRoomLimit = "Wall Painting",
            DiminishingReturnPercent = 0.9f
        };
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class DevilCanvasRecipe : RecipeFamily
    {
        private string rName = "Devil Canvas";
        private Type skillBase = typeof(PaintingSkill);
        private Type ingTalent = typeof(PaintingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) };

        public DevilCanvasRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    rName,
                    Localizer.DoStr(rName),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(BlackPaintItem), 6, true),
                        new IngredientElement(typeof(RedPaintItem), 6, true),
                        new IngredientElement(typeof(YellowPaintItem), 1, true),
                        new IngredientElement(typeof(WhitePaintItem), 3, true),
                        new IngredientElement(typeof(PaintBrushItem), 5, skillBase, ingTalent),
                        new IngredientElement(typeof(PaintPaletteItem), 5, skillBase, ingTalent),
                        new IngredientElement(typeof(EmptyCanvasItem), 4, true),
                    },
                    new CraftingElement<DevilCanvasItem>()
                    )
            };
            this.ExperienceOnCraft = 2;
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
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class DevilCanvasObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Devil Canvas");
        public virtual Type RepresentedItemType => typeof(DevilCanvasItem);

        static DevilCanvasObject()
        {
            AddOccupancy<DevilCanvasObject>(new List<BlockOccupancy>()
                {
                    new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                });
        }

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(DevilCanvasItem.HousingVal);
        }

        public override void Destroy() => base.Destroy();
    }
}
