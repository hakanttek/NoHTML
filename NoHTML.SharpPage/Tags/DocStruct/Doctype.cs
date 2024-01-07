using NoHTML.SharpPage.Tags.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoHTML.SharpPage.Tags.DocStruct
{
    public class Doctype : DOMElement
    {
        public Doctype() { 
            IsSelfClosing = false;
            Tag = "!DOCTYPE";
        }
    }
}
