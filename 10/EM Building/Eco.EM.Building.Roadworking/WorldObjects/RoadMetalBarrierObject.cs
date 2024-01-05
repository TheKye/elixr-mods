using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using Eco.Shared.Localization;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;
using Eco.Shared.Math;

namespace Eco.EM.Building.Roadworking
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]

    public partial class RoadMetalBarrierObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Metal Barrier");
        public virtual Type RepresentedItemType => typeof(RoadMetalBarrierItem);

        protected override void Initialize() { }



        static RoadMetalBarrierObject()
        {
            AddOccupancy<RoadMetalBarrierObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(-1, 0, 0)),
            });
        }
    }

    [Serialized, Weight(600), LocDisplayName("Metal Barrier"), MaxStackSize(100)]
    public partial class RoadMetalBarrierItem : WorldObjectItem<RoadMetalBarrierObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Metal Barrier To Work as A Boundry.");
        

        static RoadMetalBarrierItem() { }
    }

    [RequiresSkill(typeof(SmeltingSkill), 3)]
    public partial class RoadMetalBarrierRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RoadMetalBarrierRecipe).Name,
            Assembly = typeof(RoadMetalBarrierRecipe).AssemblyQualifiedName,
            HiddenName = "Metal Barrier",
            LocalizableName = Localizer.DoStr("Metal Barrier"),
            IngredientList = new()
            {
                new EMIngredient("IronBarItem", false, 10),
            },
            ProductList = new()
            {
                new EMCraftable("RoadMetalBarrierItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "AnvilItem",
            RequiredSkillType = typeof(SmeltingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(SmeltingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent) },
        };

        static RoadMetalBarrierRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RoadMetalBarrierRecipe()
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