using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoHTML.SharpPage.Tags.TextContent
{
    public class TextContentElement : DOMElement
    {
        public TextContentElement() => InnerText = string.Empty;
    }
}
