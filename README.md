# Cubist.Helium

![Build](https://github.com/resc/Cubist.Helium/actions/workflows/dotnet.yml/badge.svg?branch=master)
![Nuget Package Version](https://img.shields.io/nuget/v/Cubist.Helium)

![Logo By Stable Diffusion](./resources/Cubist.Helium.png)

A small and simple no guardrails html generator library for .NET 6+

# What does it do?

Helium makes generating snippets of well-formed html easy.

Start by statically importing the class that gave this library its name 
so that your html snippets will look nice and clean.:

```C#
using static Cubist.Helium.He;
```
Then use the static methods of the `He` class to build your snippets of html.

```C#
var doc = Document(
            Head(
                Title("Hello, World!")),
            Body(
                H1("Hello, World!")));

```
and render it to a string.
```C#
var html = doc.ToString();
```
Or write it to a `TextWriter`
```C#
doc.WriteTo(Console.Out);
```
This will render the following html:
```html
<!DOCTYPE html><html><head><title>Hello, World!</title></head><body><h1>Hello, World!</h1></body></html>
```

Make it nicer to read using `PrettyPrint()`...
```C#
var html = doc.PrettyPrint();
// Or write it to a TextWriter
doc.PrettyPrintTo(Console.Out);
```
Much better...
```html
<!DOCTYPE html>
<html>
<head>
  <title>Hello, World!</title>
</head>
<body>
  <h1>Hello, World!</h1>
</body>
</html>
```

### A little more complicated

Now witness the power of this fully equipped and operational library! 

```C#
using static Cubist.Helium.He;

var items = new object[] { "some text", 1, DateTime.Now, };
var html = Ul(items.Select(item => Li(TemplateFor(item)))).PrettyPrint();

Node TemplateFor(object item) => item switch
{
    int i => Div("A number: ", Data(i, "The number " + i)),
    string s => Div("Some text: ", Q(Span(("style", "font-style: italic;"), s))),
    DateTime dt => Div("A date-time: ", Time(dt, dt.ToString("M"))),
    _ => Div("Some data: ", CData(item)),
};
```
Renders to:
```html
<ul>
  <li>
    <div>Some text: <q><span style="font-style: italic;">some text</span></q></div>
  </li>
  <li>
    <div>A number: <data value="1">The number 1</data></div>
  </li>
  <li>
    <div>A date-time: <time datetime="2023-03-06 17:19:28Z">6 maart</time></div>
  </li>
</ul>
```


## What did just happen?

Most elements take a params array of objects as content, for example: 

```C#
public static He Div(params object[] content) => new(Tags.Div) { content };
```

The content objects are interpreted as follows:

* Any two-element tuple is interpreted as an HTML attribute. e.g. `Div(("tabindex", 1))` renders as `<div tabindex="1"></div>`  
* Ordering of attributes relative to child elements does not matter, `Div(("tabindex", 1), "content")` and `Div("content",("tabindex", 1))` both render as `<div tabindex="1">content</div>` 
* The order of attributes relative to other attributes is kept. 
  `Div(("class","highlight"), ("tabindex", 1))` renders as `<div class="highlight" tabindex="1"></div>`
  and `Div(("tabindex", 1), ("class","highlight"))` renders as `<div tabindex="1" class="highlight"></div>`

### Type conversions during element construction

See `He.Add(object? content)` for the nitty-gritty details.

* Any two-element tuple is added to the element's attribute list as `(string, object?)` tuple, converting the first element to a string if necessary.
* Any string content is added as a child `Text` node, and written as-is to the output. `Div("some text")` becomes `<div>some text</div>`
  and `Div("<div></div>")` will render as `<div><div></div></div>`. This is the no guardrails part...
* Any content that is a .NET primitive type uses the `ToString()` method of the content and is added as a child `Text` node
* Any content that implements `IEnumerable` will be added as a range of nodes. (This can be a mixed list of attribute tuples, `Node`s, primitive types, etc...).
* Any content that does not derive from `Node` or is not a .NET primitive type uses the `ToString()` of the content and is added as a `CData` node.

## More Examples

For more examples see [Cubist.Helium.Examples](./src/Cubist.Helium.Examples/README.md).


# Design and use of the library

## Goals

### Functional Style

Helium is designed to be used in a functional style. 
Because of that the html construction looks, dare I say, almost Lisp-like.

It is also designed so that code strongly resembles the html output in structure. 
This lowers the cognitive load of using this library.

For example:
```C#
Document(
    Head(
        MetaCharsetUtf8(),
        MetaViewPort(),
        MetaRobots(index: true, follow: false),
        Link("icon", "favicon.ico"),
        Link("stylesheet", "/css/main.css"),
        Link("stylesheet", "/css/mobile.css", ("media", "screen and (max-width: 600px)")),
        Style(Css("html", ("background", "white"))),
        Script("module", "js/module.js")
    ),
    Body(
     /* more here */
    )
);
```

### Minimal Dependencies

Another goal is to have a minimal set of dependencies, preferably none.
This makes it easy to quickly code up some html without needing a lot of infrastructure in place.

### First class extensibility

Because we live in the age of custom web elements, extensibility and using custom elements should be easy and not look out-of-place.

The [Components.TodoList()](./src/Cubist.Helium.Examples/Components.cs) example shows how this works.

By creating static methods that return `Node` instances, and by using `using static <Your custom component class>;` 
your code looks like it always was a part of the Helium library. 
Or Helium will look like it was always part of your code... whichever you prefer. :wink:

## Non-goals

### Automatic HTML-encoding

Use [HttpUtility.HtmlAttributeEncode(...)](https://learn.microsoft.com/en-us/dotnet/api/system.web.httputility.htmlattributeencode) and
[WebUtility.HtmlEncode(...)](https://learn.microsoft.com/en-us/dotnet/api/system.net.webutility.htmlencode) for that.

It's not hard to integrate encoding in the same way as the `AttributeExtensions.SingleQuoted(...)` and `AttributeExtensions.NoQuotes(...)` extensions.

#### Example
```C#
using System.Net;
using System.Web;
using Cubist.Helium;

namespace My.Encoders;

public static class EncodingExtensions
{
    public static HtmlEncoder HtmlEncoded(this string text) 
        => new HtmlEncoder(text);

    public static HtmlAttributeEncoder AttrEncoded(this string text) 
        => new HtmlAttributeEncoder(text);
}

public sealed class HtmlEncoder : Node 
{
    public string Value { get; }
    public HtmlEncoder(string value) => Value = value; 

    // HttpUtility.HtmlEncode calls WebUtility.HtmlEncode under the hood, 
    // so we use WebUtility.HtmlEncode directly.
    public override void WriteTo(TextWriter w) => WebUtility.HtmlEncode(Value, w);
}

public sealed class HtmlAttributeEncoder : Node 
{
    public string Value { get; }
    public HtmlAttributeEncoder(string value) => Value = value; 
    public override void WriteTo(TextWriter w) => HttpUtility.HtmlAttributeEncode(Value, w);
}
```
#### Usage

```C#
using My.Encoders;
using static Cubist.Helium.He;

var html = Div(
    ("data-value", "<'&>".AttrEncoded()), 
    "A custom element like this: <todo-list>".HtmlEncoded()).ToString();
```
output:
```
<div data-value="&lt;&#39;&amp;>">A custom element like this: &lt;todo-list&gt;</div>
```

#### Or slghtly different...

```C#
using static My.Encoders.EncodingExtensions;
using static Cubist.Helium.He;

var html = Div(
    ("data-value", AttrEncoded("<'&>")), 
    HtmlEncoded("A custom element like this: <todo-list>")).ToString();
```
output:
```
<div data-value="&lt;&#39;&amp;>">A custom element like this: &lt;todo-list&gt;</div>
```

### Templates, validation methods, model binding and the kitchen sink. 

If you want that, [ASP.NET](https://learn.microsoft.com/en-us/aspnet/core/) has you covered.

### Performance 

Nope, isn't a goal. Although it should be as fast as possible while still using 
the `TextWriter` class as the output mechanism this library will never be the fastest.

Creating the element tree and then rendering it can generate quite a bit of work for the garbage collector.
Lucky for this library the .NET garbage collector is excellent at cleaning up lots of small objects that don't live long.

### Using the element tree as an AST

Creating the element tree and then post-process that tree extensively will not be a supported use-case.

# Contributing

Bug reports and pull requests are encouraged! 

Please read the above goals and non-goals to get a feel for the spirit of this library.
This will help get your pull request accepted quickly ( as will new unit tests! )

Code that does not have the MIT license will not be accepted.

# Code of Conduct

This seems to be all the rage these days, so here you go.

DBAA also known as _Don't be a posterior orifice_. We're all people here. Thank you!
