using System;
using System.Collections.Generic;
using System.Text;

namespace Eco.EM.Framework.PreInit
{
    public class InjectAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DefaultValuesAttribute : Attribute
    {
        public string MethodName { get; protected set; }

        public DefaultValuesAttribute(string pMethodName)
        {
            MethodName = pMethodName;
        }
    }
}
