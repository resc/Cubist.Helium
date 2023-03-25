namespace Cubist.Helium;

/// <summary> Node that renders the supplied <see cref="ITemplate"/> implementation </summary>
public class Template : Node
{
    private readonly ITemplate _template;

    /// <summary> Creates a new <see cref="Template"/> instance </summary>
    public Template(ITemplate template)
    {
        _template = template;
    }

    /// <inheritdoc cref="Node.WriteTo"/>>
    public override void WriteTo(TextWriter w)
    {
        _template.Render().WriteTo(w);
    }

    /// <inheritdoc cref="Node.PrettyPrintTo"/>>
    public override void PrettyPrintTo(IndentWriter w)
    {
        _template.Render().PrettyPrintTo(w);
    }

    /// <inheritdoc cref="Node.ToString"/>>
    public override string ToString()
    {
        return _template.Render().ToString();
    }
}