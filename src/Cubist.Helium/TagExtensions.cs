namespace Cubist.Helium;

public static class TagExtensions
{
    public static bool IsFlow(this Tag tag) => (tag.Options & TagOptions.Flow) == TagOptions.Flow;
    public static bool IsVoid(this Tag tag) => (tag.Options & TagOptions.Void) == TagOptions.Void;
    public static bool IsHtml5(this Tag tag) => (tag.Options & TagOptions.Html5) == TagOptions.Html5;
    public static bool IsInline(this Tag tag) => (tag.Options & TagOptions.Inline) == TagOptions.Inline;
    public static bool IsCustom(this Tag tag) => (tag.Options & TagOptions.Custom) == TagOptions.Custom;
    public static bool IsForeign(this Tag tag) => (tag.Options & TagOptions.Foreign) == TagOptions.Foreign;
    public static bool IsPhrasing(this Tag tag) => (tag.Options & TagOptions.Phrasing) == TagOptions.Phrasing;
    public static bool IsMetadata(this Tag tag) => (tag.Options & TagOptions.Metadata) == TagOptions.Metadata;
    public static bool IsEmbeddedContent(this Tag tag) => (tag.Options & TagOptions.EmbeddedContent) == TagOptions.EmbeddedContent;
}