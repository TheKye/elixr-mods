using System;
using System.Collections.Generic;
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
using Eco.Gameplay.Housing.PropertyValues;
using Eco.EM.Framework.Resolvers;
using Eco.Core.Items;

namespace Eco.EM.Housing.Furniture
{
    [Serialized, Weight(600), LocDisplayName("Bedroom Small Dresser"), MaxStackSize(100)]
    [Tag("Housing", 1)]
    public partial class BedroomSmallDresserItem : WorldObjectItem<BedroomSmallDresserObject>, IConfigurableHousing
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Small Dresser for Storing your Clothes");
        public override DirectionAxisFlags RequiresSurfaceOnSides { get; } = 0 | DirectionAxisFlags.Down;
        private static readonly HousingModel defaults = new(
        typeof(BedroomSmallDresserItem),
        "Bedroom Small Dresser",
        RoomCategory.Bedroom.Name,
        skillValue: 3,
        typeForRoomLimit: "Storage",
        diminishingReturn: 0.3f);

        public override HomeFurnishingValue HomeValue => HousingVal;
        public static HomeFurnishingValue HousingVal => EMHousingResolver.Obj.ResolveHomeValue(typeof(BedroomSmallDresserItem));

        static BedroomSmallDresserItem() => EMHousingResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class BedroomSmallDresserRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BedroomSmallDresserRecipe).Name,
            Assembly = typeof(BedroomSmallDresserRecipe).AssemblyQualifiedName,
            HiddenName = "Bedroom Small Dresser",
            LocalizableName = Localizer.DoStr("Bedroom Small Dresser"),
            IngredientList = new()
            {
                new EMIngredient("Lumber", true, 25),
                new EMIngredient("ClothItem", false, 20)
            },
            ProductList = new()
            {
                new EMCraftable("BedroomSmallDresserItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "TailoringTableItem",
            RequiredSkillType = typeof(TailoringSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(TailoringLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent) },
        };

        static BedroomSmallDresserRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BedroomSmallDresserRecipe()
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
    public partial class BedroomSmallDresserObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Bedroom Small Dresser");
        public virtual Type RepresentedItemType => typeof(BedroomSmallDresserItem);

        static BedroomSmallDresserObject()
        {
            AddOccupancy<BedroomSmallDresserObject>(new List<BlockOccupancy>()
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
            this.GetComponent<HousingComponent>().HomeValue = BedroomSmallDresserItem.HousingVal;

            base.PostInitialize();
        }

    }
}