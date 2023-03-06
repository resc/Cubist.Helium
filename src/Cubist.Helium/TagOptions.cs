namespace Cubist.Helium;

/// <summary> Information about the category and usage of a <see cref="Tag"/> </summary>
[Flags]
public enum TagOptions
{
    /// <summary> No options </summary>
    None = 0,

    /// <summary> This tag is a Html5 standard tag, (as the standard is quite fluid, some obsolete tags have this option as well.) </summary>
    Html5 = 1 << 0,

    /// <summary> This tag is a <a href="https://www.w3.org/TR/2011/WD-html-markup-20110113/syntax.html#void-element">void element</a> without content, like <c>input</c> or <c>meta</c>.</summary>
    Void = 1 << 1,

    /// <summary>
    ///  This tag is a metadata element like <c>meta</c>, <c>title</c> or <c>link</c>. See <a href="https://www.w3.org/TR/2012/WD-html-markup-20121025/common-models.html#common.elem.metadata">here</a> for more info
    /// </summary>
    Metadata = 1 << 2,

    /// <summary>
    ///  This tag is a flow element. See <a href="https://www.w3.org/TR/2012/WD-html-markup-20121025/common-models.html#common.elem.flow">here</a> for more info
    /// </summary>
    Flow = 1 << 3,

    /// <summary>
    ///  This tag is a phrasing element. See <a href="https://www.w3.org/TR/2012/WD-html-markup-20121025/common-models.html#common.elem.phrasing">here</a> for more info
    /// </summary>
    Phrasing = 1 << 4,

    /// <summary> This tag is embedded content, e.g.  <c>img</c>, <c>audio</c>, <c>video</c>. </summary>
    EmbeddedContent = 1 << 5,

    /// <summary> This tag marks texts with <a href="https://html.spec.whatwg.org/multipage/text-level-semantics.html#usage-summary" >text-level semantics</a> e.g. <c>span</c>, <c>i</c>, <c>b</c> etc... </summary>
    Inline = 1 << 6,

    /// <summary> This tags is (probably) a custom tag a.k.a. a web component.
    /// See <a href="https://html.spec.whatwg.org/#valid-custom-element-name">here</a> for more info  </summary>
    Custom = 1 << 7,

    /// <summary> This tag is not defined in the html5 standard and does not conform to
    /// <a href="https://html.spec.whatwg.org/#valid-custom-element-name">the custom tag naming rules</a>
    /// This tag could be <a href="https://www.w3.org/TR/2012/WD-html-markup-20121025/syntax.html#svg-mathml">Svg or MathML</a> or a typo. </summary>
    Foreign = 1 << 8,

    /// <summary> This tag indicates a section, e.g. <c>article</c> or <c>section</c></summary>
    Section = 1 << 9,

    /// <summary> This tag is one of the <c>h1</c> - <c>h6</c> tags </summary>
    Heading = 1 << 10,

    /// <summary> This tag is <c>script</c>, <c>template</c> or <c>slot</c></summary>
    Script = 1 << 11,

    /// <summary> This tag is a grouping tag like <c>ul</c>, <c>li</c> or <c>div</c></summary>
    Grouping = 1 << 12,

    /// <summary> This tag is used to construct tables e.g. <c>table</c>, <c>tr</c> or <c>td</c></summary>
    Table = 1 << 13,

    /// <summary> This tag is used to construct forms e.g. <c>form</c>, <c>input</c>, <c>label</c> or <c>fieldset</c></summary>
    Form = 1 << 14,

    /// <summary> This tag is used to construct user interactivity e.g. <c>button</c>, <c>a</c>, <c>input</c> or <c>dialog</c></summary>
    Interactive = 1 << 15,

    /// <summary> This tag shouldn't be used for new html content </summary>
    Deprecated = 1 << 31,
}