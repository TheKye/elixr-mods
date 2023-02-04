using System;
using System.Collections.Generic;
using System.Text;

namespace Eco.EM.Framework.ModRegistration
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class PluginAttribute : Attribute
    {
        public string ModName { get; set; }

        public PluginAttribute(string name = null)
        {
            ModName = name;
        }
    }

}
