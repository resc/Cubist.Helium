﻿using System.ComponentModel;
using System.Text.Json.Nodes;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples;

[Description("Full document examples")]
public static class Doc
{
    [Example("A minimal empty html document")]
    public static Node Minimal()
        => Document(
            Head(
                Title("Hello, World!")),
            Body(
                H1("Hell, World!")));

    [Example("Html document metadata example")]
    public static Node Metadata()
        =>
            Document(
                Head(
                    MetaCharsetUtf8(),
                    MetaViewPort(),
                    MetaRobots(index: true, follow: false),
                    Link("icon", "favicon.ico"),
                    Link("stylesheet", "/css/main.css"),
                    Link("stylesheet", "/css/mobile.css", ("media", "screen and (max-width: 600px)")),
                    Style(Css("html", ("background", "white"))),
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