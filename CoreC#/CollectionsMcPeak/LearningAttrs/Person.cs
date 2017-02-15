using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LearningAttrs
{
    class Person
    {
        [DisplayOrder(1, Foo = "test")]
        public string FirstName { get; set; }
        [DisplayOrder(0)]
        public string LastName { get; set; }
    }
}
