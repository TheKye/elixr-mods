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

    public partial class AheadSignObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Ahead Sign");
        public virtual Type RepresentedItemType => typeof(AheadSignItem);

        static AheadSignObject()
        {
            AddOccupancy<AheadSignObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(0, 2, 0)),
            });
        }

        protected override void Initialize() { }

    }

    [Serialized, Weight(600), LocDisplayName("Ahead Sign"), MaxStackSize(100)]
    public partial class AheadSignItem : WorldObjectItem<AheadSignObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Sign For Something Ahead.");
        

        static AheadSignItem() { }
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class AheadSignRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(AheadSignRecipe).Name,
            Assembly = typeof(AheadSignRecipe).AssemblyQualifiedName,
            HiddenName = "Signs - Ahead Sign",
            LocalizableName = Localizer.DoStr("Signs - Ahead Sign"),
            IngredientList = new()
            {
                new EMIngredient("WoodBoard", true, 8),
                new EMIngredient("IronBarItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("AheadSignItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "AnvilItem",
            RequiredSkillType = typeof(SmeltingSkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(SmeltingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent) },
        };

        static AheadSignRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AheadSignRecipe()
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