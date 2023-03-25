using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubist.Helium
{
    /// <summary>
    /// You can implement the <see cref="ITemplate"/> interface to implement your own template engine.
    /// <see cref="ITemplate"/> instances will be wrapped by a <see cref="Template"/> instance,
    /// which will invoke <see cref="ITemplate.Render"/> every time <see cref="Node.WriteTo"/> or <see cref="Node.PrettyPrintTo"/> is called.
    /// </summary>
    public interface ITemplate
    {
        /// <summary> Renders the template to a <see cref="Node"/> </summary>
        Node Render();
    }
}
