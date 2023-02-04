

namespace Eco.EM.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Eco.EM;
    public static class Compare
    {
        public static bool IsLike(string Value1, string Value2)
        {
            return (Value1.ToLower() == Value2.ToLower());
        }
    }
}
