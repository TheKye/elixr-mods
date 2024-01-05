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
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Items.Recipes;

namespace Eco.EM.Building.Windows
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [Wall, Solid]
    public partial class SlidingWindowLongWoodObject : WindowObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Long Wood Sliding Window");
        public virtual Type RepresentedItemType => typeof(SlidingWindowLongWoodItem);

        public override bool HasTier => true;
        public override int Tier => 3;

        protected override void Initialize() { }

        static SlidingWindowLongWoodObject()
        {
            AddOccupancy<SlidingWindowLongWoodObject>(new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i(0, 0,  0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            });
        }


    }

    [Serialized]
    [Tier(2)]
    [Weight(600)]
    [Wall, Solid]
    [LocDisplayName("Long Wood Sliding Window")]
    [LocDescription("A horizontal sliding window made out of wood and glass. Could be used as a shop window?")]
    public partial class SlidingWindowLongWoodItem : WorldObjectItem<SlidingWindowLongWoodObject>
    {
        static SlidingWindowLongWoodItem() { }
    }

    [RequiresSkill(typeof(CarpentrySkill), 0)]
    public partial class SlidingWindowLongWoodRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SlidingWindowLongWoodRecipe).Name,
            Assembly = typeof(SlidingWindowLongWoodRecipe).AssemblyQualifiedName,
            HiddenName = "Long Wood Sliding Window",
            LocalizableName = Localizer.DoStr("Long Wood Sliding Window"),
            IngredientList = new()
            {
                new EMIngredient("WoodBoard", true, 10),
                new EMIngredient("GlassItem", false, 4)
            },
            ProductList = new()
            {
                new EMCraftable("SlidingWindowLongWoodItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static SlidingWindowLongWoodRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SlidingWindowLongWoodRecipe()
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