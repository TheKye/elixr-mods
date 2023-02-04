using System;
using System.Collections.Generic;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Farming
{
    [Serialized]
    [RequireComponent(typeof(StoreComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    public partial class FarmersStandObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Farmers Stand");

        public virtual Type RepresentedItemType => typeof(FarmersStandItem);

        protected override void PostInitialize()
        {
            this.GetComponent<PropertyAuthComponent>().SetPublic();
            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Economy"));
        }

        static FarmersStandObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = -2; x <= 0; x++)
                for (int y = 0; y <= 2; y++)
                    for (int z = -3; z <= 0; z++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, z), typeof(BuildingWorldObjectBlock)));

            AddOccupancy<FarmersStandObject>(BlockOccupancyList);
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(5000)]
    [LocDisplayName("Farmers Stand")]
    public partial class FarmersStandItem : WorldObjectItem<FarmersStandObject>, IPersistentData
    {
        public override LocString DisplayDescription => Localizer.DoStr("Allows the selling and trading of items outdoors.");

        static FarmersStandItem() { }

        [Serialized, TooltipChildren] public object PersistentData { get; set; }
    }

    [RequiresSkill(typeof(CarpentrySkill), 1)]
    public partial class FarmersStandRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(FarmersStandRecipe).Name,
            Assembly = typeof(FarmersStandRecipe).AssemblyQualifiedName,
            HiddenName = "Farmers Stand",
            LocalizableName = Localizer.DoStr("Farmers Stand"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 30, true),
                new EMIngredient("NaturalFiber", true, 30, true),
            },
            ProductList = new()
            {
                new EMCraftable("FarmersStandItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 300,
            LaborIsStatic = false,
            BaseCraftTime = 25,
            CraftTimeIsStatic = false,
            CraftingStation = "WorkbenchItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static FarmersStandRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public FarmersStandRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
