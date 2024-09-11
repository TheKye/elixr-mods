using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Gameplay.Housing.PropertyValues;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Occupancy;

namespace Eco.EM.Housing.Furniture
{
    [Serialized, Weight(200), MaxStackSize(50), LocDisplayName("Fake Plant Square")]
    [Tag("Housing")]
    [LocDescription("Sometimes you just don't want the real nature inside your house.")]
    public partial class FakePlantSquareItem : WorldObjectItem<FakePlantSquareObject>, IConfigurableHousing
    {
        
        private static readonly HousingModel defaults = new(
        typeof(FakePlantSquareItem),
        "Fake Plant Square",
        RoomCategory.LivingRoom,
        skillValue: 2,
        typeForRoomLimit: "Decoration",
        diminishingReturn: 0.1f);

        public override HomeFurnishingValue HomeValue => HousingVal;
        public static HomeFurnishingValue HousingVal => EMHousingResolver.Obj.ResolveHomeValue(typeof(FakePlantSquareItem));
        static FakePlantSquareItem() => EMHousingResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class FakePlantSquareRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(FakePlantSquareRecipe).Name,
            Assembly = typeof(FakePlantSquareRecipe).AssemblyQualifiedName,
            HiddenName = "Fake Plant Square",
            LocalizableName = Localizer.DoStr("Fake Plant Square"),
            IngredientList = new()
            {
                new EMIngredient("DirtItem", false, 1),
                new EMIngredient("PlantFibersItem", false, 25),
                new EMIngredient("ClothItem", false, 15),
                new EMIngredient("PlanterPotSquareItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("FakePlantSquareItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 300,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "TailoringTableItem",
            RequiredSkillType = typeof(TailoringSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(TailoringLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(TailoringParallelSpeedTalent), typeof(TailoringFocusedSpeedTalent) },
        };

        static FakePlantSquareRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public FakePlantSquareRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]

    public partial class FakePlantSquareObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Fake Plant");
        public Type RepresentedItemType => typeof(FakePlantSquareItem);

        static FakePlantSquareObject()
        {
            AddOccupancy<FakePlantSquareObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
            });
        }

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().HomeValue = FakePlantSquareItem.HousingVal;
        }

    }
}
