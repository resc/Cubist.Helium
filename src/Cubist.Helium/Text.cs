namespace Cubist.Helium;

/// <summary> plain text </summary>
public class Text : Node
{
    private readonly string _text;

    public Text(string text)
    {
        _text = text; 
    }

    public override void WriteTo(TextWriter w )
    {
        w.Write(_text);
    }
}