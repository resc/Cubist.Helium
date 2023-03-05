using System.ComponentModel;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples.Attributes;

[Description("A double-quoted attribute value")]
public class DoubleQuoted : IExample
{
    public Node Render() => Custom("attr-example", ("value", "double-quoted"));
}