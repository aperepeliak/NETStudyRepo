using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_ApplyingAttributes
{

    // Example of multiple attributes
    // Alternatively, we could type 
    // [Serializable]
    // [Obsolete("Just do not use")]

    [Serializable, Obsolete("Use another vehicle!")]
    public class HorseAndBuggy
    {
        // ...
    }
}
