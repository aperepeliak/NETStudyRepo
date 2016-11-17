using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    public interface IPointy
    {
        // Implicitly public and abstract
        byte Points { get; }
    }
}
