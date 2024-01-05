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
using Eco.Shared.Math;
using Eco.Gameplay.Items.Recipes;

namespace Eco.EM.Building.Roadworking
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]

    public partial class LeftArrowObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Left Arrow");
        public virtual Type RepresentedItemType => typeof(LeftArrowItem);

        protected override void Initialize() { }


    }

    [Serialized, Weight(10), MaxStackSize(500), LocDisplayName("Left Arrow")]
    [LocDescription("An arrow for directing traffic.")]
    public partial class LeftArrowItem : WorldObjectItem<LeftArrowObject>
    {
        
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