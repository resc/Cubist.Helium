namespace Cubist.Helium;

public class CData : Node
{
    private readonly object _data;
    
    public CData(object data)
    {
        _data = data; 
    }

    public override void WriteTo(TextWriter w )
    {
        w.Write("<![CDATA[");
        w.Write(_data);
        w.Write("]]>");
    }
}