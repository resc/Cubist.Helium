namespace Cubist.Helium;

/// <summary> plain text </summary>
public class Text : Node
{
    public string Value { get; }

    public Text(string value) 
        => Value = value;

    public override void WriteTo(TextWriter w) 
        => w.Write(Value);
}