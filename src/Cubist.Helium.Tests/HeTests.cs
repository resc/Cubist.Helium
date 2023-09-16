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
    public void CanConstructList()
    {
        var list = List(P("one"), P("two"), P("three"));
        var html = list.ToString();
        _output.WriteLine(html);
        Assert.Equal("<p>one</p><p>two</p><p>three</p>", html);
    }

    [Fact]
    public void CanConstructListPrettyPrinted()
    {
        var list = List(P("one"), P("two"), P("three"));
        var html = list.PrettyPrint();
        _output.WriteLine(html);
        Assert.Equal("""
        <p>one</p>
        <p>two</p>
        <p>three</p>

        """, html);
    }
    [Fact]
    public void CanConstructListInDivPrettyPrinted()
    {
        var list = Div(List(P("one"), P("two"), P("three")));
        var html = list.PrettyPrint();
        _output.WriteLine(html);
        Assert.Equal("""
        <div>
          <p>one</p>
          <p>two</p>
          <p>three</p>
        </div>
        
        """, html);
    }

    [Fact]
    public void CanConstructListInSpanPrettyPrinted()
    {
        var list = Span(List(Span("one"), Span("two"), Span("three")));
        var html = list.PrettyPrint();
        _output.WriteLine(html);
        Assert.Equal("""
        <span><span>one</span><span>two</span><span>three</span></span>
        """, html);
    }

    [Fact]
    public void ListIgnoresAttributes()
    {
        var list = List(("id", "test"));
        Assert.Equal(string.Empty, list.ToString());
        Assert.Equal(string.Empty, list.PrettyPrint());
    }

    [Fact]
    public void ListIgnoresAttributesWithChildTag()
    {
        var list = List(("id", "test"), P("test"));
        Assert.Equal("<p>test</p>", list.ToString());
        Assert.Equal("<p>test</p>\r\n", list.PrettyPrint());
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
    public void CanRenderTemplateNode()
    {
        var tt = new TextTemplate();
        var link = A("#text", tt);


        var html = link.ToString();
        _output.WriteLine(html);
        Assert.Equal("<a href=\"#text\"></a>", html);

        tt.Text = "Some Text";
        var html2 = link.ToString();
        _output.WriteLine(html2);
        Assert.Equal("<a href=\"#text\">Some Text</a>", html2);
    }

    [Fact]
    public void CanRenderTemplateNodeAsAttributeValue()
    {
        var tt = new TextTemplate();
        var div = Div(("class", tt));


        var html = div.ToString();
        _output.WriteLine(html);
        Assert.Equal("<div class=\"\"></div>", html);

        tt.Text = "myClass";
        var html2 = div.ToString();
        _output.WriteLine(html2);
        Assert.Equal("<div class=\"myClass\"></div>", html2);
    }

    private class TextTemplate : ITemplate
    {
        private string _text = "";
        private Text _cachedNode = Text("");

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                _cachedNode = Text(value);
            }
        }

        public Node Render() => _cachedNode;
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