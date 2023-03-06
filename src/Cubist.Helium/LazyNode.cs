﻿namespace Cubist.Helium;

/// <summary>
/// Every time this node is rendered, the value function
/// is called to retrieve the value to render. 
/// </summary>
public sealed class LazyNode<T> : Node
{
    private readonly Func<T> _value;
    private readonly He _lazy = new("lazy");

    private ICollection<Node> LazyAsCollection => _lazy;

    /// <summary> Creates a new instance of <see cref="LazyNode{T}"/> </summary>
    public LazyNode(Func<T> value)
    {
        _value = value;
    }

    /// <inheritdoc cref="Node.WriteTo"/>>
    public override void WriteTo(TextWriter w)
    {
        var value = _value();
        LazyAsCollection.Clear();
        _lazy.Add(value);
        _lazy[0].WriteTo(w);
    }
}