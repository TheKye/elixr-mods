using System;

namespace Eco.EM.Framework.Utils
{
    public static class StringUtils
    {
        public static string GetAssemblyNameFromAssemblyString(string qualifiedname)
        {
            var splits = qualifiedname.Split(",", StringSplitOptions.TrimEntries);
            return splits[1];
        }
    }
}
