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
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class DualArrowObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Dual Arrow");
        public virtual Type RepresentedItemType => typeof(DualArrowItem);

        protected override void Initialize() { }


    }

    [Serialized, Weight(10), MaxStackSize(500), LocDisplayName("Dual Arrow")]
    public partial class DualArrowItem : WorldObjectItem<DualArrowObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("An arrow for directing traffic.");
        public override DirectionAxisFlags RequiresSurfaceOnSides { get; } = 0 | DirectionAxisFlags.Down;
        static DualArrowItem() { }
    }

    [RequiresSkill(typeof(TailoringSkill), 1)]
    public partial class DualArrowRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(DualArrowRecipe).Name,
            Assembly = typeof(DualArrowRecipe).AssemblyQualifiedName,
            HiddenName = "Dual Arrow",
            LocalizableName = Localizer.DoStr("Dual Arrow"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5),
            },
            ProductList = new()
            {
                new EMCraftable("DualArrowItem"),
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
            SpeedImprovementTalents = new Type[] { typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent) },
        };

        static DualArrowRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public DualArrowRecipe()
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