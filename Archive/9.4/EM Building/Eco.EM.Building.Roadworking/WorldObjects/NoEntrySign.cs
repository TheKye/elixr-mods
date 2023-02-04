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
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class NoEntrySignObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("No Entry Sign");
        public virtual Type RepresentedItemType => typeof(NoEntrySignItem);

        static NoEntrySignObject()
        {
            AddOccupancy<NoEntrySignObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(600), LocDisplayName("No Entry Sign"), MaxStackSize(100)]
    public partial class NoEntrySignItem : WorldObjectItem<NoEntrySignObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Sign For No Entry.");

        static NoEntrySignItem() { }
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class NoEntrySignRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(NoEntrySignRecipe).Name,
            Assembly = typeof(NoEntrySignRecipe).AssemblyQualifiedName,
            HiddenName = "No Entry Sign",
            LocalizableName = Localizer.DoStr("No Entry Sign"),
            IngredientList = new()
            {
                new EMIngredient("WoodBoard", true, 10),
                new EMIngredient("ClothItem", false, 5)
            },
            ProductList = new()
            {
                new EMCraftable("NoEntrySignItem"),
            },
            CraftingStation = "AnvilItem",
        };

        static NoEntrySignRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public NoEntrySignRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(AheadSignRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}