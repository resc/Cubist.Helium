using System.Collections;

namespace Cubist.Helium;

/// <summary>
/// <see cref="He"/> stands for HtmlElement, and also is the element Helium.
/// </summary>
public class He : Node, IList<Node>
{
    public static He DocType() => new He(new Tag(@"!DOCTYPE", TagOptions.Html5 | TagOptions.Void)).Attr("html");

    public Tag Tag { get; }

    private List<Node>? _nodes;
    private List<(string, object?)>? _attrs;

    public He(Tag tag, params (string name, object? value)[] attrs)
    {
        Tag = tag;
        Attr(attrs);
    }

    public He Attr(string name, object? value = null)
    {
        _attrs ??= new();
        _attrs.Add((name, value));
        return this;
    }

    public He Attr(params (string name, object? value)[] attrs)
    {
        if (attrs.Length == 0) return this;
        _attrs ??= new(attrs.Length);
        _attrs.AddRange(attrs);
        return this;
    }

    public IEnumerable<(string, object?)> Attrs()
    {
        if (_attrs == null) yield break;
        foreach (var attr in _attrs)
            yield return attr;
    }

    public override void WriteTo(TextWriter w)
    {
        if (_attrs == null || _attrs.Count == 0)
        {
            Tag.WriteStart(w);
        }
        else
        {
            Tag.WriteStartBegin(w);
            foreach (var attr in _attrs)
                attr.WriteTo(w);

            Tag.WriteStartEnd(w);
        }

        if (_nodes != null)
        {
            foreach (var node in _nodes)
                node.WriteTo(w);
        }

        if (!Tag.IsVoid())
            Tag.WriteClose(w);
    }



    public IEnumerator<Node> GetEnumerator()
    {
        if (_nodes == null) yield break;
        foreach (var node in _nodes)
            yield return node;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(string text)
        => Add(new Text(text));

    public void Add(Node item)
    {
        EnsureNotVoid();
        _nodes ??= new();
        _nodes.Add(item);
    }
    public void Clear()
    {
        _nodes = null;
    }

    public bool Contains(Node item)
    {
        return _nodes?.Contains(item) ?? false;
    }

    public void CopyTo(Node[] array, int arrayIndex)
    {
        _nodes?.CopyTo(array, arrayIndex);
    }

    public bool Remove(Node item)
    {
        return _nodes?.Remove(item) ?? false;
    }

    public int Count => _nodes?.Count ?? 0;

    public bool IsReadOnly => false;

    public int IndexOf(Node item)
    {
        return _nodes?.IndexOf(item) ?? -1;
    }

    public void Insert(int index, Node item)
    {
        EnsureNotVoid();
        _nodes ??= new();
        _nodes.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        if (_nodes == null) throw new ArgumentOutOfRangeException(nameof(index));
        _nodes.RemoveAt(index);
    }

    public Node this[int index]
    {
        get
        {
            if (_nodes == null) throw new ArgumentOutOfRangeException(nameof(index));
            return _nodes[index];
        }
        set
        {
            EnsureNotVoid();
            if (_nodes == null) throw new ArgumentOutOfRangeException(nameof(index));
            _nodes[index] = value;
        }
    }

    private void EnsureNotVoid()
    {
        if (Tag.IsVoid())
            throw new InvalidOperationException($"<{Tag.Value}> doesn't allow child nodes");
    }
}