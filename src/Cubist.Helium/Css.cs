namespace Cubist.Helium;

public class Css : Node
{
    public string Selector { get; }

    public (string, object?)[] Attributes { get; }

    public Css(string selector, params (string, object?)[] attributes)
    {
        Selector = selector;
        Attributes = attributes;
    }

    public override void WriteTo(TextWriter w)
    {
        w.Write(Selector);
        w.Write(" {");
        InlineCss.Render(w, Attributes);
        w.Write("} ");
    }

    public void WriteTo(IndentWriter w)
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