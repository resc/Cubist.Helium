using System.ComponentModel;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples.Doc;

[Description("A minimal empty html document")]
public class Minimal : IExample
{
    public Node Render()
        => Document(
            Head(),
            Body());
}