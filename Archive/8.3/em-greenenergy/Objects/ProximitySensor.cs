namespace Eco.EM.GreenEnergy
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    #region Wall Mountable
    [Serialized]
    [RequireComponent( typeof( OnOffComponent ) )]
    [RequireComponent( typeof( PropertyAuthComponent ) )]
    public partial class WallProximitySensorObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Proximity Sensor (Wall)" ); } }
        public float Range = 10f;

        protected override void Initialize()
        {
            base.Initialize( );
            GetComponent<PropertyAuthComponent>( ).Initialize( );
        }

        public override void Destroy()
        {
            base.Destroy( );
        }

        public override void Tick()
        {
            Sensors.ProximitySensor( this, Range );
        }
    }

    [Serialized]
    [MaxStackSize( 10 )]
    [Weight( 200 )]
    public partial class WallProximitySensorItem : WorldObjectItem<WallProximitySensorObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Proximity Sensor - Wall" ); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr( "Proximity Sensors" ); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr( "A sensor that detects when players are close by." ); } }
    }

    [RequiresSkill( typeof( ElectronicsSkill ), 4 )]
    public partial class WallProximitySensorRecipe : Recipe
    {
        public WallProximitySensorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WallProximitySensorItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CircuitItem>(typeof(ElectronicsSkill), 8, ElectronicsSkill.MultiplicativeStrategy),
                new CraftingElement<PlasticItem>(typeof(ElectronicsSkill), 20, ElectronicsSkill.MultiplicativeStrategy),
                new CraftingElement<IronIngotItem>(typeof(ElectronicsSkill), 16, ElectronicsSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue( typeof( WallProximitySensorRecipe ), Item.Get<WallProximitySensorItem>( ).UILink( ), 1, typeof( ElectronicsSkill ), typeof( ElectronicsFocusedSpeedTalent ) );
            this.Initialize( Localizer.DoStr( "Proximity Sensor (Wall)" ), typeof( WallProximitySensorRecipe ) );

            CraftingComponent.AddRecipe( typeof( ElectronicsAssemblyObject ), this );
        }
    }
    #endregion

    #region Ceiling Mountable
    [Serialized]
    [RequireComponent( typeof( OnOffComponent ) )]
    [RequireComponent( typeof( PropertyAuthComponent ) )]
    public partial class CeilingProximitySensorObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Proximity Sensor (Ceiling)" ); } }
        public float Range = 20f;

        protected override void Initialize()
        {
            base.Initialize( );
            GetComponent<PropertyAuthComponent>( ).Initialize( );
        }

        public override void Destroy()
        {
            base.Destroy( );
        }

        public override void Tick()
        {
            Sensors.ProximitySensor( this, Range );
        }
    }

    [Serialized]
    [MaxStackSize( 10 )]
    [Weight( 200 )]
    public partial class CeilingProximitySensorItem : WorldObjectItem<CeilingProximitySensorObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Proximity Sensor - Ceiling" ); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr( "Proximity Sensors" ); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr( "A sensor that detects when players are close by." ); } }

    }

    [RequiresSkill( typeof( ElectronicsSkill ), 4 )]
    public partial class CeilingProximitySensorRecipe : Recipe
    {
        public CeilingProximitySensorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CeilingProximitySensorItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CircuitItem>(1),
                new CraftingElement<PlasticItem>(4),
                new CraftingElement<IronIngotItem>(1),
            };
            this.CraftMinutes = CreateCraftTimeValue( typeof( CeilingProximitySensorRecipe ), Item.Get<CeilingProximitySensorItem>( ).UILink( ), 1, typeof( ElectronicsSkill ), typeof( ElectronicsFocusedSpeedTalent ) );
            this.Initialize( Localizer.DoStr( "Proximity Sensor (Ceiling)" ), typeof( CeilingProximitySensorRecipe ) );

            CraftingComponent.AddRecipe( typeof( ElectronicsAssemblyObject ), this );
        }
    }
    #endregion
}
