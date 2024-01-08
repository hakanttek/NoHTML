using NoHTML.SharpPage.Tags.DocStruct;
using NoHTML.SharpPage.Tags.EmbeddedContent;

namespace NoHTML.SharpPage.Modules.Bootstrap.Components.Cards
{
    public class Card : Div
    {
        public Img Img { get; set; } = new Img().AppendClass<Img>("card-img-top");
        public CardBody Body { get; set; } = new CardBody();
        public Card() => AppendClass("card").Arrange(e => e.Tag = "div");
    }
}
