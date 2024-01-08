using NoHTML.SharpPage.Attributes;
using NoHTML.SharpPage.Tags;
using NoHTML.SharpPage.Tags.Attributes.Type;
using NoHTML.SharpPage.Tags.TextContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NoHTML.SharpPage
{
    public class DOMElement : IDOMElement
    {
        [Ignore]
        public string Tag { get; set; }
        [Ignore]
        public string? InnerText { get; set; }
        public IDOMElement SetInnerText(string text)
        {
            InnerText = text;
            return this;
        }
        public T SetInnerText<T>(string value) where T : IDOMElement => IDOMElement.CastTo<T>(SetInnerText(value));

        private bool _isSelfClosing = true;
        [Ignore]
        public bool IsSelfClosing { get => IsVoid || _isSelfClosing; set => _isSelfClosing = value; }

        [Ignore]
        private Dictionary<string, object?> _attributePairs = new();

        [Ignore]
        public dynamic Attributes { get; } = new System.Dynamic.ExpandoObject();

        [Ignore]
        private List<IDOMElement> _children = new();

        [Ignore]
        public string SourcePath {  get; }
        public DOMElement()
        {
            Tag = GetType().Name.ToLower();

            string path = System.IO.Directory.GetCurrentDirectory();
            int length = path.Length - path.LastIndexOf('\\');
            string classPath =  this.GetType().FullName.Substring(length).Replace(".", "\\");
            SourcePath = new StringBuilder(path).Append("\\").Append(classPath).Append(".cs").ToString();
        }

        [Ignore]
        public bool IsVoid => InnerText is null || !Children.Any();
        
        public IDOMElement SetAttribute(string name, object value) => SetAttribute<IDOMElement>(name, value);

        public T SetAttribute<T>(string name, object value) where T : IDOMElement
        {
            _attributePairs[name] = value;
            return IDOMElement.CastTo<T>(this);
        }

        public IDOMElement AppendChild(IDOMElement child) => AppendChild<IDOMElement>(child);
        public T AppendChild<T>(IDOMElement child) where T : IDOMElement
        {
            _children.Add(child);
            return IDOMElement.CastTo<T>(this);
        }
        private IEnumerable<KeyValuePair<string, object?>> GetDynamicAttributes()
        {
            foreach (var property in Attributes)
                yield return KeyValuePair.Create<string, object?>(property.Key, property.Value);
        }

        private IEnumerable<PropertyInfo> GetNonIgnoredPublicInstances()
        {
            var props = GetType()
                .GetProperties().Where(p => !Attribute.IsDefined(p, typeof(IgnoreAttribute)));

            return props;
        }
        public IDOMElement Arrange(params Action<IDOMElement>[] arrangements) => Arrange<IDOMElement>(arrangements);
        public T Arrange<T>(params Action<T>[] arrangements) where T : IDOMElement
        {
            T element = IDOMElement.CastTo<T>(this);
            foreach (var arrangement in arrangements)
                arrangement(element);

            return  IDOMElement.CastTo<T>(element);
        }

        [Ignore]
        public IEnumerable<KeyValuePair<string, object?>> Attrubites =>
            GetNonIgnoredPublicInstances()
                .Where(p => !typeof(IDOMElement).IsAssignableFrom(p.PropertyType))
                .Select(p => KeyValuePair.Create(p.Name, p.GetValue(this)))
                .Union(_attributePairs)
                .Union(GetDynamicAttributes());

        public IDOMElement AppendClass(string className) => AppendClass<IDOMElement>(className);
        public T AppendClass<T>(string className) where T : IDOMElement
        {
            this.Class ??= new StringBuilder();
            this.Class.AppendClass(className);
            return IDOMElement.CastTo<T>(this);
        }

        [Ignore]
        public IEnumerable<IDOMElement> Children =>
            GetNonIgnoredPublicInstances()
                .Where(p => typeof(IDOMElement).IsAssignableFrom(p.PropertyType))
                .Select(p => p.GetValue(this))
                .OfType<IDOMElement>()
                .Union(_children)
                .Where(p => !p.Ignore);

        [Ignore]
        public bool Ignore { get; set; } = false;

        //attributes
        public string? Id { get; set; }
        public StringBuilder? Class { get; set; }
        public string? Style { get; set; }
        public string? Title { get; set; }
        public string? Href { get; set; }
        public string? Src { get; set; }
        public string? Alt { get; set; }
        public string? Width { get; set; }
        public string? Height { get; set; }
        public string? Type { get; set; }
        public string? Value { get; set; }
        public string? Name { get; set; }
        public string? Placeholder { get; set; }
        public bool? Disabled { get; set; }
        public bool? Checked { get; set; }
        public bool? Readonly { get; set; }
        public bool? Selected { get; set; }
        public bool? Multiple { get; set; }
        public bool? Required { get; set; }
        public string? Pattern { get; set; }
        public string? Min { get; set; }
        public string? Max { get; set; }
        public string? Step { get; set; }
        public int? Cols { get; set; }
        public int? Rows { get; set; }
        public bool? Autoplay { get; set; }
        public bool? Controls { get; set; }
        public bool? Loop { get; set; }
        public bool? Muted { get; set; }
        public string? Target { get; set; }
        public string? Rel { get; set; }
        public string? Method { get; set; }
        public string? Action { get; set; }
        public string? Enctype { get; set; }
        public bool? Async { get; set; }
        public bool? Defer { get; set; }
        public string? Integrity { get; set; }
        public string? Crossorigin { get; set; }
    }
}
