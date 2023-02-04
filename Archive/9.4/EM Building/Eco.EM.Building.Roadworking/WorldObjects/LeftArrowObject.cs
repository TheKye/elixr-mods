using System;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using Eco.Shared.Localization;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;
using System.Linq;

namespace Eco.EM.Building.Roadworking
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class LeftArrowObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Left Arrow");
        public virtual Type RepresentedItemType => typeof(LeftArrowItem);

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(10), MaxStackSize(500), LocDisplayName("Left Arrow")]
    public partial class LeftArrowItem : WorldObjectItem<LeftArrowObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("An arrow for directing traffic.");
        static LeftArrowItem() { }
    }

    [RequiresSkill(typeof(TailoringSkill), 1)]
    public partial class LeftArrowRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LeftArrowRecipe).Name,
            Assembly = typeof(LeftArrowRecipe).AssemblyQualifiedName,
            HiddenName = "Left Arrow",
            LocalizableName = Localizer.DoStr("Left Arrow"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5)
            },
            ProductList = new()
            {
                new EMCraftable("LeftArrowItem"),
            },
            CraftingStation = "TailoringTableItem",
        };

        static LeftArrowRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LeftArrowRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(DualArrowRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}