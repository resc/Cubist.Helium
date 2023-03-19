namespace Cubist.Helium;

/// <summary> a html comment: &lt;!-- --&gt; </summary>
public class Comment : Node
{
    /// <summary> Creates a new <see cref="Comment"/> node </summary>
    public Comment(string text)
    {
        Text = text;
    }

    /// <summary> The comment text </summary>
    public string Text { get; }

    /// <inheritdoc cref="Node.WriteTo"/>
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

    /// <inheritdoc cref="Node.PrettyPrintTo"/>>
    public override void PrettyPrintTo(IndentWriter w)
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

    private void WriteCommentEnd(TextWriter w)
    {
        w.Write("-->");
    }

    private void WriteCommentStart(TextWriter w)
    {
        w.Write("<!--");
    }
}