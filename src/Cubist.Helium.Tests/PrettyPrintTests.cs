using System.Text.Json.Nodes;
using Xunit.Abstractions;
using static Cubist.Helium.He;

namespace Cubist.Helium.Tests;

public class PrettyPrintTests
{
    private readonly ITestOutputHelper _output;

    public PrettyPrintTests(ITestOutputHelper output)
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
  <li><a href=""http://www.example.com"">Link to example.com</a></li>
  <li><a href=""http://www.example.com"">Link to example.com</a></li>
  <li><a href=""http://www.example.com"">Link to example.com</a></li>
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
  <li><a href=""http://www.example.com"">Link to example.com</a></li>
  <!--
    This is
    a multiline
    comment
  -->
  <li><a href=""http://www.example.com"">Link to example.com</a></li>
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
  <li><a href=""http://www.example.com"">Link to example.com</a></li>
  <!-- This is a single line comment -->
  <li><a href=""http://www.example.com"">Link to example.com</a></li>
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
    public void PrettyPrintDivWithDataElement()
    {
        var doc = Div("A number: ", Data(1, 1.ToString()));
        var html = doc.PrettyPrint();
        var expected = @"<div>A number: <data value=""1"">1</data></div>
";
        _output.WriteLine(html);
        Assert.Equal(expected, html);
    }

    [Fact]
    public void PrettyPrintDivWithTimeElement()
    {
        var dt = new DateTime(2000, 1, 1, 23, 59, 59);
        var doc = Div("A date-time: ", Time(dt, dt.ToString("s")));
        var html = doc.PrettyPrint();
        var expected = @"<div>A date-time: <time datetime=""2000-01-01 23:59:59Z"">2000-01-01T23:59:59</time></div>
";
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
    <li><a href=""http://www.example.com"">Link to example.com</a></li>
    <li><a href=""http://www.example.com"">Link to example.com</a></li>
    <li><a href=""http://www.example.com"">Link to example.com</a></li>
  </ul>
</body>
</html>";
        Assert.Equal(expected, html);
    }

    [Fact]
    public void PrettyPrintImportMap()
    {
        var script = Script(("type", @"importmap"), new JsonObject
        {
            {
                "import", new JsonObject
                {
                    { "name", "./path/to/module" }
                }
            },
        });
        
        var html = script.PrettyPrint();
        _output.WriteLine(html);
        var expected = @"<script type=""importmap"">
  {
    ""import"": {
      ""name"": ""./path/to/module""
    }
  }
</script>
";
        Assert.Equal(expected, html);
    }

    [Fact]
    public void PrettyPrintImportMapFromDictionary()
    {
        var script = Script(("type", @"importmap"), Json(
            new Dictionary<string, object>
            {
                {
                    "import", new Dictionary<string, string>
                    {
                        { "name", "./path/to/module" }
                    }
                }
            }));
        
        var html = script.PrettyPrint();
        _output.WriteLine(html);
        var expected = @"<script type=""importmap"">
  {
    ""import"": {
      ""name"": ""./path/to/module""
    }
  }
</script>
";
        Assert.Equal(expected, html);
    }
}