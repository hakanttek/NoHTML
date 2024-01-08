namespace NoHTML.SharpPage.Tags.DocStruct
{
    public class Html : DOMElement
    {
        public string Lang = "en";
        public Head Head { get; set; } = new Head();
        public Body Body { get; set; } = new Body();

        public Html(Div app_root) 
        {
            app_root.Id = "app-root";
            Body.AppendChild(app_root);
            Tag = "html";
        }
    }
}
