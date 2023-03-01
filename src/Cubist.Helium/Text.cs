namespace Cubist.Helium;

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

public class Comment : Node
{
    public Comment(string text)
    {
        Text = text; 
    }

    public string Text { get; }

    public override void WriteTo(TextWriter w )
    {
        WriteCommentStart(w);
        w.Write(" ");
        w.Write(Text);
        w.Write(" ");
        WriteCommentEnd(w);
    }

    public void WriteCommentEnd(TextWriter w)
    {
        w.Write("-->");
    }

    public void WriteCommentStart(TextWriter w)
    {
        w.Write("<!--");
    }
}