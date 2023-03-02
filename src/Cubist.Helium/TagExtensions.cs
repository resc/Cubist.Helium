namespace Cubist.Helium;

public static class TagExtensions
{
    /// <inheritdoc cref="TagOptions.Flow"/>
    public static bool IsFlow(this Tag tag) => (tag.Options & TagOptions.Flow) == TagOptions.Flow;
  
    /// <inheritdoc cref="TagOptions.Void"/>
    public static bool IsVoid(this Tag tag) => (tag.Options & TagOptions.Void) == TagOptions.Void;
   
    /// <inheritdoc cref="TagOptions.Html5"/>
    public static bool IsHtml5(this Tag tag) => (tag.Options & TagOptions.Html5) == TagOptions.Html5;
   
    /// <inheritdoc cref="TagOptions.Inline"/>
    public static bool IsInline(this Tag tag) => (tag.Options & TagOptions.Inline) == TagOptions.Inline;
   
    /// <inheritdoc cref="TagOptions.Custom"/>
    public static bool IsCustom(this Tag tag) => (tag.Options & TagOptions.Custom) == TagOptions.Custom;
   
    /// <inheritdoc cref="TagOptions.Foreign"/>
    public static bool IsForeign(this Tag tag) => (tag.Options & TagOptions.Foreign) == TagOptions.Foreign;
   
    /// <inheritdoc cref="TagOptions.Phrasing"/>
    public static bool IsPhrasing(this Tag tag) => (tag.Options & TagOptions.Phrasing) == TagOptions.Phrasing;
    
    /// <inheritdoc cref="TagOptions.Metadata"/>
    public static bool IsMetadata(this Tag tag) => (tag.Options & TagOptions.Metadata) == TagOptions.Metadata;
   
    /// <inheritdoc cref="TagOptions.EmbeddedContent"/>
    public static bool IsEmbeddedContent(this Tag tag) => (tag.Options & TagOptions.EmbeddedContent) == TagOptions.EmbeddedContent;
   
    /// <inheritdoc cref="TagOptions.Section"/>
    public static bool IsSection(this Tag tag) => (tag.Options & TagOptions.Section) == TagOptions.Section;
 
    /// <inheritdoc cref="TagOptions.Heading"/>
    public static bool IsHeading(this Tag tag) => (tag.Options & TagOptions.Heading) == TagOptions.Heading;
  
    /// <inheritdoc cref="TagOptions.Script"/>
    public static bool IsScript(this Tag tag) => (tag.Options & TagOptions.Script) == TagOptions.Script;
  
    /// <inheritdoc cref="TagOptions.Grouping"/>
    public static bool IsGrouping(this Tag tag) => (tag.Options & TagOptions.Grouping) == TagOptions.Grouping;
   
    /// <inheritdoc cref="TagOptions.Table"/>
    public static bool IsTable(this Tag tag) => (tag.Options & TagOptions.Table) == TagOptions.Table;
  
    /// <inheritdoc cref="TagOptions.Form"/>
    public static bool IsForm(this Tag tag) => (tag.Options & TagOptions.Form) == TagOptions.Form;
   
    /// <inheritdoc cref="TagOptions.Interactive"/>
    public static bool IsInteractive(this Tag tag) => (tag.Options & TagOptions.Interactive) == TagOptions.Interactive;
   
    /// <inheritdoc cref="TagOptions.Deprecated"/>
    public static bool IsDeprecated(this Tag tag) => (tag.Options & TagOptions.Deprecated) == TagOptions.Deprecated;
}