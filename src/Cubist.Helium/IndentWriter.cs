using System.Text;

namespace Cubist.Helium;

public class IndentWriter : TextWriter
{
    private bool _writeIndent;

    public TextWriter Inner { get; }

    public int Level { get; private set; }

    public IndentWriter(TextWriter inner)
    {
        Inner = inner;
    }

    public IndentBlock Indent() => new(this);

    public override void Write(string? s)
    {
        if (s != null) Write(s.AsSpan());
    }

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

    public override void Write(char value)
    {
        WriteIndent();
        Inner.Write(value);

        if (value == '\n')
            _writeIndent = true;
    }

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

    public override Encoding Encoding => Inner.Encoding;

    public struct IndentBlock : IDisposable
    {
        private IndentWriter? _w;

        public IndentBlock(IndentWriter w)
        {
            _w = w;
            _w.Level++;
        }

        public void Dispose()
        {
            if (_w == null) return;
            _w.Level--;
            _w = null;
        }
    }
}