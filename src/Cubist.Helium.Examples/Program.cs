using System.Collections.Concurrent;
using System.CommandLine;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples;

internal class Program
{
    static async Task<int> Main(string[] args)
    {
        var description = $"Render the examples for the {typeof(He).Assembly.GetName().Name} library." +
                          $"See the source code for the code examples";
        var root = new RootCommand(description);
        var prettyPrintOption = new Option<bool>(
            aliases: new[] { "--pretty-print", "-p" },
            description: "Add this option to indent the output");
        root.AddGlobalOption(prettyPrintOption);
        var fullDocumentOption = new Option<bool>(
            aliases: new[] { "--full-document", "-f" },
            description: "Add this option to embed the example in a full document");
        root.AddGlobalOption(fullDocumentOption);

        AddExampleCommands(root, prettyPrintOption, fullDocumentOption);

        return await root.InvokeAsync(args);
    }

    private static void AddExampleCommands(RootCommand root, Option<bool> prettyPrintOption, Option<bool> fullDocumentOption)
    {
        var examples = typeof(Program).Assembly.GetTypes()
            .SelectMany(x => x.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
            .Where(m => m.IsDefined(typeof(ExampleAttribute)))
            .Where(m => typeof(Node).IsAssignableFrom(m.ReturnType) && m.GetParameters().Length == 0)
            .OrderBy(m => m.DeclaringType?.Name ?? "")
            .ThenBy(m => m.Name)
            .ToList();

        var groups = new ConcurrentDictionary<string, Command>();

        Command GetGroup(MemberInfo t)
        {
            var name = t.DeclaringType?.Name ?? "";
            var desc = t.DeclaringType?.GetCustomAttribute<DescriptionAttribute>()?.Description ?? $"{name} examples";
            return groups.GetOrAdd(name, static (n, d) => new Command(n.ToLowerInvariant(), d), desc);
        }

        foreach (var example in examples)
        {
            var group = GetGroup(example);
            var meta = example.GetCustomAttribute<ExampleAttribute>()!;
            var desc = meta.Description;
            var cmd = new Command(example.Name.ToLowerInvariant(), desc);
            cmd.SetHandler((prettyPrint, fullDocument) => { Render(example, meta, prettyPrint, fullDocument); }, prettyPrintOption, fullDocumentOption);
            group.AddCommand(cmd);
        }

        foreach (var group in groups.OrderBy(x => x.Key))
        {
            root.AddCommand(group.Value);
        }

    }

    private static void Render(MethodInfo example, ExampleAttribute meta, bool prettyPrint, bool fullDocument, [CallerFilePath] string? filePath = null)
    {
        Debug.Assert(filePath != null);
        var projectDir = Path.GetDirectoryName(filePath)!;
        var file = Path.GetRelativePath(projectDir, meta.FilePath);

        var node = (Node)example.Invoke(null, Array.Empty<object>())!;
        if (node is not HtmlDocument && fullDocument)
        {
            node = Document(
                Head(
                    Title(example.Name, " Example"),
                    MetaViewPort()),
                Body(
                    H1(example.Name, " Example"),
                    P(meta.Description),
                    P(A(new Uri(meta.FilePath), $"See {file} line {meta.LineNo}")),
                    Hr(),
                    Comment("example starts here"),
                    node,
                    Comment("example ends here"),
                    Hr()));
        }
        if (prettyPrint)
        {
            using var indent = new IndentWriter(Console.Out);
            node.PrettyPrintTo(indent);
        }
        else
        {
            node.WriteTo(Console.Out);
        }

    }
}