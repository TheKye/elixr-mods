using Eco.Shared.Math;
using System;

namespace Eco.EM.Homes
{
    [Serializable]
    public class Home
    {
        public string HomeName { get; private set; }
        public System.Numerics.Vector3 Location { get; private set; }

        public Home(string name, System.Numerics.Vector3 location)
        {
            HomeName = name;
            Location = location;
        }
    }
}
