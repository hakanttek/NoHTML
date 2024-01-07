namespace NoHTML.SharpPage.Tags.TextContent
{
    public class H : DOMElement
    {
        public H(Level level) : base() {
            Tag = $"h{level}";   
        }
        public enum Level
        {
            _1 = 1, _2, _3, _4, _5, _6
        }
    }

}
