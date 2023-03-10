// ReSharper disable UnusedMember.Global

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.Json;

namespace Cubist.Helium;

public partial class He
{
    // ReSharper disable once InconsistentNaming
    private static CultureInfo IC => CultureInfo.InvariantCulture;

    /// <summary>
    /// Use this to create attribute tuples like ("checked", Null)
    /// for value-less attributes, to avoid type-inference breakdowns.
    /// </summary> 
    public static object? Null => null;

    /// <inheritdoc cref="Tags.DocType"/>
    public static He DocType() => new(Tags.DocType, ("html", Null));

    /// <summary> Creates an empty document </summary>
    public static HtmlDocument Document() => new();

    /// <summary> Creates a document with the given <c>head</c> and <c>body</c> elements </summary>
    public static HtmlDocument Document(He head, He body) => new(head, body);

    /// <inheritdoc cref="Tags.A"/>
    public static He A(Uri href, params object[] content) => new(Tags.A) { ("href", href), content };

    /// <inheritdoc cref="Tags.A"/>
    public static He A(string href, params object[] content) => new(Tags.A) { ("href", href), content };

    /// <inheritdoc cref="Tags.Abbr"/>
    public static He Abbr(params object[] content) => new(Tags.Abbr) { content };

    /// <inheritdoc cref="Tags.Address"/>
    public static He Address(params object[] content) => new(Tags.Address) { content };

    /// <inheritdoc cref="Tags.Area"/>
    public static He Area(string shape, (double, double, double, double) coords, string alt, string href) =>
        new(Tags.Area)
        {
            (nameof(shape), shape),
            (nameof(coords), string.Format(IC,
                "{0},{1},{2},{3}",
                coords.Item1, coords.Item2,
                coords.Item3, coords.Item4)),
            (nameof(alt), alt),
            (nameof(href), href)
        };

    /// <inheritdoc cref="Tags.Article"/>
    public static He Article(params object[] content) => new(Tags.Article) { content };

    /// <inheritdoc cref="Tags.Aside"/>
    public static He Aside(params object[] content) => new(Tags.Aside) { content };

    /// <inheritdoc cref="Tags.Audio"/>
    public static He Audio(string type, string src) => new(Tags.Audio) { ("controls", null), Source(type, src) };

    /// <inheritdoc cref="Tags.B"/>
    public static He B(params object[] content) => new(Tags.B) { content };

    /// <inheritdoc cref="Tags.Base"/>
    public static He Base(string? target = null, string? href = null)
        => new He(Tags.Base)
            .CAttr(href != null, nameof(href), href)
            .CAttr(target != null, nameof(target), target);

    /// <inheritdoc cref="Tags.Bdi"/>
    public static He Bdi(params object[] content) => new(Tags.Bdi) { content };

    /// <inheritdoc cref="Tags.Bdo"/>
    public static He Bdo(string dir, params object[] content) => new(Tags.Bdo, (nameof(dir), dir)) { content };

    /// <inheritdoc cref="Tags.BlockQuote"/>
    public static He BlockQuote(params object[] content) => new(Tags.BlockQuote) { content };

    /// <inheritdoc cref="Tags.Body"/>
    public static He Body(params object[] content) => new(Tags.Body) { content };

    /// <inheritdoc cref="Tags.Br"/>
    public static He Br() => new(Tags.Br);

    /// <inheritdoc cref="Tags.Button"/>
    public static He Button(string type, string name, string value, params object[] content) => new(Tags.Button)
    {
        (nameof(type), type),
        (nameof(name), name),
        (nameof(value), value),
        content,
    };

    /// <inheritdoc cref="Tags.Canvas"/>
    public static He Canvas(params object[] content) => new(Tags.Canvas) { content };

    /// <inheritdoc cref="Tags.Caption"/>
    public static He Caption(params object[] content) => new(Tags.Caption) { content };

