using System;
using System.Collections.Generic;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Housing.PropertyValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Housing.Furniture
{
    [Serialized, Weight(600), LocDisplayName("Bedroom Chest")]
    [MaxStackSize(100)]
    public partial class BedroomChestItem : WorldObjectItem<BedroomChestObject>, IConfigurableHousing
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Chest For Storing your personal items.");

        private static readonly HousingModel defaults = new(
            typeof(BedroomChestItem),
            "Bedroom Chest",
            HomeFurnishingValue.RoomCategory.Bedroom,
            skillValue: 2,
            typeForRoomLimit: "Storage",
            diminishingReturn: 0.2f);

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren] public static HomeFurnishingValue HousingVal => EMHousingResolver.Obj.ResolveHomeValue(typeof(BedroomChestItem));

        static BedroomChestItem() => EMHousingResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class BedroomChestRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BedroomChestRecipe).Name,
            Assembly = typeof(BedroomChestRecipe).AssemblyQualifiedName,
            HiddenName = "Bedroom Chest",
            LocalizableName = Localizer.DoStr("Bedroom Chest"),
            IngredientList = new()
            {
                new EMIngredient("Lumber", true, 25),
                new EMIngredient("ClothItem", false, 20),
                new EMIngredient("LeatherHideItem", false, 10)
            },
            ProductList = new()
            {
                new EMCraftable("BedroomChestItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "TailoringTableItem",
            RequiredSkillType = typeof(TailoringSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(TailoringLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent) },
        };

        static BedroomChestRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BedroomChestRecipe()
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
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class BedroomChestObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Bedroom Chest");
        public virtual Type RepresentedItemType => typeof(BedroomChestItem);

        static BedroomChestObject()
        {
            AddOccupancy<BedroomChestObject>(new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i( 0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            });
        }

        protected override void Initialize()
        {
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(32);
            storage.Storage.AddInvRestriction(new NotCarriedRestriction()); // can't store block or large items

            this.GetComponent<HousingComponent>().HomeValue = BedroomChestItem.HousingVal;

            base.PostInitialize();
        }

        public override void Destroy() => base.Destroy();
    }
}