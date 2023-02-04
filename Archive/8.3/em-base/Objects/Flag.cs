namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Serialization;

    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class CTKFlagObject : WorldObject
    {
        public override string FriendlyName { get { return "ClaysTK Flag"; } }

        protected override void Initialize() { }

        public override void Destroy()
        {
            base.Destroy();
        }

        protected override void PostInitialize()
        {
            base.PostInitialize();
            this.GetComponent<PropertyAuthComponent>().Initialize(AuthModeType.Inherited);
        }

        public override InteractResult OnActRight(InteractionContext context)
        {
            Eco.CTK.Daily.CommandDaily(context.Player.User);
            return InteractResult.Success;
        }
    }

    [Serialized]
    public partial class CTKFlagItem : WorldObjectItem<CTKFlagObject>
    {
        public override string FriendlyName { get { return "ClaysTK Flag"; } }
        public override string Description { get { return "A piece of fabric with ClaysTK Logo on it."; } }

        static CTKFlagItem() { }
    }

    [RequiresSkill(typeof(MetalworkingSkill), 2)]
    public partial class CTKFlagRecipe : Recipe
    {
        public CTKFlagRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CTKFlagItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(50),
                new CraftingElement<ClothItem>(5),
                new CraftingElement<BoardItem>(10),
            };

            this.CraftMinutes = new ConstantValue(5);

            this.Initialize("ClaysTK Flag", typeof(CTKFlagRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}