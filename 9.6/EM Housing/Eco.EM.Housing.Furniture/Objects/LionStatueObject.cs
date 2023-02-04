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
using Eco.Gameplay.Housing.PropertyValues;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Housing.Furniture
{
    [Serialized, Weight(500), MaxStackSize(50), LocDisplayName("Lion Statue")]
    [Tag("Housing", 1)]
    public partial class LionStatueItem : WorldObjectItem<LionStatueObject>, IConfigurableHousing
    {
        public override LocString DisplayDescription => Localizer.DoStr("What's more gauche than a giant cement lion?");
        public override DirectionAxisFlags RequiresSurfaceOnSides { get; } = 0 | DirectionAxisFlags.Down;
        private static readonly HousingModel defaults = new(
        typeof(LionStatueItem),
        "Lion Statue",
        "Decoration",
        skillValue: 2,
        typeForRoomLimit: "Decoration",
        diminishingReturn: 0.1f);

        public override HomeFurnishingValue HomeValue => HousingVal;
        
        public static HomeFurnishingValue HousingVal => EMHousingResolver.Obj.ResolveHomeValue(typeof(LionStatueItem));
        static LionStatueItem() => EMHousingResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(MasonrySkill), 2)]
    public partial class LionStatueRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LionStatueRecipe).Name,
            Assembly = typeof(LionStatueRecipe).AssemblyQualifiedName,
            HiddenName = "Lion Statue",
            LocalizableName = Localizer.DoStr("Lion Statue"),
            IngredientList = new()
            {
                new EMIngredient("Rock", true, 40),
                new EMIngredient("ClothItem", false, 15),
                new EMIngredient("PlanterPotSquareItem", false, 1),
            },
            ProductList = new()
            {
                new EMCraftable("LionStatueItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 300,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "MasonryTableItem",
            RequiredSkillType = typeof(MasonrySkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static LionStatueRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LionStatueRecipe()
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
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class LionStatueObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Lion Statue");
        public Type RepresentedItemType => typeof(LionStatueItem);

        static LionStatueObject()
        {
            AddOccupancy<LionStatueObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 0, -1)),
            });
        }

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().HomeValue = LionStatueItem.HousingVal;
        }

    }
}

