using Microsoft.Extensions.Primitives;
using NoHTML.App.Extension;
using NoHTML.SharpPage;
using NoHTML.SharpPage.Attributes;
using NoHTML.SharpPage.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoHTML.App.Core
{
    public class XmlSerializer : ISerializer
    {
        public string Serialize(IDOMElement element)
        {
            var attributes = element.Attrubites;

            var childrenElements = element.Children;

            var tag = element.Tag;

            var stringBuilder = new StringBuilder();

            //open tag
            stringBuilder.Append(stringBuilder.Append($"<{tag}"));

            foreach (var attribute in attributes)
                if (attribute.Value is not null)
                    if (attribute.Value is BoolAttr boolAttr)
                    {
                        if(boolAttr.Value)
                            stringBuilder.Append($" {attribute.Key}");
                    }
                    else
                        stringBuilder.Append($" {attribute.Key}=\"{attribute.Value}\"");
            
            stringBuilder.Append(">");

            if(element.InnerText is not null || childrenElements.Any())
            {
                if(element.InnerText is not  null) { }
                    stringBuilder.AppendLine(element.InnerText);
                foreach (var child in childrenElements)
                    stringBuilder.AppendLine(Serialize(child));

                return stringBuilder.AppendLine($"</{tag}>").ToString();
            }
            else if (element.IsSelfClosing)
                return stringBuilder.Append($"</{tag}>").ToString();
            else
                return stringBuilder.Append($"</{tag}>").ToString();
        }
    }
}
