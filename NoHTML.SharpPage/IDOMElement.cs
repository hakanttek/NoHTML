﻿using NoHTML.SharpPage.Attributes;

namespace NoHTML.SharpPage
{
    public interface IDOMElement
    {
        string Tag { get; set; }
        string? InnerText { get; set; }
        IDOMElement SetInnerText(string value);
        T SetInnerText<T>(string value) where T : IDOMElement;
        bool IsSelfClosing {  get; set; }
        dynamic Attributes { get; }
        IDOMElement SetAttribute(string name, object value);
        T SetAttribute<T>(string name, string value) where T : IDOMElement;
        IDOMElement AppendChild(IDOMElement child);
        T AppendChild<T>(IDOMElement child) where T : IDOMElement;
        IDOMElement Arrange(Action<IDOMElement> arrangement);
        T Arrange<T>(Action<T> arrangement) where T : IDOMElement;
        bool IsVoid { get; }
        IEnumerable<KeyValuePair<string, object?>> Attrubites { get; }
        public IEnumerable<IDOMElement> Children { get; }

        //attributes
        string? Id { get; set; }
        string? Class { get; set; }
        string? Style { get; set; }
        string? Title { get; set; }
        string? Href { get; set; }
        string? Src { get; set; }
        string? Alt { get; set; }
        string? Width { get; set; }
        string? Height { get; set; }
        string? Type { get; set; }
        string? Value { get; set; }
        string? Name { get; set; }
        string? Placeholder { get; set; }
        bool? Disabled { get; set; }
        bool? Checked { get; set; }
        bool? Readonly { get; set; }
        bool? Selected { get; set; }
        bool? Multiple { get; set; }
        bool? Required { get; set; }
        string? Pattern { get; set; }
        string? Min { get; set; }
        string? Max { get; set; }
        string? Step { get; set; }
        int? Cols { get; set; }
        int? Rows { get; set; }
        bool? Autoplay { get; set; }
        bool? Controls { get; set; }
        bool? Loop { get; set; }
        bool? Muted { get; set; }
        string? Target { get; set; }
        string? Rel { get; set; }
        string? Method { get; set; }
        string? Action { get; set; }
        string? Enctype { get; set; }
        bool? Async { get; set; }
        bool? Defer { get; set; }
    }
}
