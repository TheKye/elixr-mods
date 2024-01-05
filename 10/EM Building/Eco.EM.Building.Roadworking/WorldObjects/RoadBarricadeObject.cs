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
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Occupancy;

namespace Eco.EM.Building.Roadworking
{

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]

    public partial class RoadBarricadeObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Road Barricade");
        public virtual Type RepresentedItemType => typeof(RoadBarricadeItem);

        static RoadBarricadeObject()
        {
            AddOccupancy<RoadBarricadeObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(-1, 0, 0)),
            });
        }

        protected override void Initialize() { }


    }

    [Serialized, Weight(5000), MaxStackSize(20), LocDisplayName("Road Barricade")]
    [LocDescription("A Barricade for blocking off roads.")]
    public partial class RoadBarricadeItem : WorldObjectItem<RoadBarricadeObject>
    {
        static RoadBarricadeItem() { }
    }

    [RequiresSkill(typeof(CarpentrySkill), 1)]
    public partial class RoadBarricadeRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RoadBarricadeRecipe).Name,
            Assembly = typeof(RoadBarricadeRecipe).AssemblyQualifiedName,
            HiddenName = "Road Barricade",
            LocalizableName = Localizer.DoStr("Road Barricade"),
            IngredientList = new()
            {
                new EMIngredient("Lumber", true, 10),
            },
            ProductList = new()
            {
                new EMCraftable("RoadBarricadeItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "CarpentryTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static RoadBarricadeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RoadBarricadeRecipe()
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