namespace Cubist.Helium;

/// <summary>
/// Css node for a single selector
/// </summary>
public class Css : Node
{
    /// <summary> The css selector. </summary>
    public string Selector { get; }

    /// <summary> The css attributes </summary>
    public (string, object?)[] Attributes { get; }

    /// <summary> Creates a new instance of <see cref="Css"/> </summary>
    /// <param name="selector">The css selector, e.g. <c>.this-class</c></param>
    /// <param name="attributes">The attributes like <c>background-color</c></param>
    public Css(string selector, params (string, object?)[] attributes)
    {
        Selector = selector;
        Attributes = attributes;
    }
    /// <inheritdoc cref="Node.WriteTo"/>
    public override void WriteTo(TextWriter w)
    {
        w.Write(Selector);
        w.Write(" {");
        InlineCss.Render(w, Attributes);
        w.Write("} ");
    }

    /// <inheritdoc cref="Node.PrettyPrintTo"/>>
    public override void PrettyPrintTo(IndentWriter w)
    {
        w.Write(Selector);
        w.Write(@" {");
        w.WriteLine();

        using (w.Indent())
        {
            foreach (var attribute in Attributes)
            {
                w.Write(attribute.Item1);
                w.Write(": ");
                w.Write(attribute.Item2);
                w.Write(';');
                w.WriteLine();
            }
        }

        w.Write('}');
        w.WriteLine();
    }
}