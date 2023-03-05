namespace Cubist.Helium;

/// <summary> plain text </summary>
public class Text : Node
{
    public Text(string text)
    {
        Value = text; 
    }

    public string Value { get; }

    public override void WriteTo(TextWriter w )
    {
        w.Write(Value);
    }
}