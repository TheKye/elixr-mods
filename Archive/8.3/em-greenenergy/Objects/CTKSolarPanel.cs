namespace Eco.EM.GreenEnergy
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    [Serialized]
    [RequireComponent( typeof( PropertyAuthComponent ) )]
    [RequireComponent( typeof( PowerGridComponent ) )]
    [RequireComponent( typeof( PowerGeneratorComponent ) )]
    [RequireComponent( typeof( OnOffComponent ) )]
    public partial class CTKSolarPanelObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Solar Panel" ); } }
        public float OutputWattage = 250f;
        public float CurrentOutput = 0f;

        protected override void Initialize()
        {
            GetComponent<PowerGridComponent>( ).Initialize( 30, new ElectricPower( ) );
            GetComponent<PowerGeneratorComponent>( ).Initialize( 250 );
        }

        public override void Tick()
        {
            float ToOutput = OutputWattage;
            if (!DaylightSensorHelper.IsDayLight( ))
                ToOutput = 0;

            if (CurrentOutput != ToOutput)
            {
                CurrentOutput = ToOutput;
                GetComponent<PowerGeneratorComponent>( ).Initialize( ToOutput );
            }
        }

        public override void Destroy()
        {
            base.Destroy( );
        }
    }

    [Serialized]
    public partial class CTKSolarPanelItem : WorldObjectItem<CTKSolarPanelObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Solar Panel" ); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr( "Solar Panel by EM" ); } }

        static CTKSolarPanelItem()
        {

        }
    }
}