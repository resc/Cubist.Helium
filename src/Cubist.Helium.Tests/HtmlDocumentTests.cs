using Xunit.Abstractions;

namespace Cubist.Helium.Tests
{
    public class HtmlDocumentTests
    {
        private readonly ITestOutputHelper _output;

        public HtmlDocumentTests(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void EmptyDocument()
        {
            var doc = new HtmlDocument();
            var html = doc.ToString();
            Assert.Equal(@"<!DOCTYPE html><html><head></head><body></body></html>", html);
        }

        [Fact]
        public void PrettyPrintEmptyDocument()
        {
            var doc = new HtmlDocument();
            var html = doc.PrettyPrint();
            var expected = @"<!DOCTYPE html>
<html>
<head>
</head>
<body>
</body>
</html>";
            Assert.Equal(expected, html);
        }
    }
}