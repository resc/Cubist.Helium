using Xunit.Abstractions;

namespace Cubist.Helium.Tests;

public class HeTests
{
    private readonly ITestOutputHelper _output;

    public HeTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void PrettyPrintList()
    {
        var list = new He("ul")
        {
            new He("li") { new He("a", ("href", "http://www.example.com")) { "Link to example.com" } },
            new He("li") { new He("a", ("href", "http://www.example.com")) { "Link to example.com" } },
            new He("li") { new He("a", ("href", "http://www.example.com")) { "Link to example.com" } },
        };

        var html = list.PrettyPrint();
        _output.WriteLine(html);
        Assert.Equal(@"<ul>
  <li>
    <a href=""http://www.example.com"">Link to example.com</a>
  </li>
  <li>
    <a href=""http://www.example.com"">Link to example.com</a>
  </li>
  <li>
    <a href=""http://www.example.com"">Link to example.com</a>
  </li>
</ul>
", html);
    }
    [Fact]
    public void PrettyPrintLinkWithSpan()
    {
        var list = new He("a", ("href", "http://www.example.com")) { "Link to ", new He("span") { "example.com" } };

        var html = list.PrettyPrint();
        _output.WriteLine(html);
        Assert.Equal(@"<a href=""http://www.example.com"">Link to <span>example.com</span></a>", html);
    }

    [Fact]
    public void PrettyPrintListWithMultiLineComment()
    {
        var list = new He("ul")
        {
            new He("li") { new He("a", ("href", "http://www.example.com")) { "Link to example.com" } },
            new Comment("This is\na multiline\ncomment"),
            new He("li") { new He("a", ("href", "http://www.example.com")) { "Link to example.com" } },
        };

        var html = list.PrettyPrint();
        _output.WriteLine(html);
        Assert.Equal(@"<ul>
  <li>
    <a href=""http://www.example.com"">Link to example.com</a>
  </li>
  <!--
    This is
    a multiline
    comment
  -->
  <li>
    <a href=""http://www.example.com"">Link to example.com</a>
  </li>
</ul>
", html);
    }

    [Fact]
    public void PrettyPrintListWithSingleLineComment()
    {
        var list = new He("ul")
        {
            new He("li") { new He("a", ("href", "http://www.example.com")) { "Link to example.com" } },
            new Comment("This is a single line comment"),
            new He("li") { new He("a", ("href", "http://www.example.com")) { "Link to example.com" } },
        };

        var html = list.PrettyPrint();
        _output.WriteLine(html);
        Assert.Equal(@"<ul>
  <li>
    <a href=""http://www.example.com"">Link to example.com</a>
  </li>
  <!-- This is a single line comment -->
  <li>
    <a href=""http://www.example.com"">Link to example.com</a>
  </li>
</ul>
", html);
    }

    [Fact]
    public void PrettyPrintEmptyDocument()
    {
        var doc = new HtmlDocument();
        var html = doc.PrettyPrint();
        var expected = @"<!DOCTYPE html>
<html>
<head>
</head>
<body>
</body>
</html>";

        _output.WriteLine(html);
        Assert.Equal(expected, html);
    }

    [Fact]
    public void PrettyPrintDocumentWithList()
    {
        var doc = new HtmlDocument();
        doc.Body.Add(new He("ul")
        {
            new He("li") { new He("a", ("href", "http://www.example.com")) { "Link to example.com" } },
            new He("li") { new He("a", ("href", "http://www.example.com")) { "Link to example.com" } },
            new He("li") { new He("a", ("href", "http://www.example.com")) { "Link to example.com" } },
        });

        var html = doc.PrettyPrint();
        _output.WriteLine(html);
        var expected = @"<!DOCTYPE html>
<html>
<head>
</head>
<body>
  <ul>
    <li>
      <a href=""http://www.example.com"">Link to example.com</a>
    </li>
    <li>
      <a href=""http://www.example.com"">Link to example.com</a>
    </li>
    <li>
      <a href=""http://www.example.com"">Link to example.com</a>
    </li>
  </ul>
</body>
</html>";
        Assert.Equal(expected, html);
    }
}