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
    public partial class TrafficConeObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Traffic Cone");
        public virtual Type RepresentedItemType => typeof(TrafficConeItem);

        static TrafficConeObject()
        {
            AddOccupancy<TrafficConeObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
            });
        }

        protected override void Initialize() { }


    }

    [Serialized, Weight(600), LocDisplayName("Traffic Cone"), MaxStackSize(100)]
    public partial class TrafficConeItem : WorldObjectItem<TrafficConeObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Traffic Cone.");
        public override DirectionAxisFlags RequiresSurfaceOnSides { get; } = 0 | DirectionAxisFlags.Down;
        static TrafficConeItem() { }
    }

    [RequiresSkill(typeof(TailoringSkill), 1)]
    public partial class TrafficConeRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TrafficConeRecipe).Name,
            Assembly = typeof(TrafficConeRecipe).AssemblyQualifiedName,
            HiddenName = "Traffic Cone",
            LocalizableName = Localizer.DoStr("Traffic Cone"),
            IngredientList = new()
            {
                new EMIngredient("NaturalFiber", true, 10),
                new EMIngredient("ClothItem", false, 15)
            },
            ProductList = new()
            {
                new EMCraftable("TrafficConeItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "TailoringTableItem",
            RequiredSkillType = typeof(TailoringSkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(TailoringLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(TailoringParallelSpeedTalent), typeof(TailoringFocusedSpeedTalent) },
        };

        static TrafficConeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TrafficConeRecipe()
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