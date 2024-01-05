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

    public partial class LeftSignObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Keep Left Sign");
        public virtual Type RepresentedItemType => typeof(LeftSignItem);

        static LeftSignObject()
        {
            AddOccupancy<LeftSignObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }

        protected override void Initialize() {}


    }

    [Serialized, Weight(600), LocDisplayName("Keep Left Sign"), MaxStackSize(100)]
    public partial class LeftSignItem :  WorldObjectItem<LeftSignObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Keep Left Sign.");
        
        static LeftSignItem() { }
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class LeftSignRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LeftSignRecipe).Name,
            Assembly = typeof(LeftSignRecipe).AssemblyQualifiedName,
            HiddenName = "Keep Left Sign",
            LocalizableName = Localizer.DoStr("Keep Left Sign"),
            IngredientList = new()
            {
                new EMIngredient("WoodBoard", true, 10),
                new EMIngredient("ClothItem", false, 5)
            },
            ProductList = new()
            {
                new EMCraftable("LeftSignItem"),
            },
            CraftingStation = "AnvilItem",
        };

        static LeftSignRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LeftSignRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(AheadSignRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}