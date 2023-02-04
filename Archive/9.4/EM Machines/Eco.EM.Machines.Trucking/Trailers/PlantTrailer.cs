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
    [Serialized, Weight(200), MaxStackSize(50), LocDisplayName("Plant Trailer")]
    public partial class PlantTrailerItem : WorldObjectItem<PlantTrailerObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Plant Trailer");
    }

    [RequiresSkill(typeof(IndustrySkill), 7)]
    public partial class PlantTrailerRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PlantTrailerRecipe).Name,
            Assembly = typeof(PlantTrailerRecipe).AssemblyQualifiedName,
            HiddenName = "Plant Trailer",
            LocalizableName = Localizer.DoStr("Plant Trailer"),
            IngredientList = new()
            {
                new EMIngredient("SteelPlateItem", false, 120),
                new EMIngredient("RivetItem", false, 80),
                new EMIngredient("RubberWheelItem", false, 8, true),
                new EMIngredient("SteelAxleItem", false, 3, true),

            },
            ProductList = new()
            {
                new EMCraftable("PlantTrailerItem"),
            },
            CraftingStation = "RoboticAssemblyLineItem",
            RequiredSkillType = typeof(IndustrySkill),
            RequiredSkillLevel = 7,
            SpeedImprovementTalents = new Type[] { typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent) }
        };

        static PlantTrailerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PlantTrailerRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(SemiTrailerRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class PlantTrailerObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Plant Trailer");
        public Type RepresentedItemType => typeof(PlantTrailerItem);

        static PlantTrailerObject()
        {
            AddOccupancy<PlantTrailerObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
            });
        }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();
    }
}
