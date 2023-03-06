namespace Cubist.Helium;

/// <summary> Extension methods for rendering attributes </summary>
public static class AttributeExtensions
{
    /// <summary> Use this to wrap an attribute value in single quotes e.g. <c>type='button'</c> </summary>
    public static object SingleQuoted(this object o) => new SingleQuotedValue(o);

    /// <summary> Use this to not wrap an attribute value in quotes e.g. <c>type=button</c> </summary>
    public static object NoQuotes(this object o) => new UnquotedValue(o);

    /// <summary> Writes a formatted attribute to <paramref name="w"/></summary>
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
                WriteValue(w, sq.Value);
                w.Write("'");
                break;
            case UnquotedValue uv:
                w.Write("=");
                WriteValue(w, uv.Value);
                break;
            default:
                w.Write("=\"");
                WriteValue(w, value);
                w.Write("\"");
                break;
        }
    }

    private static void WriteValue(TextWriter w, object? value)
    {
        if (value is Node n)
            n.WriteTo(w);
        else
            w.Write(value);
    }
}