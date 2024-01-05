namespace EM.ECO.MOTD
{
    public class MOTDConfig 
    {
        public bool ShowOnLogin { get; set; } = true;
        public int TimeDelayOnLogin { get; set; } = 30;
        public bool PostToChat { get; set; } = false;
    }
}