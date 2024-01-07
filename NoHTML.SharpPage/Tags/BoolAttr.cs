namespace NoHTML.SharpPage.Tags
{
    public class BoolAttr
    {
        public bool Value { get; set; }

        public BoolAttr(bool value)
        {
            Value = value;
        }

        public static BoolAttr True { get; set; } = new BoolAttr(true);
        public static BoolAttr False { get; set; } = new BoolAttr(false);
    }
}
