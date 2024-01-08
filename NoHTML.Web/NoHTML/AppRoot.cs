using NoHTML.SharpPage;
using NoHTML.SharpPage.Modules.Bootstrap.Components.Cards;
using NoHTML.SharpPage.Tags.DocStruct;

namespace NoHTML.Web.NoHTML
{
    public class AppRoot : Div
    {
        public Card Card { get; set; } = new Card()
            .Arrange<Card>(c =>
            {
                c.Img.Src = "https://i.imgur.com/QkIa5tT.jpeg";
                c.Body.Button.AppendClass("btn-primary");
                c.Style = "width: 18rem;";
                c.Body.CardTitle.InnerText = "Card title";
                c.Body.Text.InnerText = "Some quick example text to build on the card title and make up the bulk of the card's content.";
                c.Body.Button.InnerText = "Go somewhere";
                c.Body.Button.Href = "/";
            });
    }
}
