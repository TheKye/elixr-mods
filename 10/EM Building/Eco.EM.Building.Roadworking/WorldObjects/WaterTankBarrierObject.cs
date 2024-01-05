using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Shared.Localization;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Items.Recipes;

namespace Eco.EM.Building.Roadworking
{

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class WaterTankBarrierObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Water Tank Barrier");

        public virtual Type RepresentedItemType => typeof(WaterTankBarrierItem);
        protected override void Initialize() { }

        static WaterTankBarrierObject()
        {
            AddOccupancy<WaterTankBarrierObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(-1, 0, 0)),
            });
        }


    }

    [Serialized, Weight(600), LocDisplayName("Water Tank Barrier"), MaxStackSize(100)]
    [LocDescription("A Water Tank Style Barrier.")]
    public partial class WaterTankBarrierItem : WorldObjectItem<WaterTankBarrierObject>
    {
        
        static WaterTankBarrierItem() { }
    }

    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class WaterTankBarrierRecipe : RecipeFamily, IConfigurableRecipe
    {

        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WaterTankBarrierRecipe).Name,
            Assembly = typeof(WaterTankBarrierRecipe).AssemblyQualifiedName,
            HiddenName = "Water Tank Barrier",
            LocalizableName = Localizer.DoStr("Water Tank Barrier"),
            IngredientList = new()
            {
                new EMIngredient("CementItem", false, 5),
            },
            ProductList = new()
            {
                new EMCraftable("WaterTankBarrierItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "CementKilnItem",
            RequiredSkillType = typeof(MasonrySkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent) },
        };

        static WaterTankBarrierRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WaterTankBarrierRecipe()
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