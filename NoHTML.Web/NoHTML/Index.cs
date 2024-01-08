using Microsoft.AspNetCore.Components.RenderTree;
using NoHTML.FakeJS;
using NoHTML.FakeJS.Lib;
using NoHTML.SharpPage.Modules.Bootstrap;
using NoHTML.SharpPage.Tags.DocStruct;

namespace NoHTML.Web.NoHTML
{
    public class Index : Html
    {
        public Index(AppRoot webApp) : base(webApp) 
        {
            this.AddBootstrap();

            Body.SetBootstrapColorMode("dark");
        }
    }
}
