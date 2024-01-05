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
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Occupancy;

namespace Eco.EM.Machines.Trucking
{
    [Serialized, Weight(200), MaxStackSize(50), LocDisplayName("Mining Trailer")]
    [LocDescription("Mining Trailer")]
    public partial class MiningTrailerItem : WorldObjectItem<MiningTrailerObject>
    {
        
    }

    [RequiresSkill(typeof(IndustrySkill), 7)]
    public partial class MiningTrailerRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(MiningTrailerRecipe).Name,
            Assembly = typeof(MiningTrailerRecipe).AssemblyQualifiedName,
            HiddenName = "Mining Trailer",
            LocalizableName = Localizer.DoStr("Mining Trailer"),
            IngredientList = new()
            {
                new EMIngredient("SteelPlateItem", false, 120),
                new EMIngredient("RivetItem", false, 80),
                new EMIngredient("RubberWheelItem", false, 6, true),
                new EMIngredient("SteelAxleItem", false, 2, true),

            },
            ProductList = new()
            {
                new EMCraftable("MiningTrailerItem"),
            },
            CraftingStation = "RoboticAssemblyLineItem",
            RequiredSkillType = typeof(IndustrySkill),
            RequiredSkillLevel = 7,
            SpeedImprovementTalents = new Type[] { typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent) }
        };

        static MiningTrailerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public MiningTrailerRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(SemiTrailerRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    public partial class MiningTrailerObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Mining Trailer");
        public Type RepresentedItemType => typeof(MiningTrailerItem);

        static MiningTrailerObject()
        {
            AddOccupancy<MiningTrailerObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
            });
        }

        protected override void Initialize() { }


    }
}
