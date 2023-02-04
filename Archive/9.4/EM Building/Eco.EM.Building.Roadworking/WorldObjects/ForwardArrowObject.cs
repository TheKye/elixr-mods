using System;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using Eco.Shared.Localization;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using System.Linq;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Building.Roadworking
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class ForwardArrowObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Forward Arrow");
        public virtual Type RepresentedItemType => typeof(ForwardArrowItem);

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(10), MaxStackSize(500), LocDisplayName("Forward Arrow")]
    public partial class ForwardArrowItem : WorldObjectItem<ForwardArrowObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("An arrow for directing traffic.");

        static ForwardArrowItem() { }
    }

    [RequiresSkill(typeof(TailoringSkill), 1)]
    public partial class ForwardArrowRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ForwardArrowRecipe).Name,
            Assembly = typeof(ForwardArrowRecipe).AssemblyQualifiedName,
            HiddenName = "Forward Arrow",
            LocalizableName = Localizer.DoStr("Forward Arrow"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5)
            },
            ProductList = new()
            {
                new EMCraftable("ForwardArrowItem"),
            },
            CraftingStation = "TailoringTableItem",
        };

        static ForwardArrowRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ForwardArrowRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(DualArrowRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}