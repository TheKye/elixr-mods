using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Math;
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
    public partial class LeftSignObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Keep Left Sign"); } }
        public virtual Type RepresentedItemType { get { return typeof(LeftSignItem); } }

        static LeftSignObject()
        {
            AddOccupancy<LeftSignObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(0, 2, 0)),
            });
        }

        protected override void Initialize() {}

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(600), LocDisplayName("Keep Left Sign"), MaxStackSize(100)]
    public partial class LeftSignItem :  WorldObjectItem<LeftSignObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Keep Left Sign."); } }

        static LeftSignItem() { }
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class LeftSignRecipe : Recipe
    {
        public LeftSignRecipe()
        {
            var product = new Recipe(
            "Sign - Keep Left",
            Localizer.DoStr("Sign - Keep Left"),
            new IngredientElement[]
            {
                    new IngredientElement("WoodBoard", 10),
                    new IngredientElement(typeof(ClothItem), 5),
                    new IngredientElement(typeof(BlueDyeItem), 2)
            },
            new CraftingElement[]
            {
                    new CraftingElement<LeftSignItem>(),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(AnvilObject), typeof(AheadSignRecipe), product);
        }
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}