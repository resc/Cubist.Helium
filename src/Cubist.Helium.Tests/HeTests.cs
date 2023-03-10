using System.Text.Json.Nodes;
using Xunit.Abstractions;
using static Cubist.Helium.He;

namespace Cubist.Helium.Tests;

public class HeTests
{
    private readonly ITestOutputHelper _output;

    public HeTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void CanConstructMetaElement()
    {
        var meta = Meta("keywords", "test, library");

        var html = meta.ToString();
        _output.WriteLine(html);
        Assert.Equal("<meta name=\"keywords\" content=\"test, library\">", html);

    }

    [Fact]
    public void CanRenderJsonNode()
    {
        var meta = Json(new JsonObject
        {
            { "text", "some text" },
            { "bool", true },
        });

        var html = meta.ToString();
        _output.WriteLine(html);
        Assert.Equal("{\"text\":\"some text\",\"bool\":true}", html);
    }
    [Fact]
    public void CanRenderImportMap()
    {
        var meta = Script(("type", @"importmap"), new JsonObject
        {
            {
                "import", new JsonObject
                {
                    { "name", "./path/to/module" }
                }
            },
        });

        var html = meta.ToString();
        _output.WriteLine(html);
        Assert.Equal(@"<script type=""importmap"">{""import"":{""name"":""./path/to/module""}}</script>", html);
    }




    [Fact]
    public void CanRenderConditionalFalse()
    {
        var hasClass = false;
        var div = Div(If(hasClass, Class("class")));

        var html = div.ToString();
        _output.WriteLine(html);
        Assert.Equal("<div></div>", html);

    }

    [Fact]
    public void CanRenderConditionalTrue()
    {
        var hasClass = true;
        var div = Div(If(hasClass, Class("class")));

        var html = div.ToString();
        _output.WriteLine(html);
        Assert.Equal("<div class=\"class\"></div>", html);
    }

    [Fact]
    public void CanRenderConditionalTrueFunctionContent()
    {
        var hasClass = true;
        var div = Div(If(hasClass, () => Class("class")));

        var html = div.ToString();
        _output.WriteLine(html);
        Assert.Equal("<div class=\"class\"></div>", html);
    }
}