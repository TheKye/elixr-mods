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

namespace Eco.EM.Building.Roadworking
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class WaterTankWhiteBarrierObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("White Water Tank Barrier");
        public virtual Type RepresentedItemType => typeof(WaterTankWhiteBarrierItem);

        protected override void Initialize() { }

        static WaterTankWhiteBarrierObject()
        {
            AddOccupancy<WaterTankWhiteBarrierObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(-1, 0, 0)),
            });
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(600), LocDisplayName("White Water Tank Barrier"), MaxStackSize(100)]
    public partial class WaterTankWhiteBarrierItem : WorldObjectItem<WaterTankWhiteBarrierObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A White Water Tank Type Barrier.");

        static WaterTankWhiteBarrierItem() { }
    }

    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class WaterTankWhiteBarrierRecipe : RecipeFamily, IConfigurableRecipe
    {

        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WaterTankWhiteBarrierRecipe).Name,
            Assembly = typeof(WaterTankWhiteBarrierRecipe).AssemblyQualifiedName,
            HiddenName = "White Water Tank Barrier",
            LocalizableName = Localizer.DoStr("White Water Tank Barrier"),
            IngredientList = new()
            {
                new EMIngredient("CementItem", false, 5),
            },
            ProductList = new()
            {
                new EMCraftable("WaterTankWhiteBarrierItem"),
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

        static WaterTankWhiteBarrierRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WaterTankWhiteBarrierRecipe()
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