using System.ComponentModel;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples.Attributes;

[Description("An attribute without a value by using He.Attr")]
public class NoValue1 : IExample
{
    public Node Render() => Custom("attr-example").Attr("value");
}