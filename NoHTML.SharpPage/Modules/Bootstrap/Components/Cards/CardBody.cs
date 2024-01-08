using NoHTML.SharpPage.Tags.DocStruct;
using NoHTML.SharpPage.Tags.InlineTextSemantic;
using NoHTML.SharpPage.Tags.TextContent;

namespace NoHTML.SharpPage.Modules.Bootstrap.Components.Cards
{
    public class CardBody : Div
    {
        public H CardTitle { get; set; } = new H(H.Level._5)
            .AppendClass<H>("card-title");

        public P Text { get; set; } = new P()
            .SetInnerText<P>("")
            .AppendClass<P>("card-text");

        public A Button { get; set; } = new A().AppendClass<A>("btn");
        public CardBody()
        {
            this.AppendClass("card-body");
            this.Tag = "div";
        }
    }
}
