using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Components.Storage;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Housing.PropertyValues;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Housing.Furniture
{
    [Serialized]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]

    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class KitchenCabinetObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Kitchen Cabinet");

        public virtual Type RepresentedItemType => typeof(KitchenCabinetItem);

        static KitchenCabinetObject()
        {
            WorldObject.AddOccupancy<KitchenCabinetObject>(new List<BlockOccupancy>()
            {
                    new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i( 0, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i( 0, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            });
        }

        protected override void Initialize()
        {
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(40);
            storage.Storage.AddInvRestriction(new NotCarriedRestriction()); // can't store block or large items
            this.GetComponent<HousingComponent>().HomeValue = KitchenCabinetItem.HousingVal;
            this.GetComponent<LinkComponent>().Initialize(9);

            base.PostInitialize();
        }

    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(600)]
    [LocDisplayName("Kitchen Cabinet")]
    [Tag("Housing")]
    [LocDescription("A Cabinet for storing food in in your kitchen.")]
    public partial class KitchenCabinetItem : WorldObjectItem<KitchenCabinetObject>, IConfigurableHousing
    {        
        private static readonly HousingModel defaults = new(
        typeof(KitchenCabinetItem),
        "Kitchen Cabinet",
        RoomCategory.Kitchen,
        skillValue: 3,
        typeForRoomLimit: "Food Storage",
        diminishingReturn: 0.1f);

        public override HomeFurnishingValue HomeValue => HousingVal;
        
        public static HomeFurnishingValue HousingVal => EMHousingResolver.Obj.ResolveHomeValue(typeof(KitchenCabinetItem));

        static KitchenCabinetItem() => EMHousingResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CarpentrySkill), 2)]
    public partial class KitchenCabinetRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(KitchenCabinetRecipe).Name,
            Assembly = typeof(KitchenCabinetRecipe).AssemblyQualifiedName,
            HiddenName = "Kitchen Cabinet",
            LocalizableName = Localizer.DoStr("Kitchen Cabinet"),
            IngredientList = new()
            {
                new EMIngredient("Lumber", true, 30),
                new EMIngredient("Fabric", true, 10),
                new EMIngredient("LeatherHideItem", false, 5)
            },
            ProductList = new()
            {
                new EMCraftable("KitchenCabinetItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "CarpentryTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static KitchenCabinetRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public KitchenCabinetRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}