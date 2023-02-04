using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Building.Windows
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [Wall, Solid]
    public partial class SlidingWindowTallMetalObject : WindowObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Tall Metal Sliding Window");
        public virtual Type RepresentedItemType => typeof(SlidingWindowTallMetalItem);

        public override bool HasTier => true;
        public override int Tier => 3;

        protected override void Initialize() { }

        static SlidingWindowTallMetalObject()
        {
            AddOccupancy<SlidingWindowTallMetalObject>(new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            });
        }


    }

    [Serialized]
    [Tier(2)]
    [Weight(600)]
    [LocDisplayName("Tall Metal Sliding Window")]
    [Wall, Solid]
    public partial class SlidingWindowTallMetalItem : WorldObjectItem<SlidingWindowTallMetalObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A vertical sliding window made out of metal and glass.");

        static SlidingWindowTallMetalItem() { }
    }

    [RequiresSkill(typeof(SmeltingSkill), 3)]
    public partial class SlidingWindowTallMetalRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SlidingWindowTallMetalRecipe).Name,
            Assembly = typeof(SlidingWindowTallMetalRecipe).AssemblyQualifiedName,
            HiddenName = "Tall Metal Sliding Window",
            LocalizableName = Localizer.DoStr("Tall Metal Sliding Window"),
            IngredientList = new()
            {
                new EMIngredient("IronBarItem", false, 10),
                new EMIngredient("GlassItem", false, 4)
            },
            ProductList = new()
            {
                new EMCraftable("SlidingWindowTallMetalItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(SmeltingSkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(SmeltingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent) },
        };

        static SlidingWindowTallMetalRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SlidingWindowTallMetalRecipe()
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