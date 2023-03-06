using static System.Net.WebRequestMethods;

namespace Cubist.Helium;

/// <summary> Represents a html tag name with some extra information. </summary>
public readonly record struct Tag(string Value, TagOptions Options)
{
    /// <summary> implicit conversion from a string to a tag, adds TagOptions </summary>
    public static implicit operator Tag(string s) => new(s, GetOption(s));

    /// <summary> Writes the start tag.  <c>&lt;{tag}&gt;</c> </summary>
    public void WriteStart(TextWriter w)
    {
        WriteStartBegin(w);
        WriteStartEnd(w);
    }

    /// <summary> Writes the start tag begin <c>&lt;{tag}</c> so that attributes can be written. </summary>
    public void WriteStartBegin(TextWriter w)
    {
        w.Write('<');
        WriteTag(w);
    }

    private void WriteTag(TextWriter w)
    {
        if (Value.Length == 1)
            w.Write(Value[0]);
        else
            w.Write(Value);
    }

    /// <summary> Writes the start tag's closing <c>&gt;</c> character. </summary>
    public void WriteStartEnd(TextWriter w)
    {
        w.Write(">");
    }

    /// <summary> Writes the close tag <c>&lt;/{tag}&gt;</c>. </summary>
    public void WriteClose(TextWriter w)
    {
        if (this.IsVoid()) return;
        w.Write("</");
        WriteTag(w);
        w.Write('>');
    }


    /// <summary> See https://html.spec.whatwg.org/multipage/dom.html#metadata-content </summary>
    private static readonly IReadOnlySet<string> _metaDataContent = new HashSet<string>
    {
        "base", "link", "meta", @"noscript", "script", "style", "template", "title"
    };

    /// <summary> See https://html.spec.whatwg.org/multipage/dom.html#flow-content </summary>
    private static readonly IReadOnlySet<string> _flowContent = new HashSet<string>
    {
        "a", "abbr", "address", "area" /* if it is a descendant of a map element */, "article", "aside", "audio", "b",
        "bdi", "bdo", @"blockquote", "br", "button", "canvas", "cite", "code", "data", "datalist", "del", "details",
        "dfn", "dialog", "div", "dl", "em", "embed", "fieldset", "figure", "footer", "form", "h1", "h2", "h3", "h4",
        "h5", "h6", "header", "hgroup", "hr", "i", "iframe", "img", "input", "ins", "kbd", "label",
        "link" /*if it is allowed in the body*/, "main" /*if it is a hierarchically correct main element*/,
        "map", "mark", "math" /* MathML */, "menu", "meta" /* if the itemprop attribute is present */, "meter", "nav",
        @"noscript", "object", "ol", "output", "p", "picture", "pre", "progress", "q", "ruby", "s", @"samp", "script",
        "section", "select", "slot", "small", "span", "strong", "sub", "sup", "svg" /* SVG */, "table", "template",
        "text", "textarea", "time", "u", "ul", "var", "video", "wbr",
    };

    /// <summary> See https://html.spec.whatwg.org/multipage/dom.html#sectioning-content </summary>
    private static readonly IReadOnlySet<string> _sectioningContent = new HashSet<string>
    {
        "article", "aside", "body", "nav", "section", "header", "footer", "address",
        "h1", "h2", "h3", "h4", "h5", "h6", "hgroup"
    };

    /// <summary> See https://html.spec.whatwg.org/multipage/dom.html#heading-content </summary>
    private static readonly IReadOnlySet<string> _headingContent = new HashSet<string>
    {
        "h1","h2","h3","h4","h5","h6"
    };
    
    /// <summary> See https://html.spec.whatwg.org/multipage/dom.html#phrasing-content </summary>
    private static readonly IReadOnlySet<string> _phrasingContent = new HashSet<string>
    {
        "a", "abbr", "area", "audio", "b", "bdi", "bdo", "br", "button", "canvas", "cite", "code", "data",
        "datalist", "del", "dfn", "em", "embed", "i", "iframe", "img", "input", "ins", "kbd",
        "label", "link", "map", "mark", "math", "meta", "meter", @"noscript", "object", "output", "picture", "progress",
        "q", "ruby", "s", @"samp", "script", "select", "slot", "small", "span", "strong", "sub", "sup",
        "svg", "template", "textarea", "time", "u", "var", "video", "wbr",
    };

    /// <summary> See https://html.spec.whatwg.org/multipage/dom.html#embedded-content-2 </summary>
    private static readonly IReadOnlySet<string> _embeddedContent = new HashSet<string>
    {
        "audio", "canvas", "embed", "iframe", "img", "math", "object", "picture", "svg", "video"
    };

    /// <summary> See https://html.spec.whatwg.org/multipage/dom.html#script-supporting-elements </summary>
    private static readonly IReadOnlySet<string> _scriptContent = new HashSet<string>
    {
        "script", "template", "slot"
    };


    /// <summary> See https://www.w3.org/TR/2011/WD-html-markup-20110113/syntax.html#void-elements </summary>
    private static readonly IReadOnlySet<string> _voidElements = new HashSet<string>
    {
        "area", "base", "br", "col", "command",
        "embed", "hr", "img", "input", "keygen",
        "link", "meta", "param", "source", "track", "wbr"
    };

    /// <summary> See <a href="https://html.spec.whatwg.org/multipage/text-level-semantics.html#usage-summary" >text-level semantics</a> </summary>
    private static readonly IReadOnlySet<string> _inlineElements = new HashSet<string>
    {
        "a", "abbr", "b", "bdi", "bdo", "br", "cite", "code", "data", "dfn", "em",
        "i", "kbd", "mark", "q", "rp", "rt", "ruby", "s", @"samp", "small", "span",
        "strong", "sub", "sup", "time", "u", "var", "wbr",
    };

    /// <summary> See <a href="https://html.spec.whatwg.org/multipage/grouping-content.html" >grouping semantics</a> </summary>
    private static readonly IReadOnlySet<string> _groupingElements = new HashSet<string>
    {
        @"blockquote", "dd", "div", "dl", "dt", "figcaption", "figure",
        "hr", "li", "main","menu", "ol", "p", "pre", "ul",
    };

    /// <summary> See <a href="https://html.spec.whatwg.org/multipage/grouping-content.html" >grouping semantics</a> </summary>
    private static readonly IReadOnlySet<string> _tableElements = new HashSet<string>
    {
        "table", "caption", "colgroup", "col", "tbody", "thead", @"tfoot", "tr", "td", "th",
    };

    /// <summary> See <a href="https://html.spec.whatwg.org/multipage/grouping-content.html" >grouping semantics</a> </summary>
    private static readonly IReadOnlySet<string> _formElements = new HashSet<string>
    {
        "form", "label", "input", "button", "select", "datalist", "optgroup", "option", "textarea", "output",
        "progress", "meter", "fieldset", "legend", "select", "datalist", "optgroup", "option", "textarea", "output",
    };
    /// <summary> See <a href="https://html.spec.whatwg.org/multipage/grouping-content.html" >grouping semantics</a> </summary>
    private static readonly IReadOnlySet<string> _interactiveElements = new HashSet<string>
    {
        "details", "summary", "a", "button", "input",  "option", "dialog",
    };

    /// <summary> See https://developer.mozilla.org/en-US/docs/Web/HTML/Reference </summary>
    private static readonly IReadOnlySet<string> _deprecatedElements = new HashSet<string>
    {
        "acronym", "applet", @"bgsound", "big", "blink", "center", "content", "dir",
        "font", "frame", @"frameset", "image", "keygen", "marquee", "menuitem", @"nobr",
        @"noembed", @"noframes", "param", "plaintext", "rb", "rtc", "shadow", "spacer", "strike",
        "tt", "xmp"
    };

    /// <summary> https://html.spec.whatwg.org/multipage/grouping-content.html#usage-summary </summary>
    private static readonly IReadOnlySet<string> _html5Elements = _metaDataContent
        .Concat(_flowContent)
        .Concat(_sectioningContent)
        .Concat(_headingContent)
        .Concat(_phrasingContent)
        .Concat(_embeddedContent)
        .Concat(_scriptContent)
        .Concat(_voidElements)
        .Concat(_inlineElements)
        .Concat(_groupingElements)
        .Concat(_tableElements)
        .Concat(_formElements)
        .Concat(_interactiveElements)
        .ToHashSet();

    /// <summary> See https://html.spec.whatwg.org/#valid-custom-element-name </summary>
    private static readonly IReadOnlySet<string> _hyphenatedSvgMathMlElements = new HashSet<string>
    {
        "annotation-xml", "color-profile",
        "font-face", "font-face-format",
        "font-face-name", "font-face-src",
        "font-face-uri", "missing-glyph"
    };

    private static bool IsCustomElement(string s) =>
        s.Contains("-", StringComparison.Ordinal) &&
        !_hyphenatedSvgMathMlElements.Contains(s);

    /// <summary> https://www.w3.org/TR/2011/WD-html-markup-20110113/syntax.html#void-elements </summary>
    private static TagOptions GetOption(string tag)
    {
        var option = TagOptions.None;
        if (_deprecatedElements.Contains(tag))
            option = TagOptions.Deprecated;
        if (_html5Elements.Contains(tag))
        {
            option |= TagOptions.Html5;

            if (_metaDataContent.Contains(tag))
                option |= TagOptions.Metadata;

            if (_flowContent.Contains(tag))
                option |= TagOptions.Flow;

            if (_sectioningContent.Contains(tag))
                option |= TagOptions.Section;

            if (_headingContent.Contains(tag))
                option |= TagOptions.Heading;

            if (_phrasingContent.Contains(tag))
                option |= TagOptions.Phrasing;

            if (_embeddedContent.Contains(tag))
                option |= TagOptions.EmbeddedContent;

            if (_scriptContent.Contains(tag))
                option |= TagOptions.Script;

            if (_voidElements.Contains(tag))
                option |= TagOptions.Void;

            if (_inlineElements.Contains(tag))
                option |= TagOptions.Inline;

            if (_groupingElements.Contains(tag))
                option |= TagOptions.Grouping;

            if (_tableElements.Contains(tag))
                option |= TagOptions.Table;

            if (_formElements.Contains(tag))
                option |= TagOptions.Form;

            if (_interactiveElements.Contains(tag))
                option |= TagOptions.Interactive;
        }
        else if (IsCustomElement(tag))
        {
            option |= TagOptions.Custom;
        }
        else
        {
            option = TagOptions.Foreign;
        }
        return option;
    }

}