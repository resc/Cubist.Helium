using System.Collections.Concurrent;

namespace Cubist.Helium;

/// <summary> the element tree base class </summary>
public abstract class Node
{
    /// <summary> Attach user data to this node, You can use this field to find nodes in the element tree </summary>
    public object? UserData { get; init; } = null;

    /// <summary> Writes this node's content to the <see cref="TextWriter"/> <paramref name="w"/> </summary>
    public abstract void WriteTo(TextWriter w);

    /// <summary> returns the non-indented html representation of this node </summary>
    public override string ToString()
    {
        var sw = new StringWriter();
        WriteTo(sw);
        return sw.ToString();
    }
}