namespace Cubist.Helium;
/// <summary> 
/// A Html5 document with <c>!DOCTYPE</c>, <c>html</c>, <c>head</c> and <c>body</c> tags in place.
/// </summary>
public sealed class HtmlDocument : Node
{
    /// <summary>
    /// Creates a new instance of <see cref="HtmlDocument"/>
    /// </summary>
    public HtmlDocument() : this(He.Head(), He.Body()) { }

    /// <summary>
    /// Creates a new instance of <see cref="HtmlDocument"/>
    /// </summary>
    public HtmlDocument(He head, He body)
    {
        if (head.Tag.Value != Tags.Head.Value)
            throw new ArgumentException("head parameter must be a head element", nameof(head));
        if (body.Tag.Value != Tags.Body.Value)
            throw new ArgumentException("head parameter must be a head element", nameof(head));
        DocType = He.DocType();
        Html = new He(Tags.Html);
        Head = head;
        Body = body;
        Html.Add(Head);
        Html.Add(Body);
    }

    /// <summary> The Doctype element </summary>
    public He DocType { get; }
    /// <summary> The root html element </summary>
    public He Html { get; }
    /// <summary> The <see cref="Head"/> element is added as a child to the <see cref="Html"/> element</summary>
    public He Head { get; }
    /// <summary> The <see cref="Body"/> element is added as a child to the <see cref="Html"/> element</summary>
    public He Body { get; }

    /// <inheritdoc cref="Node.WriteTo"/>>
    public override void WriteTo(TextWriter w)
    {
        DocType.WriteTo(w);
        Html.WriteTo(w);
    }
}