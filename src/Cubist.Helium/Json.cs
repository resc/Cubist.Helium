using System.Text.Json;

namespace Cubist.Helium;

public class Json : Node
{
    private JsonSerializerOptions? _options;

    public JsonSerializerOptions Options
    {
        get => _options ??= new JsonSerializerOptions();
        init => _options = value;
    }

    public object Value { get; }

    public Json(object value)
    {
        Value = value;
    }

    public override void WriteTo(TextWriter w)
    {
        var json = JsonSerializer.Serialize(Value, Options);
        w.Write(json);
    }
}