    /// <summary> Creates a CData node from the given content </summary>
    public static CData CData(object content) => new(content);

    /// <inheritdoc cref="Tags.Cite"/>
    public static He Cite(params object[] content) => new(Tags.Cite) { content };

    /// <inheritdoc cref="Tags.Code"/>
    public static He Code(params object[] content) => new(Tags.Code) { content };

    /// <inheritdoc cref="Tags.Col"/>
    public static He Col(params object[] content) => new(Tags.Col) { content };

    /// <inheritdoc cref="Tags.Colgroup"/>
    public static He Colgroup(params object[] content) => new(Tags.Colgroup) { content };

    /// <inheritdoc cref="Comment(string)"/>
    public static Comment Comment(string text) => new(text);

    /// <inheritdoc cref="Helium.Css"/>
    public static Css Css(string selector, params (string, object?)[] attributes) => new(selector, attributes);

    /// <summary>Creates a class attribute</summary>
    public static (string, object?) Class(params string[] classes)
        => Class((IEnumerable<string>)classes);

    /// <summary>Creates a class attribute</summary>
    public static (string, object?) Class(IEnumerable<string> classes) => ("class", string.Join(" ", classes));

    /// <summary> Creates a custom tag </summary>
    public static He Custom(string tag, params object[] content) => new(tag) { content };

    /// <summary> Creates a custom tag </summary>
    public static He Custom(Tag tag, params object[] content) => new(tag) { content };

    /// <inheritdoc cref="Tags.Data"/>
    public static He Data(object value, params object[] content) => new(Tags.Data) { (nameof(value), value), content };

    /// <inheritdoc cref="Tags.Datalist"/>
    public static He Datalist(params object[] content) => new(Tags.Datalist) { content };

    /// <inheritdoc cref="Tags.Dd"/>
    public static He Dd(params object[] content) => new(Tags.Dd) { content };

    /// <inheritdoc cref="Tags.Del"/>
    public static He Del(params object[] content) => new(Tags.Del) { content };

    /// <inheritdoc cref="Tags.Details"/>
    public static He Details(params object[] content) => new(Tags.Details) { content };

    /// <inheritdoc cref="Tags.Dfn"/>
    public static He Dfn(params object[] content) => new(Tags.Dfn) { content };

    /// <inheritdoc cref="Tags.Dialog"/>
    public static He Dialog(params object[] content) => new(Tags.Dialog) { content };

    /// <inheritdoc cref="Tags.Div"/>
    public static He Div(params object[] content) => new(Tags.Div) { content };

    /// <inheritdoc cref="Tags.Dl"/>
    public static He Dl(params object[] content) => new(Tags.Dl) { content };

    /// <inheritdoc cref="Tags.Dt"/>
    public static He Dt(params object[] content) => new(Tags.Dt) { content };

    /// <inheritdoc cref="Tags.Em"/>
    public static He Em(params object[] content) => new(Tags.Em) { content };

    /// <inheritdoc cref="Tags.Embed"/>
    public static He Embed(string type, string src, params object[] content) => new(Tags.Embed)
    {
        (nameof(src), src),
        (nameof(type), type),
        content
    };

    /// <inheritdoc cref="Tags.Fieldset"/>
    public static He Fieldset(params object[] content) => new(Tags.Fieldset) { content };

    /// <inheritdoc cref="Tags.Figcaption"/>
    public static He Figcaption(params object[] content) => new(Tags.Figcaption) { content };

    /// <inheritdoc cref="Tags.Figure"/>
    public static He Figure(params object[] content) => new(Tags.Figure) { content };

    /// <inheritdoc cref="Tags.Footer"/>
    public static He Footer(params object[] content) => new(Tags.Footer) { content };

    /// <inheritdoc cref="Tags.Form"/>
    public static He Form(string method, string action, params object[] content) => new(Tags.Form)
    {
        (nameof(method), method),
        (nameof(action), action),
        content
    };

