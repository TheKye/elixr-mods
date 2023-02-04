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
using System.Linq;

namespace Eco.EM.Machines.Trucking
{
    [Serialized, Weight(200), MaxStackSize(50), LocDisplayName("Logging Trailer")]
    public partial class LoggingTrailerItem : WorldObjectItem<LoggingTrailerObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Logging Trailer");
        public override DirectionAxisFlags RequiresSurfaceOnSides { get; } = 0 | DirectionAxisFlags.Down;
    }

    [RequiresSkill(typeof(IndustrySkill), 7)]
    public partial class LoggingTrailerRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LoggingTrailerRecipe).Name,
            Assembly = typeof(LoggingTrailerRecipe).AssemblyQualifiedName,
            HiddenName = "Logging Trailer",
            LocalizableName = Localizer.DoStr("Logging Trailer"),
            IngredientList = new()
            {
                new EMIngredient("SteelPlateItem", false, 120),
                new EMIngredient("RivetItem", false, 80),
                new EMIngredient("RubberWheelItem", false, 8, true),
                new EMIngredient("SteelAxleItem", false, 3, true),

            },
            ProductList = new()
            {
                new EMCraftable("LoggingTrailerItem"),
            },
            CraftingStation = "RoboticAssemblyLineItem",
            RequiredSkillType = typeof(IndustrySkill),
            RequiredSkillLevel = 7,
            SpeedImprovementTalents = new Type[] { typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent) }
        };

        static LoggingTrailerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LoggingTrailerRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(SemiTrailerRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class LoggingTrailerObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Logging Trailer");
        public Type RepresentedItemType => typeof(LoggingTrailerItem);

        static LoggingTrailerObject()
        {
            AddOccupancy<LoggingTrailerObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
            });
        }

        protected override void Initialize() { }


    }
}
