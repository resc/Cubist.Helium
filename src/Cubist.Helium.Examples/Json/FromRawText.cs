using System.ComponentModel;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples.Json;

[Description("Create a script import map from a raw string, pretty-printing doesn't work here.")]
public class FromRawText : IExample
{
    public Node Render()
        => Script(
            ("type", @"importmap"),
            @"{ ""imports"": { ""square"": ""./module/shapes/square.js"",
  ""circle"": 
""https://example.com/shapes/circle.js""    }
}");
}