    /// <inheritdoc cref="Tags.H1"/>
    public static He H1(params object[] content) => new(Tags.H1) { content };

    /// <inheritdoc cref="Tags.H2"/>
    public static He H2(params object[] content) => new(Tags.H2) { content };

    /// <inheritdoc cref="Tags.H3"/>
    public static He H3(params object[] content) => new(Tags.H3) { content };

    /// <inheritdoc cref="Tags.H4"/>
    public static He H4(params object[] content) => new(Tags.H4) { content };

    /// <inheritdoc cref="Tags.H5"/>
    public static He H5(params object[] content) => new(Tags.H5) { content };

    /// <inheritdoc cref="Tags.H6"/>
    public static He H6(params object[] content) => new(Tags.H6) { content };

    /// <inheritdoc cref="Tags.Head"/>
    public static He Head(params object[] content) => new(Tags.Head) { content };

    /// <inheritdoc cref="Tags.Header"/>
    public static He Header(params object[] content) => new(Tags.Header) { content };

    /// <inheritdoc cref="Tags.Hr"/>
    public static He Hr() => new(Tags.Hr);

    /// <inheritdoc cref="Tags.Html"/>
    public static He Html(params object[] content) => new(Tags.Html) { content };

    /// <inheritdoc cref="Tags.I"/>
    public static He I(params object[] content) => new(Tags.I) { content };

    /// <inheritdoc cref="Conditional"/>
    public static object If(bool condition, params object[] content)
        => If(() => condition, content);

    /// <inheritdoc cref="Conditional"/>
    public static object If(Func<bool> condition, params object[] content)
        => new Conditional(condition, () => content);

    /// <inheritdoc cref="Conditional"/>
    public static object If<T>(bool condition, Func<T> content) where T : notnull
        => If(() => condition, content);

    /// <inheritdoc cref="Conditional"/>
    public static object If<T>(Func<bool> condition, Func<T> content) where T : notnull
        => new Conditional(condition, () => content());

    /// <inheritdoc cref="Tags.Iframe"/>
    public static He Iframe(string title, string src) => new(Tags.Iframe)
    {
        (nameof(src), src),
        (nameof(title), title),
    };

    /// <inheritdoc cref="Tags.Img"/>
    public static He Img(string alt, string src, int? width = null, int? height = null)
        => new He(Tags.Img)
            {
                (nameof(src), src),
                (nameof(alt), alt)
            }
            .CAttr(width != null, nameof(width), width)
            .CAttr(height != null, nameof(height), height);

    /// <inheritdoc cref="Tags.Input"/>
    public static He Input(string type, string name, string id, params (string, object?)[] attrs) => new(Tags.Input)
    {
        (nameof(type), type),
        (nameof(name), name),
        (nameof(id), id),
        attrs,
    };

    /// <summary>creates an inline style attribute</summary>
    public static (string, object?) InlineStyle(params (string, object?)[] attrs)
        => ("style", new InlineCss(attrs));

    /// <inheritdoc cref="Tags.Ins"/>
    public static He Ins(params object[] content) => new(Tags.Ins) { content };

    ///  <summary> Renders the <paramref name="content"/> as serialized JSON</summary>
    public static Json Json(object content, JsonSerializerOptions? options = null) =>
        new(content) { Options = options! };

    /// <inheritdoc cref="Tags.Kbd"/>
    public static He Kbd(params object[] content) => new(Tags.Kbd) { content };

    /// <inheritdoc cref="Tags.Label"/>
    public static He Label(string @for, params object[] content) => new(Tags.Label)
    {
        (nameof(@for), @for),
        content
    };

    /// <inheritdoc cref="Tags.Legend"/>
    public static He Legend(params object[] content) => new(Tags.Legend) { content };

    /// <inheritdoc cref="Tags.Li"/>
    public static He Li(params object[] content) => new(Tags.Li) { content };

