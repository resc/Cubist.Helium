using System.ComponentModel;
using System.Text.Json.Nodes;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples.Json;

[Description("Create a script import map from a JsonObject")]
public class  FromJsonObject : IExample
{
    public Node Render()
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
}