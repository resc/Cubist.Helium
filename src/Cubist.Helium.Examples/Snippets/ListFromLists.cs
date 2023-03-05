using System.ComponentModel;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples.Snippets
{
    [Description("Generate a single <ul> list from multiple C# lists")]
    public class ListFromLists : IExample
    {
        private readonly List<string> _primaryColors = new() { "red", "yellow", "blue" };
        private readonly List<string> _secondaryColors = new() { "orange", "green", "violet" };

        public Node Render() => Ul(
            _primaryColors.Select(c => Li("Primary Color: ", c)),
            _secondaryColors.Select(c => Li("Secondary Color: ", c))
        );
    }
}
