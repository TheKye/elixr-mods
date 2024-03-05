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

namespace Eco.EM.Housing.Furniture
{
    [Serialized, Weight(500), MaxStackSize(50), LocDisplayName("Lava Rug")]
    [Tag("Housing")]
    [LocDescription("The floor is lava!!")]
    public partial class LavaRugItem : WorldObjectItem<LavaRugObject>, IConfigurableHousing
    {
        private static readonly HousingModel defaults = new(
        typeof(LavaRugItem),
        "Lava Rug",
        RoomCategory.LivingRoom,
        skillValue: 3,
        typeForRoomLimit: "Rug",
        diminishingReturn: 0.1f);

        public override HomeFurnishingValue HomeValue => HousingVal;
       
        public static HomeFurnishingValue HousingVal => EMHousingResolver.Obj.ResolveHomeValue(typeof(LavaRugItem));

        static LavaRugItem() => EMHousingResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class LavaRugRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LavaRugRecipe).Name,
            Assembly = typeof(LavaRugRecipe).AssemblyQualifiedName,
            HiddenName = "Lava Rug",
            LocalizableName = Localizer.DoStr("Lava Rug"),
            IngredientList = new()
            {
                new EMIngredient("Rock", true, 40),
                new EMIngredient("NaturalFiber", true, 30),
                new EMIngredient("Fabric", true, 15),
            },
            ProductList = new()
            {
                new EMCraftable("LavaRugItem"),
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

        static LavaRugRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LavaRugRecipe()
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
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]

    public partial class LavaRugObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Lava Rug");
        public Type RepresentedItemType => typeof(LavaRugItem);

        static LavaRugObject() { }

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().HomeValue = LavaRugItem.HousingVal;
        }

    }
}