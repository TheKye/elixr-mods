namespace Eco.EM.Admin
{
    public class AFKConfiguration
    {
        public bool Enabled { get; set; } = false;
        public int Interval { get; set; } = 1000 * 60 * 20;
        public int AFKCheck { get; set; } = 1000 * 60 * 5;
    }
}
