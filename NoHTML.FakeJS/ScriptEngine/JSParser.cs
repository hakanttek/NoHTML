
namespace NoHTML.FakeJS.ScriptEngine
{
    public class JSParser : IJSParser
    {
        public string? Parse(string text)
        {
            var index = text.IndexOf(JavaScriptAttribute.UsageName) + JavaScriptAttribute.UsageName.Length;

            int numberOfLeft = 0, numberOfRight = 0;
            int startIndex = -1, endIndex = -1;

            while (index < text.Length)
            {
                if (text[index] == '{')
                {
                    numberOfLeft++;
                    if (numberOfLeft == 1 && index + 1 < text.Length)
                        startIndex = index + 1;
                }
                else if (text[index] == '}')
                {
                    numberOfRight++;
                    if (numberOfLeft == numberOfRight && numberOfLeft > 0)
                    {
                        endIndex = index - 1;
                        if (startIndex != -1)
                        {
                            text = text.Substring(startIndex, endIndex - startIndex + 1);
                            Arrangement.Replaces.ForEach(replace => text?.Replace(replace.oldValue, replace.oldValue));
                            Arrangement.ReplaceIfs.ForEach(replaceIf =>
                            {
                                (int startIndex, int length) = replaceIf.find(text);
                                string newValue = replaceIf.newValue;
                                text = text.Remove(startIndex, length).Insert(startIndex, newValue);
                            });
                            return text;
                        }
                    }
                }
                index++;
            }
            return null;
        }
    }
}
