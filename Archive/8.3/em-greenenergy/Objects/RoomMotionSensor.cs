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
    public partial class WallMotionSensorObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Motion Sensor (Wall)" ); } }
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
            Sensors.MotionSensor( this, Range );
        }
    }

    [Serialized]
    [MaxStackSize( 10 )]
    [Weight( 200 )]
    public partial class WallMotionSensorItem : WorldObjectItem<WallMotionSensorObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Motion Sensor - Wall" ); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr( "Motion Sensors" ); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr( "A sensor that detects when players are in the room." ); } }
    }

    [RequiresSkill( typeof( ElectronicsSkill ), 4 )]
    public partial class WallMotionSensorRecipe : Recipe
    {
        public WallMotionSensorRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<WallMotionSensorItem>(),
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<CircuitItem>(typeof(ElectronicsSkill), 8, ElectronicsSkill.MultiplicativeStrategy),
                new CraftingElement<PlasticItem>(typeof(ElectronicsSkill), 20, ElectronicsSkill.MultiplicativeStrategy),
                new CraftingElement<IronIngotItem>(typeof(ElectronicsSkill), 16, ElectronicsSkill.MultiplicativeStrategy),
            };
            CraftMinutes = CreateCraftTimeValue( typeof( WallMotionSensorRecipe ), Item.Get<WallMotionSensorItem>( ).UILink( ), 1, typeof( ElectronicsSkill ), typeof( ElectronicsFocusedSpeedTalent ) );
            Initialize( Localizer.DoStr( "Motion Sensor (Wall)" ), typeof( WallMotionSensorRecipe ) );

            CraftingComponent.AddRecipe( typeof( ElectronicsAssemblyObject ), this );
        }
    }
    #endregion

    #region Ceiling Mountable
    [Serialized]
    [RequireComponent( typeof( OnOffComponent ) )]
    [RequireComponent( typeof( PropertyAuthComponent ) )]
    public partial class CeilingMotionSensorObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Motion Sensor (Ceiling)" ); } }
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
            Sensors.MotionSensor( this, Range );
        }
    }

    [Serialized]
    [MaxStackSize( 10 )]
    [Weight( 200 )]
    public partial class CeilingMotionSensorItem : WorldObjectItem<CeilingMotionSensorObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Motion Sensor - Ceiling" ); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr( "Motion Sensors" ); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr( "A sensor that detects when players are in the room." ); } }

    }

    [RequiresSkill( typeof( ElectronicsSkill ), 4 )]
    public partial class CeilingMotionSensorRecipe : Recipe
    {
        public CeilingMotionSensorRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<CeilingMotionSensorItem>(),
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<CircuitItem>(1),
                new CraftingElement<PlasticItem>(4),
                new CraftingElement<IronIngotItem>(1),
            };
            CraftMinutes = CreateCraftTimeValue( typeof( CeilingMotionSensorRecipe ), Item.Get<CeilingMotionSensorItem>( ).UILink( ), 1, typeof( ElectronicsSkill ), typeof( ElectronicsFocusedSpeedTalent ) );
            Initialize( Localizer.DoStr( "Motion Sensor (Ceiling)" ), typeof( CeilingMotionSensorRecipe ) );

            CraftingComponent.AddRecipe( typeof( ElectronicsAssemblyObject ), this );
        }
    }
    #endregion
}
