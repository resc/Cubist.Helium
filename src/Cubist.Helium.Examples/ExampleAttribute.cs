using System.Runtime.CompilerServices;

namespace Cubist.Helium.Examples;

[AttributeUsage(AttributeTargets.Method)]
internal class ExampleAttribute : Attribute
{
    public string Description { get; }
    public string FilePath { get; }
    public int LineNo { get; }

    public ExampleAttribute(string description, [CallerFilePath] string? filePath = null, [CallerLineNumber] int lineNo = 0)
    {
        Description = description;
        FilePath = filePath ?? "";
        LineNo = lineNo;
    }
}