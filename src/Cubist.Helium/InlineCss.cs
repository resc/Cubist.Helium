namespace Cubist.Helium;

public class InlineCss : Node
{
    public (string, object?)[] Attributes { get; }

    public InlineCss(params (string, object?)[] attributes)
    {
        Attributes = attributes;
    }

    public override void WriteTo(TextWriter w)
    {
        Render(w, Attributes);
    }

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