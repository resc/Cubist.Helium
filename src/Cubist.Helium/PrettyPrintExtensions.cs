using System.Buffers;
using System.Text.Json;

namespace Cubist.Helium;

/// <summary> Extension methods to write formatted and indented html. </summary>
public static class PrettyPrintExtensions
{
    private record PrettyPrintContext(bool Indent);

    /// <summary> pretty-prints this node to a string </summary>
    public static string PrettyPrint(this Node n)
    {
        var sw = new StringWriter();
        var indent = new IndentWriter(sw);
        PrettyPrintNode(n, indent);
        return sw.ToString();
    }

    /// <summary> pretty-prints this node to the indent writer </summary>
    public static void PrettyPrintTo(this Node n, IndentWriter w)
        => PrettyPrintNode(n, w);

    private static void PrettyPrintNode(Node n, IndentWriter w)
    {
        switch (n)
        {
            case He he:
                PrettyPrintElement(he, w);
                break;
            case Text text:
                text.WriteTo(w);
                break;
            case Json json:
                PrettyPrintJson(json, w);
                break;
            case CData cdata:
                cdata.WriteTo(w);
                break;
            case Comment comment:
                comment.WriteTo(w);
                break;
            case Css css:
                css.WriteTo(w);
                break;
            case HtmlDocument doc:
                PrettyPrintDocument(doc, w);
                break;
        }
    }

    private static void PrettyPrintJson(Json json, IndentWriter w)
    {
        var options = new JsonSerializerOptions(json.Options) { WriteIndented = true };
        var str = JsonSerializer.Serialize(json.Value, options);
        w.WriteLine(str);
    }


    private static bool IsInline(this Node n)
        => n is CData ||
           (n is Text t && !t.Value.Contains('\n')) ||
           (n is He he && he.Tag.IsInline() &&
            he.All(child => child.IsInline()));

    /// <summary>
    /// Splits <paramref name="s"/> into the first <paramref name="line"/>, and the <paramref name="remaining"/> text after the newline.
    /// Returns true if a newline was found, false if not.
    /// </summary> 
    public static bool SplitNewline(this ReadOnlySpan<char> s, out ReadOnlySpan<char> line, out ReadOnlySpan<char> remaining)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '\r')
            {
                if (s.Length > i + 1)
                {
                    if (s[i + 1] == '\n')
                    {
                        line = s[..i];
                        remaining = s[(i + 2)..];
                        return true;
                    }
                }
            }

            if (s[i] == '\n')
            {
                line = s[..i];
                if (s.Length > i + 1)
                {
                    remaining = s[(i + 1)..];
                    return true;
                }
                remaining = Span<char>.Empty;
                return true;
            }
        }

        line = s;
        remaining = Span<char>.Empty;
        return false;
    }

    private static void PrettyPrintElement(He he, IndentWriter w)
    {
        var indent = !he.IsInline();

        he.WriteStartTag(w);

        var allChildrenInline = he.All(n => n.IsInline());
        using (w.Indent())
        {
            if (indent && !allChildrenInline)
                w.WriteLine();

            foreach (var child in he)
                PrettyPrintNode(child, w);

            if (indent && !allChildrenInline && he.Count > 0 && he.Last().IsInline())
                w.WriteLine();
        }


        if (!he.Tag.IsVoid())
        {
            he.WriteCloseTag(w);

        }
        if (indent)
            w.WriteLine();

    }

    private static void PrettyPrintDocument(HtmlDocument doc, IndentWriter w)
    {
        doc.DocType.WriteTo(w);
        w.WriteLine();
        doc.Html.WriteStartTag(w);

        w.WriteLine();
        doc.Head.WriteStartTag(w);
        w.WriteLine();

        using (w.Indent())
        {
            foreach (var child in doc.Head)
            {
                PrettyPrintNode(child, w);
                if (child is He e && e.Tag.IsVoid())
                    w.WriteLine();
            }
        }

        doc.Head.WriteCloseTag(w);
        w.WriteLine();

        doc.Body.WriteStartTag(w);
        w.WriteLine();

        using (w.Indent())
        {
            foreach (var child in doc.Body)
            {
                PrettyPrintNode(child, w);
            }
        }

        doc.Body.WriteCloseTag(w);
        w.WriteLine();

        doc.Html.WriteCloseTag(w);
    }

    private static readonly ArrayPool<char> _indents = ArrayPool<char>.Create();

    /// <summary> Writes the indent whitespace for the given <paramref name="level"/> </summary>
    public static void WriteIndent(this TextWriter w, int level)
    {
        if (level < 1) return;
        var size = level * 2;
        var indent = _indents.Rent(size);
        if (indent[0] != ' ')
            Array.Fill(indent, ' ');

        w.Write(indent, 0, size);

        // we don't care if we don't return an indent due to a
        // write exception the pool will just allocate a new one
        // and the old one will be garbage collected eventually
        _indents.Return(indent);
    }
}