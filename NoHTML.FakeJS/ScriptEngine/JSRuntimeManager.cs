using NoHTML.SharpPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoHTML.FakeJS.ScriptEngine
{
    public class JSRuntimeManager : IJSRuntimeManager
    {
        public OperationMode OperationMode { get; set; }
        private readonly IJSParser _parser;
        
        public JSRuntimeManager(IJSParser parser, OperationMode operationMode = OperationMode.Development)
        {
            _parser = parser;
            OperationMode = operationMode;
        }

        public string? GetCodeOf(IDOMElement element)
        {
            if(OperationMode == OperationMode.Development)
            {
                var path = element.SourcePath;
                try
                {
                    var text = File.ReadAllText(path);
                    return _parser.Parse(text);
                }catch (Exception) { 
                    return null;
                }

            }
            else
            {
                throw new NotSupportedException("In NoHTML.FakeJS.ScriptEngine.JsRuntimeManager, OperationMode.Production is still not complated.");
            }
        }
    }
}