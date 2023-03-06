using System.ComponentModel;
using System.Text.Json.Nodes;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples;

[Description("JSON rendering examples")]
public static class Json
{
    [Example("Create a script import map from a Dictionary<string, object>")]
    public static Node FromDictionary()
        => Script(
            ("type", @"importmap"),
            He.Json(new Dictionary<string, object>
            {
                {
                    "import", new Dictionary<string, string>
                    {
                        { "name", "./path/to/module" }
                    }
                }
            }));


    [Example("Create a script import map from a JsonObject")]
    public static Node FromJsonObject()
        => Script(
            ("type", @"importmap"),
            new JsonObject
            {
                {
                    "import", new JsonObject
                    {
                        { "name", "./path/to/module" }
                    }
                }
            });

    [Example("Create a script import map from a raw string, pretty-printing doesn't work here.")]
    public static Node FromRawText()
        => Script(
            ("type", @"importmap"),
            @"{ ""imports"": { ""square"": ""./module/shapes/square.js"",
  ""circle"": 
""https://example.com/shapes/circle.js""    }
}");
}