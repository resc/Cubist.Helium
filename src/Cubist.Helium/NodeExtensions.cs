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
}