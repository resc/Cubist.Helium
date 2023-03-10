using System.Collections;

namespace Cubist.Helium;

/// <summary> Adds content or not, based on a condition </summary>
public class Conditional : IEnumerable
{
    private readonly Func<bool> _condition;
    private readonly Func<object> _content;

    /// <summary> Creates a new <see cref="Conditional"/> instance </summary> 
    public Conditional(Func<bool> condition, Func<object> content)
    {
        _condition = condition;
        _content = content;
    }
    /// <inheritdoc cref="IEnumerable.GetEnumerator"/>>
    public IEnumerator GetEnumerator()
    {
        if (_condition())
            yield return _content();
    }
}