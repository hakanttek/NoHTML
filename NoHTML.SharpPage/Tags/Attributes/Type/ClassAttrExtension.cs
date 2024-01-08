using System.Text;

namespace NoHTML.SharpPage.Tags.Attributes.Type
{
    public static class ClassAttrExtension
    {
        public static StringBuilder AppendClass(this StringBuilder className, string newClassName)
        {
            if(className.Length > 0)
                className.Append(' ');

            className.Append(newClassName);

            return className;
        }
    }
}
