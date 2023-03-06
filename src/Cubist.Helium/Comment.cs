namespace Cubist.Helium;

/// <summary> a html comment: &lt;!-- --&gt; </summary>
public class Comment : Node
{
    public Comment(string text)
    {
        Text = text;
    }

    public string Text { get; }

    public override void WriteTo(TextWriter w)
    {
        WriteCommentStart(w);

        if (Text.Length > 0)
        {
            if (!Text.StartsWith(" ", StringComparison.Ordinal))
                w.Write(' ');

            w.Write(Text);

            if (!Text.EndsWith(" ", StringComparison.Ordinal))
                w.Write(' ');
        }

        WriteCommentEnd(w);
    }

    public void WriteTo(IndentWriter w)
    {
        WriteCommentStart(w);
        if (string.IsNullOrEmpty(Text))
        {
            w.Write(' ');
        }
        else
        {
            if (Text.Contains('\n'))
            {
                using (w.Indent())
                {
                    w.WriteLine();
                    var text = Text.AsSpan();
                    while (true)
                    {
                        text.SplitNewline(out var line, out text);
                        w.Write(line);
                        w.WriteLine();
                        if (text.IsEmpty)
                            break;
                    }
                }
            }
            else
            {
                if (!Text.StartsWith(" ", StringComparison.Ordinal))
                    w.Write(' ');

                w.Write(Text);

                if (!Text.EndsWith(" ", StringComparison.Ordinal))
                    w.Write(' ');
            }
        }
        WriteCommentEnd(w);
        w.WriteLine();
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