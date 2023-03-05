using System.ComponentModel;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples.Attributes
{
    [Description("A single-quoted attribute value")]
    public class SingleQuoted : IExample
    {
        public Node Render() => Custom("attr-example", ("value", "single-quoted".SingleQuoted()));
    }
}
