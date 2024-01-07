using Microsoft.AspNetCore.Components.RenderTree;
using NoHTML.SharpPage;
using NoHTML.SharpPage.Tags.DocStruct;

namespace NoHTML.Web.NoHTML
{
    public class WebPage : Html
    {
        public WebPage(WebApp webApp) {
            Body.AppendChild(webApp);
        }
    }
}
