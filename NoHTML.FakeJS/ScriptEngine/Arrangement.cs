using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoHTML.FakeJS.ScriptEngine
{
    public static class Arrangement
    {
        public static readonly List<(Func<string, (int index, int length)> find, string newValue)> ReplaceIfs = new();
        public static readonly List<(string oldValue, string newValue)> Replaces = new();
    }
}
