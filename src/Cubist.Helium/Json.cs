using System.Text.Json;

namespace Cubist.Helium;

/// <summary> Represents a JSON node </summary>
public class Json : Node
{
    private JsonSerializerOptions? _options;

    /// <summary> Json serializer options </summary>
    public JsonSerializerOptions Options
    {
        get => _options ??= new JsonSerializerOptions();
        init => _options = value;
    }

    /// <summary> the JSON value to render </summary>
    public object Value { get; }

    /// <summary> Creates a new <see cref="Json"/> instance </summary>
    public Json(object value)
    {
        Value = value;
    }

    /// <inheritdoc cref="Node.WriteTo"/>
    public override void WriteTo(TextWriter w)
    {
        var json = JsonSerializer.Serialize(Value, Options);
        w.Write(json);
    }

    /// <inheritdoc cref="Node.PrettyPrintTo"/>>
    public override void PrettyPrintTo(IndentWriter w)
    {
        var options = new JsonSerializerOptions(Options) { WriteIndented = true };
        var str = JsonSerializer.Serialize(Value, options);
        w.WriteLine(str);
    }
}