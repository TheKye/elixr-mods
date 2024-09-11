namespace Eco.EM.Admin.AdminExtentsions
{
    public class AutoRestartConfig
    {
        public float[] RestartTimes { get; set; } = new float[] {00.00f, 12.00f };
        public string AutoShutdownMessage { get; set; } = "Automatic Restart";
        public string ReasonForShutdown { get; set; } = "Restart";
        public int[] ShutdownIntervals { get; set; } = new int[] { 60, 45, 30, 15, 5, 3, 1 };
        public float CountdownStart { get; set; } = 30;
    }
}