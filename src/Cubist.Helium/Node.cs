using System.Collections.Concurrent;

namespace Cubist.Helium;

public abstract class Node
{
    /// <summary> Attach user data to this node, You can use this field to find nodes in the element tree </summary>
    public object? UserData { get; init; } = null;

    public abstract void WriteTo(TextWriter w);


    public override string ToString()
    {
        var sw = new StringWriter();
        WriteTo(sw);
        return sw.ToString();
    }
}