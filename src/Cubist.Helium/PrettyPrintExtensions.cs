using System.Buffers;

namespace Cubist.Helium;

/// <summary> Extension methods to write formatted and indented html. </summary>
public static class PrettyPrintExtensions
{
    /// <summary> pretty-prints this node to a string </summary>
    public static string PrettyPrint(this Node n)
    {
        using var sw = new StringWriter();
        using var iw = new IndentWriter(sw);
        n.PrettyPrintTo(iw);
        return sw.ToString();
    }

    /// <summary> Returns true if this is an inline node, with only inline child nodes </summary>
    public static bool IsInline(this Node n)
        => n is CData ||
           (n is Text t && !t.Value.Contains('\n')) ||
           (n is He he && (he.Tag.IsInline() || he.Tag==Tag.Empty) &&
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