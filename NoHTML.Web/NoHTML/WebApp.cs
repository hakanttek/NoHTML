using NoHTML.SharpPage.Tags.DocStruct;

namespace NoHTML.Web.NoHTML
{
    public class WebApp : Div
    {
        Div div = new Div()
            .SetInnerText<Div>("Hello world");
    }
}
