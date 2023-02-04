using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Furniture
{
    [Serialized, Weight(500), MaxStackSize(50), LocDisplayName("Lava Rug")]
    [Tag("Housing", 1)]
    public partial class LavaRugItem : WorldObjectItem<LavaRugObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("The floor is lava!!.");

        [TooltipChildren] public HousingValue HousingTooltip => HousingVal;
        [TooltipChildren] public static HousingValue HousingVal => new HousingValue() { Category = HousingValue.RoomCategory.General, Val = 3, TypeForRoomLimit = "Rug", DiminishingReturnPercent = 0.8f };
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class LavaRugRecipe : RecipeFamily
    {
        private string rName = "Lava Rug";
        private Type skillBase = typeof(TailoringSkill);
        private Type ingTalent = typeof(TailoringLavishResourcesTalent);
        private Type[] speedTalents = { typeof(TailoringParallelSpeedTalent), typeof(TailoringFocusedSpeedTalent) };

        public LavaRugRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Rock", 40, skillBase, ingTalent),
                    new IngredientElement("NaturalFiber", 30, skillBase, ingTalent),
                    new IngredientElement(typeof(ClothItem), 15, skillBase, ingTalent),                    
                },
                 new CraftingElement<LavaRugItem>(1f)
            );
            this.ExperienceOnCraft = 2;
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(300f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 10f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
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
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class LavaRugObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Lava Rug");
        public Type RepresentedItemType => typeof(LavaRugItem);

        static LavaRugObject() { }

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(LavaRugItem.HousingVal);
        }

        public override void Destroy() => base.Destroy();
    }
}