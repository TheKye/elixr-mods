using System;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using Eco.Shared.Localization;
using Eco.EM.Artistry;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;

namespace Eco.EM.Transportation
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class CustomerParkingSignObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Customer Parking Sign"); } }
        public virtual Type RepresentedItemType { get { return typeof(CustomerParkingSignItem); } }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(600), LocDisplayName("Customer Parking Sign"), MaxStackSize(100)]
    public partial class CustomerParkingSignItem : WorldObjectItem<CustomerParkingSignObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Customer Parking Sign."); } }

        static CustomerParkingSignItem() { }
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class CustomerParkingSignRecipe : Recipe
    {
        public CustomerParkingSignRecipe()
        {
            var product = new Recipe(
                 "Sign - Customer Parking",
                 Localizer.DoStr("Sign - Customer Parking"),
                 new IngredientElement[]
                 {
                    new IngredientElement("WoodBoard", 10),
                    new IngredientElement(typeof(ClothItem), 5),
                    new IngredientElement(typeof(BlueDyeItem), 2)
                 },
                 new CraftingElement[]
                 {
                    new CraftingElement<CustomerParkingSignItem>(),
                 }
             );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(AnvilObject), typeof(AheadSignRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here. Recipe's only use post not pre</summary>
        partial void ModsPostInitialize();
    }
}