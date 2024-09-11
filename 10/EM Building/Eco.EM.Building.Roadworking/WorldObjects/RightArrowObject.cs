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
using System.Linq;
using Eco.Gameplay.Items.Recipes;

namespace Eco.EM.Building.Roadworking
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]

    public partial class RightArrowObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Right Arrow");
        public virtual Type RepresentedItemType => typeof(RightArrowItem);

        protected override void Initialize() { }


    }

    [Serialized, Weight(10), MaxStackSize(500), LocDisplayName("Right Arrow")]
    [LocDescription("An arrow for directing traffic.")]
    public partial class RightArrowItem : WorldObjectItem<RightArrowObject>
    {
        
        static RightArrowItem() { }
    }

    [RequiresSkill(typeof(TailoringSkill), 1)]
    public partial class RightArrowRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RightArrowRecipe).Name,
            Assembly = typeof(RightArrowRecipe).AssemblyQualifiedName,
            HiddenName = "Right Arrow",
            LocalizableName = Localizer.DoStr("Right Arrow"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5)
            },
            ProductList = new()
            {
                new EMCraftable("RightArrowItem"),
            },
            CraftingStation = "TailoringTableItem",
        };

        static RightArrowRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RightArrowRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(DualArrowRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}