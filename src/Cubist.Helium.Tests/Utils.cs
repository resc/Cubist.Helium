using Xunit.Abstractions;

namespace Cubist.Helium.Tests;

public class Utils
{
    private readonly ITestOutputHelper _output;

    public Utils(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void PrintSortedDistinct()
    {
        var set = new HashSet<string>
        {
            "annotation-xml",
            "color-profile",
            "font-face",
            "font-face-src",
            "font-face-uri",
            "font-face-format",
            "font-face-name",
            "missing-glyph",
        };
        _output.WriteLine("\"" + string.Join("\", \"", set.OrderBy(x => x)) + "\"");
    }
}