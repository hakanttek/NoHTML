using NoHTML.SharpPage.Tags.DocStruct;

namespace NoHTML.App.Core
{
    public class ClientApp<T> where T : Html
    {
        public readonly ISerializer Serializer;

        public readonly T MainElement;

        private string _serializedMainElement;

        public string ContentType { get; set; }

        public ClientApp(ISerializer serializer, T mainElement, string contentType = "text/html")
        {
            Serializer = serializer;
            MainElement = mainElement;
            _serializedMainElement = serializer.Serialize(mainElement);
            ContentType = contentType;
        }

        public string ToPlainText() => _serializedMainElement;

        public void RefreshContent() => _serializedMainElement = Serializer.Serialize(MainElement);
    }
}
