using NoHTML.SharpPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoHTML.FakeJS.ScriptEngine
{
    public interface IJSRuntimeManager
    {
        string? GetCodeOf(IDOMElement element);
    }
}
