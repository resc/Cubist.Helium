using System.ComponentModel;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples.Attributes;

[Description("An attribute without a value by using He.Null")]
public class NoValue2 : IExample
{
    /// <summary> Using the null keyword causes type inference
    /// not being able to properly infer the type of the attribute tuple.
    /// For this purpose <see cref="He.Null"/> is available.
    /// </summary>
    public Node Render() => Custom("attr-example", ("value", Null));
}