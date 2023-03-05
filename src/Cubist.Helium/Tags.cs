namespace Cubist.Helium;

public static class Tags
{
    ///<summary> document type declaration </summary>
    public static Tag DocType { get; } = new(@"!DOCTYPE", TagOptions.Html5 | TagOptions.Void);

    ///<summary>hyperlink </summary>
    public static Tag A { get; } = "a";

    ///<summary>abbreviation</summary>
    public static Tag Abbr { get; } = "abbr";

    ///<summary>contact information</summary>
    public static Tag Address { get; } = "address";

    ///<summary>image-map hyperlink</summary>
    public static Tag Area { get; } = "area";

    ///<summary>article </summary>
    public static Tag Article { get; } = "article";

    ///<summary> aside tangential content </summary>
    public static Tag Aside { get; } = "aside";

    ///<summary>audio stream </summary>
    public static Tag Audio { get; } = "audio";

    ///<summary>offset text conventionally styled in bold </summary>
    public static Tag B { get; } = "b";

    ///<summary>base URL</summary>
    public static Tag Base { get; } = "base";

    ///<summary>BiDi isolate </summary>
    public static Tag Bdi { get; } = "bdi";

    ///<summary>BiDi override</summary>
    public static Tag Bdo { get; } = "bdo";

    ///<summary>block quotation</summary>
    public static Tag BlockQuote { get; } = @"blockquote";

    ///<summary>document body</summary>
    public static Tag Body { get; } = "body";

    ///<summary>line break</summary>
    public static Tag Br { get; } = "br";

    ///<summary>button</summary>
    /// <remarks>
    /// <list>
    /// <item><term> button type=submit </term><description> submit button</description></item>
    /// <item><term> button type=reset </term><description> reset button</description></item>
    /// <item><term> button type=button </term><description> button with no additional semantics</description></item>
    /// </list>
    /// </remarks>
    public static Tag Button { get; } = "button";

    ///<summary>canvas for dynamic graphics </summary>
    public static Tag Canvas { get; } = "canvas";

    ///<summary>table title</summary>
    public static Tag Caption { get; } = "caption";

    ///<summary>cited title of a work </summary>
    public static Tag Cite { get; } = "cite";

    ///<summary>code fragment</summary>
    public static Tag Code { get; } = "code";

    ///<summary>table column</summary>
    public static Tag Col { get; } = "col";

    ///<summary>table column group</summary>
    public static Tag Colgroup { get; } = "colgroup";

    ///<summary> used to add a machine-readable translation of a given content </summary>
    public static Tag Data { get; } = "data";

    ///<summary>predefined options for other controls </summary>
    public static Tag Datalist { get; } = "datalist";

    ///<summary>description or value</summary>
    public static Tag Dd { get; } = "dd";

    ///<summary>deleted text</summary>
    public static Tag Del { get; } = "del";

    ///<summary>control for additional on-demand information </summary>
    public static Tag Details { get; } = "details";

    ///<summary>defining instance</summary>
    public static Tag Dfn { get; } = "dfn";

    ///<summary>defines a dialog box or sub-window</summary>
    public static Tag Dialog { get; } = "dialog";

    ///<summary>generic flow container</summary>
    public static Tag Div { get; } = "div";

    ///<summary>description list</summary>
    public static Tag Dl { get; } = "dl";

    ///<summary>term or name</summary>
    public static Tag Dt { get; } = "dt";

    ///<summary>emphatic stress</summary>
    public static Tag Em { get; } = "em";

    ///<summary>integration point for plugins </summary>
    public static Tag Embed { get; } = "embed";

    ///<summary>set of related form controls</summary>
    public static Tag Fieldset { get; } = "fieldset";

    ///<summary>figure caption </summary>
    public static Tag Figcaption { get; } = "figcaption";

    ///<summary>figure with optional caption </summary>
    public static Tag Figure { get; } = "figure";

    ///<summary>footer </summary>
    public static Tag Footer { get; } = "footer";

    ///<summary>user-submittable form</summary>
    public static Tag Form { get; } = "form";

    ///<summary>heading</summary>
    public static Tag H1 { get; } = "h1";

    ///<summary>heading</summary>
    public static Tag H2 { get; } = "h2";

    ///<summary>heading</summary>
    public static Tag H3 { get; } = "h3";

