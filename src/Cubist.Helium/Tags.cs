namespace Cubist.Helium;

public static class Tags
{
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

    ///<summary>tangential content </summary>
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
    /// ⓘ button type=submit – submit button
    /// ⓘ button type=reset – reset button
    /// ⓘ button type=button – button with no additional semantics
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

    ///<summary>command </summary>
    /// <remarks>
    /// ⓘ command type=command – command with an associated action 
    /// ⓘ command type=radio – selection of one item from a list of items 
    /// ⓘ command type=checkbox – state or option that can be toggled 
    /// </remarks>
    public static Tag Command { get; } = "command";

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

    ///<summary>heading group </summary>
    public static Tag Hgroup { get; } = "hgroup";

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
    /// ⓘ input type=text – text-input field
    /// ⓘ input type=password – password-input field
    /// ⓘ input type=checkbox – checkbox
    /// ⓘ input type=radio – radio button
    /// ⓘ input type=button – button
    /// ⓘ input type=submit – submit button
    /// ⓘ input type=reset – reset button
    /// ⓘ input type=file – file upload control
    /// ⓘ input type=hidden – hidden input control
    /// ⓘ input type=image – image-coordinates input control
    /// ⓘ input type=datetime – global date-and-time input control 
    /// ⓘ input type=datetime-local – local date-and-time input control 
    /// ⓘ input type=date – date input control 
    /// ⓘ input type=month – year-and-month input control 
    /// ⓘ input type=time – time input control 
    /// ⓘ input type=week – year-and-week input control 
    /// ⓘ input type=number – number input control 
    /// ⓘ input type=range – imprecise number-input control 
    /// ⓘ input type=email – e-mail address input control 
    /// ⓘ input type=url – URL input control 
    /// ⓘ input type=search – search field 
    /// ⓘ input type=tel – telephone-number-input field 
    /// ⓘ input type=color – color-well control 
    /// </remarks>
    public static Tag Input { get; } = "input";

    ///<summary>inserted text</summary>
    public static Tag Ins { get; } = "ins";

    ///<summary>user input</summary>
    public static Tag Kbd { get; } = "kbd";

    ///<summary>key-pair generator/input control </summary>
    public static Tag Keygen { get; } = "keygen";

    ///<summary>caption for a form control</summary>
    public static Tag Label { get; } = "label";

    ///<summary>title or explanatory caption</summary>
    public static Tag Legend { get; } = "legend";

    ///<summary>list item</summary>
    public static Tag Li { get; } = "li";

    ///<summary>inter-document relationship metadata</summary>
    public static Tag Link { get; } = "link";

    ///<summary>image-map definition</summary>
    public static Tag Map { get; } = "map";

    ///<summary>marked (highlighted) text </summary>
    public static Tag Mark { get; } = "mark";

    ///<summary>list of commands </summary>
    public static Tag Menu { get; } = "menu";

    ///<summary>metadata </summary>
    /// <remarks>
    /// ⓘ meta name – name-value metadata
    /// ⓘ meta http-equiv=refresh – “refresh” pragma directive
    /// ⓘ meta http-equiv=default-style – “preferred stylesheet” pragma directive
    /// ⓘ meta charset – document character-encoding declaration 
    /// ⓘ meta http-equiv=content-type – document character-encoding declaration
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

    ///<summary>table</summary>
    public static Tag Table { get; } = "table";

    ///<summary>table row group</summary>
    public static Tag Tbody { get; } = "tbody";

    ///<summary>table cell</summary>
    public static Tag Td { get; } = "td";

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

    ///<summary>line-break opportunity </summary>
    public static Tag Wbr { get; } = "wbr";
}