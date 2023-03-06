namespace Cubist.Helium;

/// <summary> A helper for declaring inline style attributes </summary>
public class InlineCss : Node
{
    /// <summary> The css attributes </summary>
    public (string, object?)[] Attributes { get; }

    /// <summary> Creates a new instance of <see cref="InlineCss"/> </summary>
    /// <param name="attributes"></param>
    public InlineCss(params (string, object?)[] attributes)
    {
        Attributes = attributes;
    }
    /// <inheritdoc cref="Node.WriteTo"/>
    public override void WriteTo(TextWriter w)
    {
        Render(w, Attributes);
    }

    /// <summary> renders the inline css attributes </summary>
    public static void Render(TextWriter w, params (string, object?)[] attributes)
    {
        var n = 0;
        foreach (var a in attributes)
        {
            if (n > 0) w.Write(' '); 
            w.Write(a.Item1);
            w.Write(": ");
            w.Write(a.Item2);
            w.Write(';');
            n++;
        }
    }
}