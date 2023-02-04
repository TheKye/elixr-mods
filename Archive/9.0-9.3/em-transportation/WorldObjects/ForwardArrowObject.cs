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
    public partial class ForwardArrowObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Forward Arrow"); } }
        public virtual Type RepresentedItemType { get { return typeof(ForwardArrowItem); } }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(10), MaxStackSize(500), LocDisplayName("Forward Arrow")]
    public partial class ForwardArrowItem : WorldObjectItem<ForwardArrowObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("An arrow for directing traffic."); } }

        static ForwardArrowItem() { }
    }

    [RequiresSkill(typeof(TailoringSkill), 1)]
    public partial class ForwardArrowRecipe : Recipe
    {
        public ForwardArrowRecipe()
        {
            var product = new Recipe(
            "Forward Arrow",
            Localizer.DoStr("Forward Arrow"),
            new IngredientElement[]
            {
                    new IngredientElement(typeof(ClothItem), 5),
                    new IngredientElement(typeof(GreyDyeItem), 1)
            },
            new CraftingElement[]
            {
                    new CraftingElement<ForwardArrowItem>(),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(TailoringTableObject), typeof(DualArrowRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}