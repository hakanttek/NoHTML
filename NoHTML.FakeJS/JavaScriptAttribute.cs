using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoHTML.FakeJS
{
    [AttributeUsage(AttributeTargets.Method)]
    public class JavaScriptAttribute : Attribute
    {
        public static readonly string UsageName = $"[{typeof(JavaScriptAttribute).Name.Remove(typeof(JavaScriptAttribute).Name.IndexOf("Attribute"))}]";
    }
}
