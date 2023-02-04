using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Property;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Furniture
{
    [Serialized, Weight(500) ,LocDisplayName("Stone Table"), MaxStackSize(50)]
    public partial class StoneTableItem : WorldObjectItem<StoneTableObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A stone table for placing things on");

        [TooltipChildren] public HousingValue HousingTooltip => HousingVal; 
        [TooltipChildren] public static HousingValue HousingVal => new HousingValue() {Category = HousingValue.RoomCategory.General, Val = 2,TypeForRoomLimit = "Table",DiminishingReturnPercent = 0.75f};
    }


    [RequiresSkill(typeof(MasonrySkill), 2)]
    public partial class StoneTableRecipe : RecipeFamily
    {
        private string rName = "Stone Table";
        private Type skillBase = typeof(MasonrySkill);
        private Type ingTalent = typeof(MasonryLavishResourcesTalent);
        private Type[] speedTalents = { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) };

        public StoneTableRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(SandItem), 15, skillBase, ingTalent),
                    new IngredientElement("Rock", 30, skillBase, ingTalent),
                },
                 new CraftingElement<StoneTableItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(200f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 5f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KilnObject), this);        
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
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(8)]
    [RequireRoomMaterialTier(1)]
    public partial class StoneTableObject : WorldObject
    {
        static StoneTableObject()
        {
            AddOccupancy<StoneTableObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(-1, 0, 0)),
            });
        }

        public override LocString DisplayName => Localizer.DoStr("Stone Table");

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(StoneTableItem.HousingVal);
        }

        public override void Destroy() => base.Destroy();
    }
}