    /// <inheritdoc cref="Tags.Link"/>
    public static He Link(string rel, string href, params (string, object?)[] attrs) => new(Tags.Link)
    {
        (nameof(rel), rel),
        (nameof(href), href),
        attrs
    };

    /// <inheritdoc cref="Tags.Main"/>
    public static He Main(params object[] content) => new(Tags.Main) { content };

    /// <inheritdoc cref="Tags.Map"/>
    public static He Map(string name, params object[] content) => new(Tags.Map) { (nameof(name), name), content };

    /// <inheritdoc cref="Tags.Mark"/>
    public static He Mark(params object[] content) => new(Tags.Mark) { content };

    /// <inheritdoc cref="Tags.Meta"/>
    public static He Meta(params (string, object?)[] attrs) => new(Tags.Meta) { attrs };

    /// <inheritdoc cref="Tags.Meta"/>
    public static He Meta(string name, string content) =>
        new(Tags.Meta) { (nameof(name), name), (nameof(content), content) };

    /// <inheritdoc cref="Tags.Meta"/>
    public static He MetaHttpEquiv(string httpEquiv, object? content) => new(Tags.Meta)
        { ("http-equiv", httpEquiv), (nameof(content), content) };

    /// <inheritdoc cref="Tags.Meta"/>
    public static He MetaCharsetUtf8() => Meta("charset", "utf-8");

    /// <inheritdoc cref="Tags.Meta"/>
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public static He MetaRobots(bool index = true, bool follow = true, bool noarchive = false, bool nosnippet = false,
        bool noimageindex = false)
        => Meta("robots", MakeRobotsContent(index, follow, noarchive, nosnippet, noimageindex));

    [SuppressMessage("ReSharper", "IdentifierTypo")]
    private static string MakeRobotsContent(bool index, bool follow, bool noarchive, bool nosnippet, bool noimageindex)
    {
        var content = (index, follow) switch
        {
            (true, true) => @"index,follow",
            (true, false) => @"index,nofollow",
            (false, true) => @"noindex,follow",
            (false, false) => @"noindex,nofollow",
        };
        if (noarchive) content += @",noarchive";
        if (nosnippet) content += @",nosnippet";
        if (noimageindex) content += @",noimageindex";
        return content;
    }

    /// <summary>
    /// Sets the viewport to make your website look good on all devices:
    /// <c>&lt;meta name="viewport" content="width=device-width, initial-scale=1.0"&gt;</c>
    /// </summary>
    /// <returns></returns>
    public static He MetaViewPort() => new(Tags.Meta)
        { ("name", "viewport"), ("content", "width=device-width, initial-scale=1.0") };

    /// <inheritdoc cref="Tags.Meter"/>
    public static He Meter(double percent, params (string, object?)[] content) => new(Tags.Meter)
    {
        ("value", percent.ToString(IC)),
        content
    };

    /// <inheritdoc cref="Tags.Meter"/>
    public static He Meter(double value, double min, double max, params (string, object?)[] content) => new(Tags.Meter)
    {
        (nameof(value), value.ToString(IC)),
        (nameof(min), min.ToString(IC)),
        (nameof(max), max.ToString(IC)),
        content
    };

    /// <inheritdoc cref="Tags.Nav"/>
    public static He Nav(params object[] content) => new(Tags.Nav) { content };

    /// <inheritdoc cref="Tags.NoScript"/>
    public static He NoScript(params object[] content) => new(Tags.NoScript) { content };

    /// <inheritdoc cref="Tags.Object"/>
    public static He Object(params object[] content) => new(Tags.Object) { content };

    /// <inheritdoc cref="Tags.Ol"/>
    public static He Ol(params object[] content) => new(Tags.Ol) { content };

    /// <inheritdoc cref="Tags.Optgroup"/>
    public static He Optgroup(string label, params object[] content) =>
        new(Tags.Optgroup) { (nameof(label), label), content };

