namespace NoHTML.SharpPage.Tags.Scripting
{
    public class Script : DOMElement
    {
        public Script() {
            InnerText ??= "";
        }
    }
}
