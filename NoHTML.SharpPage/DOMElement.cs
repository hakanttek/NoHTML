using NoHTML.SharpPage.Attributes;
using NoHTML.SharpPage.Tags;
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
        public static T CastTo<T>(DOMElement obj) where T : IDOMElement
        {
            if (obj is T element)
            {
                return element;
            }
            else
            {
                throw new InvalidOperationException(
                    $"This instance of type '{obj.GetType().Name}' cannot be cast to the type '{typeof(T).Name}'."
                );
            }
        }

        [Ignore]
        public string Tag { get; set; }
        [Ignore]
        public string? InnerText { get; set; }
        public IDOMElement SetInnerText(string text)
        {
            InnerText = text;
            return this;
        }
        public T SetInnerText<T>(string value) where T : IDOMElement
        {
            SetInnerText(value);
            return CastTo<T>(this);
        }

        private bool _isSelfClosing = true;
        [Ignore]
        public bool IsSelfClosing { get => IsVoid || _isSelfClosing; set => _isSelfClosing = value; }
        
        private Dictionary<string, object?> _attributePairs = new();

        public dynamic Attributes { get; } = new System.Dynamic.ExpandoObject();

        private List<IDOMElement> _children = new();

        public DOMElement()
        {
            Tag = GetType().Name.ToLower();
        }
                
        public bool IsVoid => InnerText is null || !Children.Any();
        
        public IDOMElement SetAttribute(string name, object value)
        {
            _attributePairs[name] = value;
            return this;
        }

        public T SetAttribute<T>(string name, string value) where T : IDOMElement
        {
            SetAttribute(name, value);
            return CastTo<T>(this);
        }

        public IDOMElement AppendChild(IDOMElement element)
        {
            _children.Add(element);
            return this;
        }
        public T AppendChild<T>(IDOMElement child) where T : IDOMElement
        {
            AppendChild(child);
            return CastTo <T>(this);
        }
        private IEnumerable<KeyValuePair<string, object?>> GetDynamicAttributes()
        {
            foreach (var property in (IDictionary<string, Object>)Attributes)
                yield return KeyValuePair.Create<string, object?>(property.Key, property.Value);
        }

        private IEnumerable<PropertyInfo> GetNonIgnoredPublicInstances() => 
            GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => !Attribute.IsDefined(p, typeof(IgnoreAttribute)));

        public IDOMElement Arrange(Action<IDOMElement> arrangement)
        {
            arrangement(this);
            return this;
        }
        public T Arrange<T>(Action<T> arrangement) where T : IDOMElement => Arrange(arrangement);

        [Ignore]
        public IEnumerable<KeyValuePair<string, object?>> Attrubites =>
            GetNonIgnoredPublicInstances()
                .Select(p => KeyValuePair.Create(p.Name, p.GetValue(this)))
                .Union(_attributePairs)
                .Union(GetDynamicAttributes());

        [Ignore]
        public IEnumerable<IDOMElement> Children =>
            GetNonIgnoredPublicInstances()
                .Where(p => typeof(IDOMElement).IsAssignableFrom(p.PropertyType))
                .Select(p => p.GetValue(this))
                .OfType<IDOMElement>()
                .Union(_children);

        //attributes
        public string? Id { get; set; }
        public string? Class { get; set; }
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
    }
}
