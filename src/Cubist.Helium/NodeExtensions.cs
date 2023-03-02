using System.Collections.Concurrent;

namespace Cubist.Helium;

public static class NodeExtensions
{

    public static IEnumerable<Node> Descendants(this Node start)
        => start.DescendantsAndSelf().Skip(1);

    public static IEnumerable<Node> DescendantsAndSelf(this Node start)
    {
        var stack = new Stack<Node>();
        stack.Push(start);

        while (stack.Count > 0)
        {
            var n = stack.Pop();
            yield return n;

            if (n is He he)
            {
                for (var index = he.Count - 1; index >= 0; index--)
                    stack.Push(he[index]);
            }
        }
    }

    public static void Apply(this Node start, Func<Node, bool> match, Action<Node> apply)
    {
        var stack = new Stack<Node>();
        stack.Push(start);

        while (stack.Count > 0)
        {
            var n = stack.Pop();
            if (match(n))
                apply(n);

            if (n is He he)
            {
                foreach (var child in he)
                    stack.Push(child);
            }
        }
    }



    private static readonly ConcurrentDictionary<int, string> _indents = new();

    public static void WriteIndent(this TextWriter w, int level)
        => w.Write(_indents.GetOrAdd(level, l => new string(' ', l * 2)));

    public static void WriteStartTag(this He he, TextWriter w)
    {
        he.Tag.WriteStartBegin(w);
        foreach (var attr in he.Attrs())
            attr.WriteTo(w);
        he.Tag.WriteStartEnd(w);
    }

    public static void WriteCloseTag(this He he, TextWriter w)
    {
        he.Tag.WriteClose(w);
    }

    public static string PrettyPrint(this Node n)
    {
        var sw = new StringWriter();
        n.PrettyPrintTo(sw, 0);
        return sw.ToString();
    }

    public static void PrettyPrintTo(this Node n, TextWriter w)
        => n.PrettyPrintTo(w, 0);


    public static void PrettyPrintTo(this Node n, TextWriter w, int level)
    {
        switch (n)
        {
            case HtmlDocument doc:
                PrettyPrintDocument(doc, w);
                break;
            case Text text:
                text.WriteTo(w);
                break;
            case Comment comment:
                WriteComment(comment, w, level);
                break;
            case CData cdata:
                cdata.WriteTo(w);
                break;
            case He he:
                PrettyPrintElement(he, w, level);
                break;
        }
    }

    private static void WriteComment(Comment comment, TextWriter w, int level)
    {
        w.WriteIndent(level);
        comment.WriteCommentStart(w);
        if (string.IsNullOrEmpty(comment.Text))
        {
            w.Write(" ");
        }
        else
        {
            if (comment.Text.Contains("\n"))
            {
                foreach (var line in comment.Text.Split("\n"))
                {
                    w.WriteLine();
                    w.WriteIndent(level + 1);
                    w.Write(line);
                }

                w.WriteLine();
                w.WriteIndent(level);
            }
            else
            {
                w.Write(" ");
                w.Write(comment.Text);
                w.Write(" ");
            }
        }

        comment.WriteCommentEnd(w);
        w.WriteLine();
    }

    private static bool IsInline(this He he)
        => he.Tag.IsInline();

    private static void PrettyPrintElement(He he, TextWriter w, int level)
    {
        if (!he.IsInline())
            w.WriteIndent(level);

        he.Tag.WriteStartBegin(w);
        foreach (var attr in he.Attrs())
            attr.WriteTo(w);
        he.Tag.WriteStartEnd(w);

        if (he.Count == 0 || he.All(x => x is Text or CData))
        {
            foreach (var child in he)
                child.PrettyPrintTo(w, level + 1);

            if (!he.Tag.IsVoid())
            {
                he.Tag.WriteClose(w);
                if (!he.IsInline())
                    w.WriteLine();
            }
        }
        else
        {
            w.WriteLine();

            foreach (var child in he)
            {
                if (child is He x && x.IsInline())
                    w.WriteIndent(level+1);

                child.PrettyPrintTo(w, level + 1);
                {
                    if (child is He e && e.Tag.IsVoid())
                    {
                        w.WriteLine();
                    }
                }
            }

            if (!he.Tag.IsVoid())
            {
                w.WriteIndent(level);
                he.Tag.WriteClose(w);
                if (!he.IsInline())
                    w.WriteLine();
            }
        }
    }

    private static void PrettyPrintDocument(HtmlDocument doc, TextWriter w)
    {
        doc.DocType.WriteTo(w);
        w.WriteLine();
        doc.Html.WriteStartTag(w);

        w.WriteLine();
        doc.Head.WriteStartTag(w);
        w.WriteLine();
        foreach (var child in doc.Head)
        {
            child.PrettyPrintTo(w, 1);
            if (child is He e && e.Tag.IsVoid())
                w.WriteLine();
        }
        doc.Head.WriteCloseTag(w);
        w.WriteLine();

        doc.Body.WriteStartTag(w);
        w.WriteLine();
        foreach (var child in doc.Body)
        {
            child.PrettyPrintTo(w, 1);
            if (child is He e && e.Tag.IsVoid())
                w.WriteLine();
        }

        doc.Body.WriteCloseTag(w);
        w.WriteLine();

        doc.Html.WriteCloseTag(w);
    }
}