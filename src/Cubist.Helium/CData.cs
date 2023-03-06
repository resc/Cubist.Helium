namespace Cubist.Helium;

/// <summary> A CData node wraps text in a &lt;![CDATA[...]]&gt; element </summary>
public class CData : Node
{
    /// <summary> Creates a new <see cref="CData"/> instance with the given <paramref name="data"/> </summary>
    public CData(object data)
    {
        Value = data;
    }
    /// <summary> The value to render </summary>
    public object Value { get; }

    /// <inheritdoc cref="Node.WriteTo"/>
    public override void WriteTo(TextWriter w)
    {
        w.Write("<![CDATA[");
        if (Value is Node n)
            n.WriteTo(w);
        else
            w.Write(Value);
        w.Write("]]>");
    }
}