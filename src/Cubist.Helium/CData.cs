namespace Cubist.Helium;

public class CData : Node
{
    public CData(object data)
    {
        Value = data;
    }

    public object Value { get; }

    public override void WriteTo(TextWriter w)
    {
        w.Write("<![CDATA[");
        w.Write(Value);
        w.Write("]]>");
    }
}