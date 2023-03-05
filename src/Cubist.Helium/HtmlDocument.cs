namespace Cubist.Helium;
/// <summary> 
/// A Html5 document with <c>!DOCTYPE</c>, <c>html</c>, <c>head</c> and <c>body</c> tags in place.
/// </summary>
public sealed class HtmlDocument : Node
{
    public HtmlDocument() : this(He.Head(), He.Body()) { }

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

    public He DocType { get; }
    public He Html { get; }
    public He Head { get; }
    public He Body { get; }

    public override void WriteTo(TextWriter w)
    {
        DocType.WriteTo(w);
        Html.WriteTo(w);
    }
}