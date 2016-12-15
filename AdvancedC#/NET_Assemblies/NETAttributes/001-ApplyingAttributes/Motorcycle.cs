using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_ApplyingAttributes
{
    [Serializable]
    public class Motorcycle
    {
        [NonSerialized]
        float weightOfCurrentPassengers;

        // These fields are still serializable
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }
}
