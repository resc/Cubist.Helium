using System.ComponentModel;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples;

[Description("How to change rendering of atrtibutes")]
public static class Attributes
{
    [Example("A double-quoted attribute value")]
    public static Node DoubleQuoted()
        => Div(
            ("class", "double-quoted"),
            "This div has a double-quoted attribute");

    [Example("A single-quoted attribute value")]
    public static Node SingleQuoted()
        => Div(
            ("class", "single-quoted".SingleQuoted()),
            "This div has a single-quoted attribute");

    [Example("An attribute value rendered without quotes")]
    public static Node NoQuotes()
        => Div(
            ("class", "no-quotes".NoQuotes()),
            "This div has an attribute without quotes");

    [Example("An attribute without a value by using He.Attr")]
    public static Node NoValue1()
        => Div("This div has an attribute without a value").Attr("autofocus");

    /// <summary> Using the null keyword causes type inference
    /// not being able to properly infer the type of the attribute tuple.
    /// For this purpose <see cref="Null"/> is available.
    /// </summary>
    [Example("An attribute without a value by using He.Null")]
    public static Node NoValue2()
        => Div(
            ("autofocus", Null),
            "This div has an attribute without a value");

    [Example("Setting the style attribute")]
    public static Node Styles()
        => Div(
            InlineStyle(
                ("margin", "1em"),
                ("padding", "1em"),
                ("border", "2px solid black")),
            "Some inline styling on this div!");

    [Example("Setting the class attribute")]
    public static Node Classes()
        => Div(
            Class("alert", "alert-success"),
            "This div has classes!");

}