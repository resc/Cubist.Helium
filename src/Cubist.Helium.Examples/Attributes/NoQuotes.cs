using System.ComponentModel;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples.Attributes;

[Description("An attribute value rendered without quotes")]
public class NoQuotes : IExample
{
    public Node Render() => Custom("attr-example", ("value", "no-quotes".NoQuotes()));
}