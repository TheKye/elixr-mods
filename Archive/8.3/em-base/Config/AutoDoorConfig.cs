namespace Eco.EM.Items
{
    public class AutoDoorConfig
    {
        public bool Enable { get; set; } = true;

        public bool AutoDoorOn { get; set; } 

        public int DoorSensor { get; set; } = 3;

        public int LdoorSensor { get; set; } = 5;

    }
}
