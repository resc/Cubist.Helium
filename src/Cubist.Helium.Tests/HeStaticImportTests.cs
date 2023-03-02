
using System.Xml.Serialization;
using Xunit.Abstractions;
using static Cubist.Helium.He;

namespace Cubist.Helium.Tests;

public class HeStaticImportTests
{
    private readonly ITestOutputHelper _output;

    public HeStaticImportTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void DemoPage()
    {

        var doc = Document(
            Head(
                MetaCharsetUtf8(),
                MetaViewPort(),
                Link("stylesheet", "/css/main.css")
            ),
            Body(
                Div(
                    Comment("Attributes can come after elements"),
                    ("id", "mainDiv"),
                    ("class", "main"),
                    Form("POST", "/submit-form",
                        Fieldset(
                            Legend("Add Something to the database"),
                            Label("name-field", "Name"),
                            Input("text", "name", "name-field", ("placeholder", "your name")),
                            Br(),
                            Label("age-field", "Age"),
                            Input("range", "age", "age-field", ("placeholder", "your age")),
                            Br(),
                            Enumerable.Range(1, 5).SelectMany(n => new[]
                            {
                                Label($"rating-{n}", $"Rating {n}"),
                                Input("radio", "rating-field", $"rating-{n}")
                            }),
                            Br(),
                            Button("submit", "submit", "submit", "Submit")
                        )
                    ),
                    Details(
                        Summary("Demo of Helium"),
                        P("This is a more detailed explanation of what helium is")
                    ),
                    Ul(
                        Li(A("http://link.to/somewhere1", "Some link 1")),
                        Li(A("http://link.to/somewhere2", "Some link 2")),
                        Li(A("http://link.to/somewhere3", "Some link 3")),
                        Li(Meter(60, 0, 100)),
                        Li(Progress(6, 10))
                    )
                ),
                Template(
                    "Hi ",
                    Slot("user-name"),
                    ", Welcome to ",
                    Slot("event-name"))
            )
        );


       _output.WriteLine(doc.PrettyPrint());
    }
}