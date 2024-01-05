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
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Items.Recipes;

namespace Eco.EM.Building.Roadworking
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]

    public partial class BenchObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Bench");

        public virtual Type RepresentedItemType => typeof(BenchItem);

        protected override void Initialize() { }



        static BenchObject()
        {

            AddOccupancy<BenchObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(-1, 0, 0)),
            });
        }

    }

    [Serialized, Weight(6000), LocDisplayName("Park Bench"), MaxStackSize(100)]
    [LocDescription("A Beautiful Parck Bench.")]
    public partial class BenchItem : WorldObjectItem<BenchObject>
    {
        static BenchItem() { }
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class BenchRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BenchRecipe).Name,
            Assembly = typeof(BenchRecipe).AssemblyQualifiedName,
            HiddenName = "Park Bench",
            LocalizableName = Localizer.DoStr("Park Bench"),
            IngredientList = new()
            {
                new EMIngredient("Lumber", true, 20, true),
                new EMIngredient("IronBarItem", false, 4),
                new EMIngredient("RivetItem", false, 20)
            },
            ProductList = new()
            {
                new EMCraftable("BenchItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "SawmillItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static BenchRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BenchRecipe()
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