    ///<summary>heading</summary>
    public static Tag H4 { get; } = "h4";

    ///<summary>heading</summary>
    public static Tag H5 { get; } = "h5";

    ///<summary>heading</summary>
    public static Tag H6 { get; } = "h6";

    ///<summary>document metadata container</summary>
    public static Tag Head { get; } = "head";

    ///<summary>header </summary>
    public static Tag Header { get; } = "header";

    ///<summary>thematic break </summary>
    public static Tag Hr { get; } = "hr";

    ///<summary>root element</summary>
    public static Tag Html { get; } = "html";

    ///<summary>offset text conventionally styled in italic </summary>
    public static Tag I { get; } = "i";

    ///<summary>nested browsing context (inline frame)</summary>
    public static Tag Iframe { get; } = "iframe";

    ///<summary>image</summary>
    public static Tag Img { get; } = "img";

    ///<summary>input control </summary>
    /// <remarks>
    /// <list>
    ///   <item><term>input type=text</term><description>text-input field</description></item>
    ///   <item><term>input type=password</term><description>password-input field</description></item>
    ///   <item><term>input type=checkbox</term><description>checkbox</description></item>
    ///   <item><term>input type=radio</term><description>radio button</description></item>
    ///   <item><term>input type=button</term><description>button</description></item>
    ///   <item><term>input type=submit</term><description>submit button</description></item>
    ///   <item><term>input type=reset</term><description>reset button</description></item>
    ///   <item><term>input type=file</term><description>file upload control</description></item>
    ///   <item><term>input type=hidden</term><description>hidden input control</description></item>
    ///   <item><term>input type=image</term><description>image-coordinates input control</description></item>
    ///   <item><term>input type=datetime</term><description>global date-and-time input control </description></item>
    ///   <item><term>input type=datetime-local</term><description>local date-and-time input control </description></item>
    ///   <item><term>input type=date</term><description>date input control </description></item>
    ///   <item><term>input type=month</term><description>year-and-month input control </description></item>
    ///   <item><term>input type=time</term><description>time input control </description></item>
    ///   <item><term>input type=week</term><description>year-and-week input control </description></item>
    ///   <item><term>input type=number</term><description>number input control </description></item>
    ///   <item><term>input type=range</term><description>imprecise number-input control </description></item>
    ///   <item><term>input type=email</term><description>e-mail address input control </description></item>
    ///   <item><term>input type=url</term><description>URL input control </description></item>
    ///   <item><term>input type=search</term><description>search field </description></item>
    ///   <item><term>input type=tel</term><description>telephone-number-input field </description></item>
    ///   <item><term>input type=color</term><description>color-well control </description></item>
    /// </list>
    /// </remarks>
    public static Tag Input { get; } = "input";

    ///<summary>inserted text</summary>
    public static Tag Ins { get; } = "ins";

    ///<summary>user input</summary>
    public static Tag Kbd { get; } = "kbd";

    ///<summary>caption for a form control</summary>
    public static Tag Label { get; } = "label";

    ///<summary>title or explanatory caption</summary>
    public static Tag Legend { get; } = "legend";

    ///<summary>list item</summary>
    public static Tag Li { get; } = "li";

    ///<summary>inter-document relationship metadata</summary>
    public static Tag Link { get; } = "link";

    ///<summary> specifies the main content of a document </summary>
    public static Tag Main { get; } = "main";

    ///<summary>image-map definition</summary>
    public static Tag Map { get; } = "map";

    ///<summary>marked (highlighted) text </summary>
    public static Tag Mark { get; } = "mark";

    ///<summary>document level metadata </summary>
    /// <remarks>
    /// <list>
    ///   <item><term>meta name={name} content={content}</term><description>name-value metadata</description></item>
    ///   <item><term>meta http-equiv=refresh content={content}</term><description>“refresh” pragma directive</description></item>
    ///   <item><term>meta http-equiv=default-style content={content}</term><description>“preferred stylesheet” pragma directive</description></item>
    ///   <item><term>meta http-equiv=content-type content={content}</term><description>document character-encoding declaration </description></item>
    ///   <item><term>meta charset=utf-8</term><description>document character-encoding declaration </description></item>
    /// </list>
    /// </remarks>
    public static Tag Meta { get; } = "meta";

    ///<summary>scalar gauge </summary>
    public static Tag Meter { get; } = "meter";

