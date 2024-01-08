using System;
using System.Collections.Generic;
using System.Linq;
namespace NoHTML.FakeJS
{
    public static class Util
    {
        public static string GetRuntimePathOf(Type type)
        {
            var projectName = System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name??
                throw new NullReferenceException("GetRuntimePathOf() cannot find the projectName via System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name");
            
            var classPath = type.ToString().Substring(projectName.Length + 1).Replace(".",@"\");

            // Add a leading '\' to the path
            var projectPath = Directory.GetParent(Environment.CurrentDirectory);
            return @$"{projectPath}\{projectName}\{classPath}.cs";
        }
    }
}
