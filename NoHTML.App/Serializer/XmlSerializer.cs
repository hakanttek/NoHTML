using NoHTML.FakeJS.ScriptEngine;
using NoHTML.SharpPage;
using NoHTML.SharpPage.Tags.Attributes.Type;
using NoHTML.SharpPage.Tags.Scripting;
using System.Text;

namespace NoHTML.App.Core
{
    public class XmlSerializer : ISerializer
    {
        private IJSRuntimeManager _jSRuntimeManager;

        public XmlSerializer(IJSRuntimeManager jSRuntimeManager) 
        { 
            _jSRuntimeManager = jSRuntimeManager;
        }

        public string Serialize<T>(T element) where T : IDOMElement
        {
            var attributes = element.Attrubites;

            var childrenElements = element.Children;

            var tag = element.Tag;

            var stringBuilder = new StringBuilder();

            //open tag
            stringBuilder.Append($"<{tag}");

            foreach (var attribute in attributes)
                if (attribute.Value is not null)
                    if (attribute.Value is BoolAttr boolAttr)
                    {
                        if(boolAttr.Value)
                            stringBuilder.Append($" {attribute.Key.ToLower()}");
                    }
                    else
                        stringBuilder.Append($" {attribute.Key.ToLower()}=\"{attribute.Value.ToString()}\"");

            string? jsCode = _jSRuntimeManager.GetCodeOf(element);

            if(element.InnerText is not null || childrenElements.Any() || jsCode is not null)
            {
                stringBuilder.Append(">");

                if (element.InnerText?.Length > 0)
                    stringBuilder.AppendLine(element.InnerText);

                foreach (var child in childrenElements)
                    stringBuilder.AppendLine(Serialize(child));

                if (jsCode is not null)
                {
                    Script script = new()
                    {
                        InnerText = jsCode
                    };

                    stringBuilder.AppendLine(Serialize(script));
                }

                return stringBuilder.AppendLine($"</{tag}>").ToString();
            }
            else if (element.IsSelfClosing)
                return stringBuilder.Append($"/>").ToString();
            else
                return stringBuilder.Append($">").ToString();
        }
    }
}
