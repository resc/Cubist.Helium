namespace Cubist.Helium;

[Flags]
public enum TagOptions
{
    /// <summary> No options </summary>
    None = 0,

    /// <summary> This tag is a Html5 standard tag </summary>
    Html5 = 1 << 0,

    /// <summary> This tag is a <a href="https://www.w3.org/TR/2011/WD-html-markup-20110113/syntax.html#void-element">void element</a> without content.</summary>
    Void = 1 << 1,

    /// <summary>
    ///  See <a href="https://www.w3.org/TR/2012/WD-html-markup-20121025/common-models.html#common.elem.metadata">here</a> for more info
    /// </summary>
    Metadata = 1 << 2,

    /// <summary>
    ///  See <a href="https://www.w3.org/TR/2012/WD-html-markup-20121025/common-models.html#common.elem.flow">here</a> for more info
    /// </summary>
    Flow = 1 << 3,

    /// <summary>
    ///  See <a href="https://www.w3.org/TR/2012/WD-html-markup-20121025/common-models.html#common.elem.phrasing">here</a> for more info
    /// </summary>
    Phrasing = 1 << 4,

    /// <summary> Tags that embed other content in html, like audio, video or frames. </summary>
    EmbeddedContent = 1 << 5,

    /// <summary> Tags that supply <a href="https://html.spec.whatwg.org/multipage/text-level-semantics.html#usage-summary" >text-level semantics</a>. </summary>
    Inline = 1 << 5,

    /// <summary> Tags that have a - in the tag name are a web component.
    /// See <a href="https://html.spec.whatwg.org/#valid-custom-element-name">here</a> for more info  </summary>
    Custom = 1 << 6,

    /// <summary> Tags that are not defined in the html5 standard and are not conforming to
    /// <a href="https://html.spec.whatwg.org/#valid-custom-element-name">the custom tag naming rules</a>
    /// are marked with this option. This tag could be
    /// <a href="https://www.w3.org/TR/2012/WD-html-markup-20121025/syntax.html#svg-mathml">Svg or MathML</a> or a typo. </summary>
    Foreign = 1 << 7,

    Section = 1 << 8,

    Heading = 1 << 9,
    
    Script = 1 << 10,
    
    Grouping = 1 << 11,
    
    Table = 1 << 12,
    
    Form = 1 << 13,

    Interactive = 1 << 14,

    /// <summary> This tag shouldn't be used for new html content </summary>
    Deprecated = 1 << 31,
}