    /// <inheritdoc cref="Tags.Option"/>
    public static He Option(object? value, params object[] content) =>
        new(Tags.Option) { (nameof(value), value), content };

    /// <inheritdoc cref="Tags.Output"/>
    public static He Output(string @for, params object[] content) => new(Tags.Output) { (nameof(@for), @for), content };

    /// <inheritdoc cref="Tags.P"/>
    public static He P(params object[] content) => new(Tags.P) { content };

    /// <inheritdoc cref="Tags.Param"/>
    public static He Param(string name, object? value) =>
        new(Tags.Param) { (nameof(name), name), (nameof(value), value) };

    /// <inheritdoc cref="Tags.Picture"/>
    public static He Picture(params object[] content) => new(Tags.Picture) { content };

    /// <inheritdoc cref="Tags.Pre"/>
    public static He Pre(params object[] content) => new(Tags.Pre) { content };

    /// <inheritdoc cref="Tags.Progress"/>
    public static He Progress(double value, double max, params object[] content) => new(Tags.Progress)
    {
        (nameof(value), value.ToString(IC)),
        (nameof(max), max.ToString(IC)),
        content
    };

    /// <inheritdoc cref="Tags.Q"/>
    public static He Q(params object[] content) => new(Tags.Q) { content };

    /// <inheritdoc cref="Tags.Rp"/>
    public static He Rp(params object[] content) => new(Tags.Rp) { content };

    /// <inheritdoc cref="Tags.Rt"/>
    public static He Rt(params object[] content) => new(Tags.Rt) { content };

    /// <inheritdoc cref="Tags.Ruby"/>
    public static He Ruby(params object[] content) => new(Tags.Ruby) { content };

    /// <inheritdoc cref="Tags.S"/>
    public static He S(params object[] content) => new(Tags.S) { content };

    /// <inheritdoc cref="Tags.Samp"/>
    public static He Samp(params object[] content) => new(Tags.Samp) { content };

    /// <inheritdoc cref="Tags.Script"/>
    public static He Script(params object[] content) => new(Tags.Script) { content };

    /// <inheritdoc cref="Tags.Script"/>
    public static He Script(string type, string src, params object[] content) => new(Tags.Script)
    {
        (nameof(src), src),
        (nameof(type), type),
        content
    };

    /// <summary> Creates a javascript snippet that defines the simplest custom component class that does something.
    /// The returned value should be embedded in a <c>&lt;script&gt;</c> tag </summary>
    /// <param name="tag">the component tag, should contain at least one hyphen: <c>-</c> </param>
    /// <param name="templateId">the component's template id</param>
    /// <param name="mode">shadow dom 'mode' parameter</param>
    /// <returns></returns>
    public static Text DefineCustomElement(string tag, string templateId, string mode = "open")
        => new($@"customElements.define(
  ""{tag}"",
  class extends HTMLElement {{
    constructor() {{
      super();
      let template = document.getElementById(""{templateId}"");
      let templateContent = template.content;

      const shadowRoot = this.attachShadow({{ mode: ""{mode}"" }});
      const clone = templateContent.cloneNode(true);
      shadowRoot.appendChild(clone);
    }}
  }}
);
");

    /// <inheritdoc cref="Tags.Section"/>
    public static He Section(params object[] content) => new(Tags.Section) { content };

    /// <inheritdoc cref="Tags.Select"/>
    public static He Select(params object[] content) => new(Tags.Select) { content };

    /// <inheritdoc cref="Tags.Slot"/>
    public static He Slot(params object[] contents) => new(Tags.Slot) { contents };

    /// <inheritdoc cref="Tags.Slot"/>
    public static He Slot(string name, params object[] contents) => new(Tags.Slot) { (nameof(name), name), contents };

    /// <inheritdoc cref="Tags.Small"/>
    public static He Small(params object[] content) => new(Tags.Small) { content };

    /// <inheritdoc cref="Tags.Source"/>
    public static He Source(string type, string src) => new(Tags.Source, (nameof(src), src), (nameof(type), type));

