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
using Eco.Gameplay.Housing.PropertyValues;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Housing.Furniture
{
    [Serialized, Weight(500) ,LocDisplayName("Stone Table"), MaxStackSize(50)]
    public partial class StoneTableItem : WorldObjectItem<StoneTableObject>, IConfigurableHousing
    {
        public override LocString DisplayDescription => Localizer.DoStr("A stone table for placing things on");

        private static readonly HousingModel defaults = new(
        typeof(StoneTableItem),
        "Stone Table",
        roomType: HomeFurnishingValue.RoomCategory.General,
        skillValue: 2,
        typeForRoomLimit: "Table",
        diminishingReturn: 0.1f);

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren]
        public static HomeFurnishingValue HousingVal => EMHousingResolver.Obj.ResolveHomeValue(typeof(StoneTableItem));

        static StoneTableItem() => EMHousingResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(MasonrySkill), 2)]
    public partial class StoneTableRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(StoneTableRecipe).Name,
            Assembly = typeof(StoneTableRecipe).AssemblyQualifiedName,
            HiddenName = "Stone Table",
            LocalizableName = Localizer.DoStr("Stone Table"),
            IngredientList = new()
            {
                new EMIngredient("SandItem", false, 15),
                new EMIngredient("Rock", true, 30),
            },
            ProductList = new()
            {
                new EMCraftable("StoneTableItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 200,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "KilnItem",
            RequiredSkillType = typeof(MasonrySkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static StoneTableRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public StoneTableRecipe()
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
            this.GetComponent<HousingComponent>().HomeValue  = StoneTableItem.HousingVal;
        }

        public override void Destroy() => base.Destroy();
    }
}
