namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Shared.Localization;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Serialization;
    using Eco.Mods.TechTree;
    using Eco.Shared.Math;
    using System.Collections.Generic;

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class ASpecialFlagObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Special Flag"); } }

        protected override void Initialize() { }

        public override void Destroy()
        {
            base.Destroy();
        }

        protected override void PostInitialize()
        {
            base.PostInitialize();
        }

    }

    [Serialized]
    [Weight(600)]
    public partial class ASpecialFlagItem : WorldObjectItem<ASpecialFlagObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Special Flag"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A piece of fabric with Special Logo on it."); } }

        static ASpecialFlagItem() { }
    }

    [RequiresSkill(typeof(TailoringSkill), 1)]
    public partial class ASpecialFlagRecipe : Recipe
    {
        public ASpecialFlagRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ASpecialFlagItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(50),
                new CraftingElement<ClothItem>(5),
                new CraftingElement<IronIngotItem>(5),
            };

            this.CraftMinutes = new ConstantValue(5);

            this.Initialize(Localizer.DoStr("Special Flag"), typeof(ASpecialFlagRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
}