    /// <inheritdoc cref="Tags.Span"/>
    public static He Span(params object[] content) => new(Tags.Span) { content };

    /// <inheritdoc cref="Tags.Strong"/>
    public static He Strong(params object[] content) => new(Tags.Strong) { content };

    /// <inheritdoc cref="Tags.Style"/>
    public static He Style(params object[] content) => new(Tags.Style) { content };

    /// <inheritdoc cref="Tags.Sub"/>
    public static He Sub(params object[] content) => new(Tags.Sub) { content };

    /// <inheritdoc cref="Tags.Summary"/>
    public static He Summary(params object[] content) => new(Tags.Summary) { content };

    /// <inheritdoc cref="Tags.Sup"/>
    public static He Sup(params object[] content) => new(Tags.Sup) { content };

    /// <inheritdoc cref="Tags.Svg"/>
    public static He Svg(params object[] content) => new(Tags.Svg) { content };

    /// <inheritdoc cref="Tags.Table"/>
    public static He Table(params object[] content) => new(Tags.Table) { content };

    /// <inheritdoc cref="Tags.Tbody"/>
    public static He Tbody(params object[] content) => new(Tags.Tbody) { content };

    /// <inheritdoc cref="Tags.Td"/>
    public static He Td(params object[] content) => new(Tags.Td) { content };

    /// <inheritdoc cref="Tags.Template"/>
    public static He Template(string id, params object[] content) => new(Tags.Template) { (nameof(id), id), content };

    /// <inheritdoc cref="Tags.Template"/>
    public static He Template(params object[] content) => new(Tags.Template) { content };

    /// <inheritdoc cref="Tags.Textarea"/>
    public static He Textarea(params object[] content) => new(Tags.Textarea) { content };

    /// <inheritdoc cref="Tags.Tfoot"/> 
    // ReSharper disable once IdentifierTypo
    public static He Tfoot(params object[] content) => new(Tags.Tfoot) { content };

    /// <inheritdoc cref="Tags.Th"/>
    public static He Th(params object[] content) => new(Tags.Th) { content };

    /// <inheritdoc cref="Tags.Thead"/>
    public static He Thead(params object[] content) => new(Tags.Thead) { content };

    /// <inheritdoc cref="Tags.Time"/>
    public static He Time(params object[] content) => new(Tags.Time) { content };

    /// <inheritdoc cref="Tags.Time"/>
    public static He Time(DateTime datetime, params object[] content) =>
        new(Tags.Time) { (nameof(datetime), datetime.ToString("u")), content };

    /// <inheritdoc cref="Tags.Title"/>
    public static He Title(params object[] content) => new(Tags.Title) { content };

    /// <inheritdoc cref="Tags.Tr"/>
    public static He Tr(params object[] content) => new(Tags.Tr) { content };

    /// <inheritdoc cref="Tags.Track"/>
    // ReSharper disable once IdentifierTypo
    public static He Track(string label, string src, string srclang, string kind) => new(Tags.Track)
    {
        (nameof(label), label),
        (nameof(src), src),
        (nameof(srclang), srclang),
        (nameof(kind), kind),
    };

    ///  <summary>
    /// Inline text, consider passing the text as a string for auto-conversion to a <see cref="Text(string)"/> node
    /// </summary>
    public static Text Text(string content) => new(content);

    /// <inheritdoc cref="Tags.Ul"/>
    public static He Ul(params object[] content) => new(Tags.Ul) { content };

    /// <inheritdoc cref="Tags.Var"/>
    public static He Var(params object[] content) => new(Tags.Var) { content };

    /// <inheritdoc cref="Tags.Video"/>
    public static He Video(params object[] content) => new(Tags.Video) { ("controls", null), content };

    /// <inheritdoc cref="Tags.Wbr"/>
    public static He Wbr() => new(Tags.Wbr);
}