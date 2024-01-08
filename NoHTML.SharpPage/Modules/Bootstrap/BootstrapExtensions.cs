using NoHTML.SharpPage.Tags.DocStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoHTML.SharpPage.Modules.Bootstrap
{
    public static class BootstrapExtensions
    {
        public static void AddBootstrap(this Html html)
        {
            html.Head.AppendChild(BootstrapCDN.CSS());
            html.Body.AppendChild(BootstrapCDN.JS());
        }

        public static void SetBootstrapColorMode(this IDOMElement element, string mode) 
        { 
            element.SetAttribute("data-bs-theme", mode);
        }
    }
}
