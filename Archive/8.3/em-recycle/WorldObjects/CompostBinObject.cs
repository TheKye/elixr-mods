namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Serialization;
    using Eco.Shared.Localization;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class CompostBinObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Compost Bin"); } }

        protected override void Initialize()
        {
            GetComponent<MinimapComponent>().Initialize("Crafting");
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized]
    public partial class CompostBinItem : WorldObjectItem<CompostBinObject>
    {
        public override LocString DisplayName        { get { return Localizer.DoStr("Compost Bin"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Throw in organic materials to get dirt!"); } }

        static CompostBinItem()
        {

        }
    }
    
    [RequiresSkill(typeof(RecycleSkill), 0)]
    public partial class CompostBinRecipe : Recipe
    {
        public CompostBinRecipe()
        {
            Products = new CraftingElement[] {
                new CraftingElement<CompostBinItem>(),
            };
            Ingredients = new CraftingElement[] {
                new CraftingElement<PlasticItem> (8),
            };

            this.CraftMinutes = CreateCraftTimeValue(typeof(CompostBinRecipe), Item.Get<CompostBinItem>().UILink(), 2, typeof(RecycleSkill)); ;
            Initialize(Localizer.DoStr("Compost Bin"), typeof(CompostBinRecipe));
            CraftingComponent.AddRecipe(typeof( WorkbenchObject ), this);
        }
    }
}