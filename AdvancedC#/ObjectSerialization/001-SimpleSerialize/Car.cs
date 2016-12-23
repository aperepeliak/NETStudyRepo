using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_SimpleSerialize
{
    [Serializable]
     public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchback;
    }
}
