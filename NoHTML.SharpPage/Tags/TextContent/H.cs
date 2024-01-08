using NoHTML.SharpPage.Attributes;

namespace NoHTML.SharpPage.Tags.TextContent
{
    public class H : TextContentElement
    {
        private Level _level;
        [Ignore]
        public Level H_Level
        {
            get => _level;
            set
            {
                _level = value;
                Tag = $"h{(int)value}";
            }
        }
        public H(Level level) : base() {
            H_Level = level; 
        }
        public enum Level
        {
            _1 = 1, _2, _3, _4, _5, _6
        }
    }

}
