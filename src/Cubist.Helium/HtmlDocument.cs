namespace Cubist.Helium;
/// <summary>
/// A Html5 document with empty html, head and body tags in place.
/// 
/// </summary>
public sealed class HtmlDocument : Node
{
    public HtmlDocument()
    {
        DocType = He.DocType();
        Html = new He(Tags.Html);
        Head = new He(Tags.Head);
        Body = new He(Tags.Body);
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