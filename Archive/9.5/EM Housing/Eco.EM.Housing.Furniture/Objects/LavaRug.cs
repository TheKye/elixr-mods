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
    [Serialized, Weight(500), MaxStackSize(50), LocDisplayName("Lava Rug")]
    [Tag("Housing", 1)]
    public partial class LavaRugItem : WorldObjectItem<LavaRugObject>, IConfigurableHousing
    {
        public override LocString DisplayDescription => Localizer.DoStr("The floor is lava!!");

        private static readonly HousingModel defaults = new(
        typeof(LavaRugItem),
        "Lava Rug",
        roomType: HomeFurnishingValue.RoomCategory.General,
        skillValue: 3,
        typeForRoomLimit: "Rug",
        diminishingReturn: 0.1f);

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren]
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
                new EMIngredient("ClothItem", false, 15),
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
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
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
            this.GetComponent<HousingComponent>().HomeValue = LavaRugItem.HousingVal;
        }

        public override void Destroy() => base.Destroy();
    }
}