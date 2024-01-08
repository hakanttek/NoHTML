using NoHTML.FakeJS.Lib;
using NoHTML.FakeJS;
using NoHTML.SharpPage.Modules.Bootstrap.Components.Cards;
using NoHTML.SharpPage.Tags.DocStruct;

namespace NoHTML.Web.NoHTML
{
    public class AppRoot : Div
    {
        public Card Card { get; set; } = new Card {Id = "Card"}
        .Arrange<Card>(c =>
        {
            c.Img.Src = "https://upload.wikimedia.org/wikipedia/commons/5/5d/2023_Minutnik_Baseus.jpg";
            c.Body.Button.AppendClass("btn-primary");
            c.Style = "width: 18rem;";
            c.Body.CardTitle.InnerText = "Counter";
            c.Body.Text.Id = "card-text";
            c.Body.Button.InnerText = "Increase";
            c.Body.Button.OnClick = "action()";
        });

        [JavaScript]
        private void Script()
        {
            var element = document.getElementById("card-text");
            var count = 0;
            element.innerHTML = count + "";
            var action = () =>
            {
                count++;
                element.innerHTML = count + "";
            };
        }
    }
}
