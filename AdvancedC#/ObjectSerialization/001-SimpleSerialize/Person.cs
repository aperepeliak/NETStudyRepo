using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_SimpleSerialize
{
    [Serializable]
    class Person
    {
        public bool isAlive = true;
        private int personAge = 21;

        private string fName = string.Empty;
        public string Firstname
        {
            get { return fName; }
            set { fName = value; }
        }

    }
}
