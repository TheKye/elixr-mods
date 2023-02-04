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
    [Serialized, Weight(200), MaxStackSize(50), LocDisplayName("B-Double Trailer")]
    public partial class BDoubleTrailerItem : WorldObjectItem<BDoubleTrailerObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("B-Double Trailer");
    }

    [RequiresSkill(typeof(IndustrySkill), 7)]
    public partial class BDoubleTrailerRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BDoubleTrailerRecipe).Name,
            Assembly = typeof(BDoubleTrailerRecipe).AssemblyQualifiedName,
            HiddenName = "B-Double Trailer",
            LocalizableName = Localizer.DoStr("B-Double Trailer"),
            IngredientList = new()
            {
                new EMIngredient("SteelPlateItem", false, 120),
                new EMIngredient("RivetItem", false, 160),
                new EMIngredient("RubberWheelItem", false, 16, true),
                new EMIngredient("SteelAxleItem", false, 6, true),

            },
            ProductList = new()
            {
                new EMCraftable("BDoubleTrailerItem"),
            },
            CraftingStation = "RoboticAssemblyLineItem",
            RequiredSkillType = typeof(IndustrySkill),
            RequiredSkillLevel = 7,
            SpeedImprovementTalents = new Type[] { typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent) }
        };

        static BDoubleTrailerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BDoubleTrailerRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(SemiTrailerRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class BDoubleTrailerObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("B-Double Trailer");
        public Type RepresentedItemType => typeof(BDoubleTrailerItem);

        static BDoubleTrailerObject()
        {
            AddOccupancy<BDoubleTrailerObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
            });
        }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();
    }
}