    ///<summary>group of navigational links </summary>
    public static Tag Nav { get; } = "nav";

    ///<summary>fallback content for script</summary>
    public static Tag NoScript { get; } = @"noscript";

    ///<summary>generic external content</summary>
    public static Tag Object { get; } = "object";

    ///<summary>ordered list</summary>
    public static Tag Ol { get; } = "ol";

    ///<summary>group of options</summary>
    public static Tag Optgroup { get; } = "optgroup";

    ///<summary>option</summary>
    public static Tag Option { get; } = "option";

    ///<summary>result of a calculation in a form </summary>
    public static Tag Output { get; } = "output";

    ///<summary>paragraph</summary>
    public static Tag P { get; } = "p";

    ///<summary>initialization parameters for plugins</summary>
    public static Tag Param { get; } = "param";

    ///<summary> gives flexibility in specifying image resources</summary>
    public static Tag Picture { get; } = "picture";

    ///<summary>pre-formatted text</summary>
    public static Tag Pre { get; } = "pre";

    ///<summary>progress indicator </summary>
    public static Tag Progress { get; } = "progress";

    ///<summary>quoted text</summary>
    public static Tag Q { get; } = "q";

    ///<summary>ruby parenthesis </summary>
    public static Tag Rp { get; } = "rp";

    ///<summary>ruby text </summary>
    public static Tag Rt { get; } = "rt";

    ///<summary>ruby annotation </summary>
    public static Tag Ruby { get; } = "ruby";

    ///<summary>struck text </summary>
    public static Tag S { get; } = "s";

    // ReSharper disable once IdentifierTypo
    ///<summary>(sample) output</summary>
    public static Tag Samp { get; } = @"samp";

    ///<summary>embedded script</summary>
    public static Tag Script { get; } = "script";

    ///<summary>section </summary>
    public static Tag Section { get; } = "section";

    ///<summary>option-selection form control</summary>
    public static Tag Select { get; } = "select";

    ///<summary> template hole </summary>
    public static Tag Slot { get; } = "slot";

    ///<summary>small print </summary>
    public static Tag Small { get; } = "small";

    ///<summary>media source </summary>
    public static Tag Source { get; } = "source";

    ///<summary>generic span</summary>
    public static Tag Span { get; } = "span";

    ///<summary>strong importance</summary>
    public static Tag Strong { get; } = "strong";

    ///<summary>style (presentation) information</summary>
    public static Tag Style { get; } = "style";

    ///<summary>subscript</summary>
    public static Tag Sub { get; } = "sub";

    ///<summary>summary, caption, or legend for a details control </summary>
    public static Tag Summary { get; } = "summary";

    ///<summary>superscript</summary>
    public static Tag Sup { get; } = "sup";

    ///<summary>Svg content</summary>
    public static Tag Svg { get; } = "svg";

    ///<summary>table</summary>
    public static Tag Table { get; } = "table";

    ///<summary>table row group</summary>
    public static Tag Tbody { get; } = "tbody";

    ///<summary>table cell</summary>
    public static Tag Td { get; } = "td";

    ///<summary>template</summary>
    public static Tag Template { get; } = "template";

    ///<summary>text input area</summary>
    public static Tag Textarea { get; } = "textarea";

    // ReSharper disable once IdentifierTypo
    ///<summary>table footer row group</summary> 
    public static Tag Tfoot { get; } = @"tfoot";

    ///<summary>table header cell</summary>
    public static Tag Th { get; } = "th";

    ///<summary>table heading group</summary>
    public static Tag Thead { get; } = "thead";

    ///<summary>date and/or time </summary>
    public static Tag Time { get; } = "time";

    ///<summary>document title</summary>
    public static Tag Title { get; } = "title";

    ///<summary>table row</summary>
    public static Tag Tr { get; } = "tr";

    ///<summary>supplementary media track </summary>
    public static Tag Track { get; } = "track";

    ///<summary>offset text conventionally styled with an underline </summary>
    public static Tag U { get; } = "u";

    ///<summary>unordered list</summary>
    public static Tag Ul { get; } = "ul";

    ///<summary>variable or placeholder text</summary>
    public static Tag Var { get; } = "var";

    ///<summary>video </summary>
    public static Tag Video { get; } = "video";

    ///<summary>word-break opportunity </summary>
    public static Tag Wbr { get; } = "wbr";
}