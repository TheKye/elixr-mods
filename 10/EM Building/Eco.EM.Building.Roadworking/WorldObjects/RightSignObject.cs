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

namespace Eco.EM.Building.Roadworking
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]

    public partial class RightSignObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Keep Right Sign");
        public virtual Type RepresentedItemType => typeof(RightSignItem);

        static RightSignObject()
        {
            AddOccupancy<RightSignObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }

        protected override void Initialize() { }


    }

    [Serialized]
    [Weight(600)]
    [LocDisplayName("Keep Right Sign")]
    [MaxStackSize(100)]
    public partial class RightSignItem : WorldObjectItem<RightSignObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Keep right Sight");
        

        static RightSignItem() { }
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class RightSignRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RightSignRecipe).Name,
            Assembly = typeof(RightSignRecipe).AssemblyQualifiedName,
            HiddenName = "Keep Right Sign",
            LocalizableName = Localizer.DoStr("Keep Right Sign"),
            IngredientList = new()
            {
                new EMIngredient("WoodBoard", true, 10),
                new EMIngredient("ClothItem", false, 5)
            },
            ProductList = new()
            {
                new EMCraftable("RightSignItem"),
            },
            CraftingStation = "AnvilItem",
        };

        static RightSignRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RightSignRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(AheadSignRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}