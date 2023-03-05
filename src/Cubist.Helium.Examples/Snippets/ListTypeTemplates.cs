using System.ComponentModel;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples.Snippets;

[Description("Generate a &lt;ul&gt; list from diverse types")]
public class ListTypeTemplates : IExample
{
    private readonly List<object> _items = new() { "some text", 1, DateTime.Now, };

    public Node Render() => Ul(_items.Select(item => Li(ItemTemplate(item))));

    private Node ItemTemplate(object item)
        => item switch
        {
            int i => Div("A number: ", Data(i, i.ToString())),
            string s => Div("Some text: ", Q(Span(("style", "font-style: italic;"), s))),
            DateTime dt => Div("A date-time: ", Time(dt, dt.ToString("M"))),
            _ => Div("Some data: ", CData(item)),
        };
}