namespace Cubist.Helium;

/// <summary> plain text </summary>
public class Text : Node
{
    /// <summary> The text for this node </summary>
    public string Value { get; }

    /// <summary>Creates a new instance of <see cref="Text"/> </summary>
    public Text(string value) => Value = value;

    /// <inheritdoc cref="Node.WriteTo"/>>
    public override void WriteTo(TextWriter w)
        => w.Write(Value);
}