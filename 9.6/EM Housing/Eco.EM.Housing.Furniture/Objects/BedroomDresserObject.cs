using System;
using System.Collections.Generic;
using Eco.Core.Items;
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
    [Serialized, Weight(600), LocDisplayName("Bedroom Dresser")]
    [MaxStackSize(100)]
    [Tag("Housing", 1)]
    public partial class BedroomDresserItem : WorldObjectItem<BedroomDresserObject>, IConfigurableHousing
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Large Dresser for storing your clothes");
        public override DirectionAxisFlags RequiresSurfaceOnSides { get; } = 0 | DirectionAxisFlags.Down;

        private static readonly HousingModel defaults = new(
            typeof(BedroomDresserItem), 
            "Bedroom Dresser", 
            RoomCategory.Bedroom.Name,
            skillValue: 5, 
            typeForRoomLimit: "Storage", 
            diminishingReturn: 0f);

         public override HomeFurnishingValue HomeValue => HousingVal;
         public static HomeFurnishingValue HousingVal => EMHousingResolver.Obj.ResolveHomeValue(typeof(BedroomDresserItem));

        static BedroomDresserItem() => EMHousingResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(TailoringSkill), 5)]
    public partial class BedroomDresserRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BedroomDresserRecipe).Name,
            Assembly = typeof(BedroomDresserRecipe).AssemblyQualifiedName,
            HiddenName = "Bedroom Dresser",
            LocalizableName = Localizer.DoStr("Bedroom Dresser"),
            IngredientList = new()
            {
                new EMIngredient("Lumber", true, 40),
                new EMIngredient("ClothItem", false, 20)
            },
            ProductList = new()
            {
                new EMCraftable("BedroomDresserItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "TailoringTableItem",
            RequiredSkillType = typeof(TailoringSkill),
            RequiredSkillLevel = 5,
            IngredientImprovementTalents = typeof(TailoringLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent) },
        };

        static BedroomDresserRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BedroomDresserRecipe()
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
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class BedroomDresserObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Bedroom Dresser");
        public virtual Type RepresentedItemType => typeof(BedroomDresserItem);

        static BedroomDresserObject()
        {
            AddOccupancy<BedroomDresserObject>(new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(0, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),

            });
        }

        protected override void Initialize()
        {
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(48);
            storage.Storage.AddInvRestriction(new NotCarriedRestriction()); // can't store block or large items
            this.GetComponent<HousingComponent>().HomeValue = BedroomDresserItem.HousingVal;

            base.PostInitialize();
        }

    }
}