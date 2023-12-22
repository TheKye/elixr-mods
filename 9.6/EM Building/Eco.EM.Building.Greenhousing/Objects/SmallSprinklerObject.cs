using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Pipes.LiquidComponents;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Building.Greenhousing
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SprinklerComponent))]
    [RequireComponent(typeof(LiquidConsumerComponent))]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(StatusComponent))]
    public partial class SmallSprinklerObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Small Sprinkler");

        public virtual Type RepresentedItemType => typeof(SmallSprinklerItem);

        static SmallSprinklerObject()
        {
            AddOccupancy<SmallSprinklerObject>(new List<BlockOccupancy>()
            {
            new BlockOccupancy(new Vector3i(0, -1, 0)),
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(PipeSlotBlock), new Quaternion(-0.7071071f, 2.634177E-07f, 2.634179E-07f, 0.7071065f), BlockOccupancyType.WaterInputPort)
            });
        }

        protected override void Initialize()
        {
            this.GetComponent<SprinklerComponent>().Initialize(6);
        }

        protected override void PostInitialize()
        {
            this.GetComponent<LiquidConsumerComponent>().Setup(typeof(WaterItem), 0.3f, BlockOccupancyType.WaterInputPort, 0.3f);
            base.PostInitialize();
        }

        public override void Tick()
        {
            base.Tick();
            SetAnimatedState("Water", this.Operating);
        }
    }

    [Serialized, LocDisplayName("Small Sprinkler")]
    [LocDescription("Small Sprinkler, Required for a greenhouse to work. Provides necessary water for plants")]
    public partial class SmallSprinklerItem : WorldObjectItem<SmallSprinklerObject>
    {
        
    }

    [RequiresSkill(typeof(BasicEngineeringSkill), 1)]
    public partial class SmallSprinklerRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SmallSprinklerRecipe).Name,
            Assembly = typeof(SmallSprinklerRecipe).AssemblyQualifiedName,
            HiddenName = "Small Sprinkler",
            LocalizableName = Localizer.DoStr("Small Sprinkler"),
            IngredientList = new()
            {
                new EMIngredient("IronPipeItem", false, 1),
                new EMIngredient("IronBarItem", false, 1),
            },
            ProductList = new()
            {
                new EMCraftable("SmallSprinklerItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "WainwrightTableItem",
            RequiredSkillType = typeof(BasicEngineeringSkill),
            RequiredSkillLevel = 5,
            IngredientImprovementTalents = typeof(BasicEngineeringLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(BasicEngineeringParallelSpeedTalent), typeof(BasicEngineeringFocusedSpeedTalent) },
        };

        static SmallSprinklerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SmallSprinklerRecipe()
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
