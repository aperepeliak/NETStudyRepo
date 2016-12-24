using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _001_SimpleSerialize
{
    [Serializable, XmlRoot(Namespace = "https://www.google.com")]
    public class JamesBondCar : Car
    {
        public JamesBondCar(bool skyWorthy = default(bool), bool seaWorthy = default(bool))
        {
            canFly = skyWorthy;
            canSubmerge = seaWorthy;
        }

        // default ctor for serializable object is mandatory
        public JamesBondCar() { }

        [XmlAttribute]
        public bool canFly;

        [XmlAttribute]
        public bool canSubmerge;
    }
}
