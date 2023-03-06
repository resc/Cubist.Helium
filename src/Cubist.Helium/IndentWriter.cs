using System.Text;

namespace Cubist.Helium;

/// <summary> a <see cref="TextWriter"/> that writes indented text </summary>
public class IndentWriter : TextWriter
{
    private bool _writeIndent;

    /// <summary> The inner writer </summary>
    public TextWriter Inner { get; }

    /// <summary> The current indent level, change this by using <see cref="Indent"/> </summary>
    public int Level { get; private set; }

    /// <summary> Creates a new instance of <see cref="IndentWriter"/> </summary>
    public IndentWriter(TextWriter inner)
    {
        Inner = inner;
    }
    /// <summary> Indent the code one level, use in a using block to auto-dedent. </summary>
    public IndentBlock Indent() => new(this);

    /// <inheritdoc cref="TextWriter.Write(string?)"/>
    public override void Write(string? s)
    {
        if (s != null) Write(s.AsSpan());
    }

    /// <inheritdoc cref="TextWriter.Write(char[],int,int)"/>
    public override void Write(char[] value, int start, int count)
    {
        while (true)
        {
            if (count == 0)
                return;

            WriteIndent();

            var (nlIndex, nlCount) = NewlineIndex(value, start, count);

            if (nlIndex < 0)
            {
                Inner.Write(value, start, count);
                return;
            }

            var lineCount = nlIndex - start;
            Inner.Write(value, start, lineCount);
            Inner.WriteLine();
            _writeIndent = true;
            start = start + lineCount + nlCount;
            count = count - lineCount - nlCount;
        }
    }

    /// <inheritdoc cref="TextWriter.Write(char)"/>
    public override void Write(char value)
    {
        WriteIndent();
        Inner.Write(value);

        if (value == '\n')
            _writeIndent = true;
    }

    /// <inheritdoc cref="TextWriter.WriteLine()"/>
    public override void WriteLine()
    {
        WriteIndent();
        Inner.WriteLine();
        _writeIndent = true;
    }

    private (int index, int count) NewlineIndex(char[] value, int startIndex, int count)
    {
        var nIndex = Array.IndexOf(value, '\n', startIndex, count);
        if (nIndex < startIndex) return (-1, 0);
        var hasR = nIndex > startIndex && value[nIndex - 1] == '\r';
        return hasR ? (nIndex - 1, 2) : (nIndex, 1);
    }

    private void WriteIndent()
    {
        if (_writeIndent)
        {
            Inner.WriteIndent(Level);
            _writeIndent = false;
        }
    }

    /// <inheritdoc cref="TextWriter.Encoding"/>
    public override Encoding Encoding => Inner.Encoding;

    /// <summary> Represent a indentation level </summary>
    public struct IndentBlock : IDisposable
    {
        private IndentWriter? _w;

        /// <summary> Creates a <see cref="IndentBlock"/> value</summary>
        public IndentBlock(IndentWriter w)
        {
            _w = w;
            _w.Level++;
        }

        /// <inheritdoc cref="IDisposable.Dispose"/>>
        public void Dispose()
        {
            if (_w == null) return;
            _w.Level--;
            _w = null;
        }
    }
}