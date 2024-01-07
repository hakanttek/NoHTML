using NoHTML.SharpPage.Tags.Metadata;

namespace NoHTML.SharpPage.Tags.DocStruct
{
    public class Head : DOMElement
    {
        public Meta Meta1 { get; set; } = new Meta { Charset = "UTF-8" };
        public Meta Meta2 { get; set; } = new Meta 
        { 
            Name = "viewport", 
            Content = "width=device-width, initial-scale=1.0" 
        };
    }
}
