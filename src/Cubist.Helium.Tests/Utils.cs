using System.Net;
using System.Web;
using Xunit.Abstractions;
using static Cubist.Helium.He;

namespace Cubist.Helium.Tests;

public class Utils
{
    private readonly ITestOutputHelper _output;

    public Utils(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void PrintSortedDistinct()
    {
        var set = new HashSet<string>
        {
            "annotation-xml",
            "color-profile",
            "font-face",
            "font-face-src",
            "font-face-uri",
            "font-face-format",
            "font-face-name",
            "missing-glyph",
        };
        _output.WriteLine("\"" + string.Join("\", \"", set.OrderBy(x => x)) + "\"");
    }

    [Fact]
    public void CanEncodeAttrsAndHtml()
    {
        var html = Div(
            ("data-value", "<'&>".AttrEncoded()),
            "A custom element like this: <todo-list>".HtmlEncoded()).ToString();
        Assert.Equal("<div data-value=\"&lt;&#39;&amp;>\">A custom element like this: &lt;todo-list&gt;</div>",html);
    }
}

public static class EncodingExtensions
{
    public static HtmlEncoder HtmlEncoded(this string text) => new(text);

    public static HtmlAttributeEncoder AttrEncoded(this string text) => new(text);
}

public sealed class HtmlEncoder : Node
{
    public string Value { get; }
    public HtmlEncoder(string value) => Value = value;
    public override void WriteTo(TextWriter w) => WebUtility.HtmlEncode(Value, w);
}

public sealed class HtmlAttributeEncoder : Node
{
    public string Value { get; }
    public HtmlAttributeEncoder(string value) => Value = value;
    public override void WriteTo(TextWriter w) => HttpUtility.HtmlAttributeEncode(Value, w);
}
