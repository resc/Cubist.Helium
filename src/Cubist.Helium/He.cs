using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;

namespace Cubist.Helium;

/// <summary> <see cref="He"/> is short for HtmlElement, and also the element Helium.  </summary>
public partial class He : Node, IList<Node>
{
    private List<Node>? _nodes;

    private List<(string, object?)>? _attrs;

    /// <summary> Creates a new <see cref="He"/> instance </summary>
    public He(Tag tag)
    {
        Tag = tag;
    }

    /// <summary> Creates a new <see cref="He"/> instance </summary>
    public He(Tag tag, params (string, object?)[] attrs)
    {
        Tag = tag;
        Attr(attrs);
    }

    /// <summary> This element's tag </summary>
    public Tag Tag { get; }

    /// <summary> The number of child nodes in this element </summary>
    public int Count => _nodes?.Count ?? 0;

    /// <summary> Sets or the child node at the given <paramref name="index"/> </summary>
    public Node this[int index]
    {
        get
        {
            if (_nodes == null)
                throw new ArgumentOutOfRangeException(nameof(index));

            return _nodes[index];
        }
    }

    /// <summary> Adds an attribute </summary>
    /// <param name="name">the attribute name</param>
    /// <param name="value">the optional attribute value</param>
    public He Attr(string name, object? value = null)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("name cannot be null or empty.", nameof(name));

        _attrs ??= new();
        _attrs.Add((name, value switch
        {
            ITemplate t => new Template(t),
            _ => value
        }));
        return this;
    }

    /// <summary> Adds one or more attributes </summary>
    /// <param name="attrs">the attribute tuples</param> 
    public He Attr(params (string name, object? value)[] attrs)
    {
        foreach (var (name, value) in attrs)
            Attr(name, value);

        return this;
    }

    /// <summary> Adds the attribute only if <paramref name="condition"/> is true </summary>
    public He CAttr(bool condition, string name, object? value = null)
    {
        if (condition)
            Attr(name, value);

        return this;
    }

    /// <summary> returns this element's attributes </summary>
    public IEnumerable<(string, object?)> Attrs()
    {
        if (_attrs == null) yield break;
        foreach (var attr in _attrs)
            yield return attr;
    }

    /// <inheritdoc cref="Node.WriteTo"/>
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

    /// <inheritdoc cref="Node.PrettyPrintTo"/>>
    public override void PrettyPrintTo(IndentWriter w)
    {
        var indent = !this.IsInline();

        this.WriteStartTag(w);

        var allChildrenInline = this.All(n => n.IsInline());
        using (w.Indent())
        {
            if (indent && !allChildrenInline)
                w.WriteLine();

            foreach (var child in this)
                child.PrettyPrintTo(w);

            if (indent && !allChildrenInline && this.Count > 0 && this.Last().IsInline())
                w.WriteLine();
        }


        if (!Tag.IsVoid())
            this.WriteCloseTag(w);

        if (indent)
            w.WriteLine();
    }

    /// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
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

    /// <summary> Adds the content to this element </summary>
    public He Add(IEnumerable content)
    {
        foreach (var c in content)
            Add(c);

        return this;
    }

    /// <summary> Adds the content to this element </summary>
    public He Add(object? content) => content switch
    {
        Node n => Add(n),
        string s => Add(s),
        ITuple { Length: 2 } tuple => Attr(tuple[0] as string ?? $"{tuple[0]}", tuple[1]),
        ITemplate t => Add(new Template(t)),
        JsonNode json => Add(Json(json)),
        IEnumerable nodes => AddRange(nodes),
        bool boolValue => Add(boolValue.ToString()),
        int intValue => Add(intValue.ToString()),
        double doubleValue => Add(doubleValue.ToString(CultureInfo.CurrentCulture)),
        null => this,
        _ => AddOther(content)
    };

    private He AddRange(IEnumerable content)
    {
        foreach (var item in content)
            Add(item);
        return this;
    }

    private He AddOther(object content) =>
        content.GetType().IsPrimitive
            ? Add(content.ToString()!)
            : Add(new CData($"{content}"));

    /// <summary> Adds the content to this element </summary>
    public He Add(params (string, object?)[] attrs)
        => Attr(attrs);

    /// <summary> Adds the content to this element </summary>
    public He Add((string, object?) attr)
        => Attr(attr);

    /// <summary> Adds the content to this element </summary>
    public He Add(string content)
        => Add(new Text(content));

    /// <summary> Adds the content to this element </summary>
    public He Add(Text content)
        => Add((Node)content);

    /// <summary> Adds the content to this element </summary>
    public He Add(CData content)
        => Add((Node)content);

    /// <summary> Adds the content to this element </summary>
    public He Add(Comment content)
        => Add((Node)content);

    /// <summary> Adds the content to this element </summary>
    public He Add(He content)
        => Add((Node)content);

    /// <summary> Adds the content to this element </summary>
    public He Add(Node content)
    {
        EnsureNotVoid();
        _nodes ??= new();
        _nodes.Add(content);
        return this;
    }

    void ICollection<Node>.Add(Node item)
        => Add(item);

    void ICollection<Node>.Clear()
    {
        _nodes = null;
    }

    bool ICollection<Node>.Contains(Node item)
    {
        return _nodes?.Contains(item) ?? false;
    }

    void ICollection<Node>.CopyTo(Node[] array, int arrayIndex)
    {
        _nodes?.CopyTo(array, arrayIndex);
    }

    bool ICollection<Node>.Remove(Node item)
    {
        return _nodes?.Remove(item) ?? false;
    }

    bool ICollection<Node>.IsReadOnly => false;

    /// <summary> Sets or sets the child node at the given <paramref name="index"/> </summary>
    Node IList<Node>.this[int index]
    {
        get => this[index];
        set
        {
            EnsureNotVoid();
            if (_nodes == null) throw new ArgumentOutOfRangeException(nameof(index));
            _nodes[index] = value;
        }
    }

    int IList<Node>.IndexOf(Node item)
    {
        return _nodes?.IndexOf(item) ?? -1;
    }

    void IList<Node>.Insert(int index, Node item)
    {
        EnsureNotVoid();
        _nodes ??= new();
        _nodes.Insert(index, item);
    }

    void IList<Node>.RemoveAt(int index)
    {
        if (_nodes == null) throw new ArgumentOutOfRangeException(nameof(index));
        _nodes.RemoveAt(index);
    }


    private void EnsureNotVoid()
    {
        if (Tag.IsVoid())
            throw new InvalidOperationException($"<{Tag.Value}> doesn't allow child nodes");
    }
}