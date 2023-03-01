namespace Cubist.Helium;

public static class AttributeExtensions
{
    /// <summary> Use this to wrap an attribute value in single quotes e.g. <c>type='button'</c> </summary>
     public static object SingleQuoted(this object o) => new SingleQuotedValue(o);

    /// <summary> Use this to not wrap an attribute value in quotes e.g. <c>type=button</c> </summary>
    public static object Unquoted(this object o) => new UnquotedValue(o);

    public static void WriteTo(this (string, object?) attr, TextWriter w)
    {
        var (name, value) = attr;
        w.Write(" ");
        w.Write(name);
        switch (value)
        {
            case null:
                return;
            case SingleQuotedValue sq:
                w.Write("='");
                w.Write(sq.Value);
                w.Write("'");
                break;
            case UnquotedValue uv:
                w.Write("=");
                w.Write(uv.Value);
                break;
            default:
                w.Write("=\"");
                w.Write(value);
                w.Write("\"");
                break;
        }
    }
}