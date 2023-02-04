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
using System.Collections.Generic;

namespace Eco.EM.Building.Roadworking
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class CustomerParkingSignObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Customer Parking Sign");
        public virtual Type RepresentedItemType => typeof(CustomerParkingSignItem);

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();
        
        static CustomerParkingSignObject()
        {

            AddOccupancy<CustomerParkingSignObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    [Serialized, Weight(600), LocDisplayName("Customer Parking Sign"), MaxStackSize(100)]
    public partial class CustomerParkingSignItem : WorldObjectItem<CustomerParkingSignObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Customer Parking Sign.");

        static CustomerParkingSignItem() { }
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class CustomerParkingSignRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(CustomerParkingSignRecipe).Name,
            Assembly = typeof(CustomerParkingSignRecipe).AssemblyQualifiedName,
            HiddenName = "Customer Parking Sign",
            LocalizableName = Localizer.DoStr("Customer Parking Sign"),
            IngredientList = new()
            {
                new EMIngredient("WoodBoard", true, 10),
                new EMIngredient("ClothItem", false, 5)
            },
            ProductList = new()
            {
                new EMCraftable("CustomerParkingSignItem"),
            },
            CraftingStation = "AnvilItem",
        };

        static CustomerParkingSignRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public CustomerParkingSignRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(AheadSignRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}