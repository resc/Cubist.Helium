using System.ComponentModel;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples.Json;

[Description("Create a script import map from a Dictionary<string, object>")]
public class FromDictionary : IExample
{
    public Node Render()
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
}