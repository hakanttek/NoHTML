namespace NoHTML.SharpPage.Tags.DocStruct
{
    public class Html : DOMElement
    {
        public string Lang = "en";
        public Head Head { get; set; } = new Head();
        public Body Body { get; set; } = new Body();
    }
}
