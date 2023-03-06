using System.ComponentModel;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples
{
    [Description("Snippets of code to show common use-cases")]
    public static class Snippets
    {
        #region ListFromLists

        private static readonly List<string> _primaryColors = new() { "red", "yellow", "blue" };
        private static readonly List<string> _secondaryColors = new() { "orange", "green", "violet" };

        [Example("Generate a single <ul> list from multiple C# lists")]
        public static Node ListFromLists()
            => Ul(
                _primaryColors.Select(c => Li("Primary Color: ", c)),
                _secondaryColors.Select(c => Li("Secondary Color: ", c)));

        #endregion

        #region ListTypeTemplates

        private static readonly List<object> _items = new() { "some text", 1, DateTime.Now, };

        [Example("Generate a list for heterogeneous items")]
        public static Node ListTypeTemplates()
            => Ul(_items.Select(item => Li(SelectItemTemplate(item))));

        private static Node SelectItemTemplate(object item)
            => item switch
            {
                int i => Div("A number: ", Data(i, i.ToString())),
                string s => Div("Some text: ", Q(Span(("style", "font-style: italic;"), s))),
                DateTime dt => Div("A date-time: ", Time(dt, dt.ToString("M"))),
                _ => Div("Some data: ", CData(item)),
            };

        #endregion

    }
}
