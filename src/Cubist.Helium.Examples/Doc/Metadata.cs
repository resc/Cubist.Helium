using System.ComponentModel;
using System.Text.Json.Nodes;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples.Doc ;

[Description("Html document metadata examples")]
public class Metadata: IExample
{
    public Node Render()
        => Document(
            Head(
                MetaCharsetUtf8(),
                MetaViewPort(),
                MetaRobots(index: true, follow: false),
                Link("icon", "favicon.ico"),
                Link("stylesheet", "/css/main.css"),
                Link("stylesheet", "/css/mobile.css", ("media", "screen and (max-width: 600px)")),
                Style("html { background: white; } "),
                Script(("type", @"importmap"), new JsonObject
                {
                    {
                        "imports", new JsonObject
                        {
                            { "square", "./module/shapes/square.js" },
                            { "circle", "https://example.com/shapes/circle.js" }
                        }
                    }
                }),
                Script("module", "js/module.js")
            ),
            Body()
        );
}