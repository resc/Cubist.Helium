namespace Cubist.Helium.Tests;

public class AttributeTests
{
    [Fact]
    public void BooleanAttribute()
    {
        var input = new He("input").Attr("checked");
        var html = input.ToString();
        Assert.Equal(@"<input checked>", html);
    }

    [Fact]
    public void BooleanAttributeInCtor()
    {
        var input = new He("input") { ("checked", null) };
        var html = input.ToString();
        Assert.Equal(@"<input checked>", html);
    }

    [Fact]
    public void UnquotedAttribute()
    {
        var input = new He("input") { ("type", "checkbox".NoQuotes()) };
        var html = input.ToString();
        Assert.Equal(@"<input type=checkbox>", html);
    }

    [Fact]
    public void SingleQuotedAttribute()
    {
        var input = new He("input", ("type", "checkbox".SingleQuoted()));
        var html = input.ToString();
        Assert.Equal(@"<input type='checkbox'>", html);
    }

    [Fact]
    public void DoubleQuotedAttribute()
    {
        var input = new He("input", ("type", "checkbox"));
        var html = input.ToString();
        Assert.Equal(@"<input type=""checkbox"">", html);
    }
}