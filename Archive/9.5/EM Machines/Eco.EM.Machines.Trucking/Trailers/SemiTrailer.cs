using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Machines.Trucking
{
    [Serialized, Weight(200), MaxStackSize(50), LocDisplayName("Semi Trailer")]
    public partial class SemiTrailerItem : WorldObjectItem<SemiTrailerObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Semi Trailer");
    }

    [RequiresSkill(typeof(IndustrySkill), 7)]
    public partial class SemiTrailerRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SemiTrailerRecipe).Name,
            Assembly = typeof(SemiTrailerRecipe).AssemblyQualifiedName,
            HiddenName = "Semi Trailer",
            LocalizableName = Localizer.DoStr("Semi Trailer"),
            IngredientList = new()
            {
                new EMIngredient("SteelPlateItem", false, 120),
                new EMIngredient("RivetItem", false, 80),
                new EMIngredient("RubberWheelItem", false, 8, true),
                new EMIngredient("SteelAxleItem", false, 3, true),

            },
            ProductList = new()
            {
                new EMCraftable("SemiTrailerItem"),
            },
            BaseExperienceOnCraft = 1f,
            BaseLabor = 2000,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "RoboticAssemblyLineItem",
            RequiredSkillType = typeof(IndustrySkill),
            RequiredSkillLevel = 7,
            SpeedImprovementTalents = new Type[] { typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent) }
        };

        static SemiTrailerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SemiTrailerRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class SemiTrailerObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Semi Trailer");
        public Type RepresentedItemType => typeof(SemiTrailerItem);

        static SemiTrailerObject()
        {
            AddOccupancy<SemiTrailerObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
            });
        }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();
    }
}
