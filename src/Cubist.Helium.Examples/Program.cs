using System.Collections.Concurrent;
using System.CommandLine;
using System.ComponentModel;
using System.Reflection;
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
            aliases:new []{ "--pretty-print", "-p"},
            description: "Add this option to indent the output");
        root.AddGlobalOption(prettyPrintOption);

        AddExampleCommands(root, prettyPrintOption);

        return await root.InvokeAsync(args);
    }

    private static void AddExampleCommands(RootCommand root, Option<bool> prettyPrintOption)
    {
        var types = typeof(Program).Assembly.GetTypes()
            .Where(t => typeof(IExample).IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null)
            .OrderBy(t => t.Name);

        var groups = new ConcurrentDictionary<string, Command>();

        Command GetGroup(Type t)
        {
            var ns = t.Namespace ?? "";
            var name = ns.Split('.').Last();
            return groups.GetOrAdd(name, n => new Command(n.ToLowerInvariant(), $"{n} examples"));
        }

        foreach (var type in types)
        {
            var group = GetGroup(type);

            var example = type;
            var desc = example.GetCustomAttribute<DescriptionAttribute>()?.Description ?? "";
            var cmd = new Command(example.Name.ToLowerInvariant(), desc);
            cmd.SetHandler((prettyPrint) => { Render(example, desc, prettyPrint); }, prettyPrintOption);
            group.AddCommand(cmd);
        }

        foreach (var group in groups.OrderBy(x => x.Key))
        {
            root.AddCommand(group.Value);
        }

    }

    private static void Render(Type exampleType, string description, bool prettyPrint)
    {
        if (Activator.CreateInstance(exampleType) is not IExample example)
            return;

        var node = example.Render();
        if (node is not HtmlDocument)
        {
            node = Document(
                Head(
                    Title(exampleType.Name, " Example"),
                    MetaViewPort()),
                Body(
                    H1(exampleType.Name, " Example"),
                    P(description),
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