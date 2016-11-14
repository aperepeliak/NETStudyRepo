using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }

        public string SSN { get; set; } = "";

        public Person(string fName, string lName, int personAge)
        {
            FirstName = fName;
            LastName = lName;
            Age = personAge;
        }

        public Person() { }

        public override string ToString()
        {
            string myState;
            myState = string.Format("[FirstName: {0}; LastName: {1}; Age: {2}]", FirstName, LastName, Age);
            return myState;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person && obj != null)
            {
                Person temp;
                temp = (Person)obj;
                if (temp.FirstName == this.FirstName
                    && temp.LastName == this.LastName
                    && temp.Age == this.Age)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        //Less labor intensive Equals() overrride if we have proper ToString() implementation
        //public override bool Equals(object obj)
        //{
        //    return obj.ToString() === this.ToString();
        //}

        // Here we are leveraging the System.String's GetHashCode() implementation
        // we are using SSN because it is unique for all instancies of class Person
        //public override int GetHashCode()
        //{
        //    return SSN.GetHashCode();
        //}

        // If you cannot find unique string data field but you have overridden toString(),
        // you can call GetHashCode() on your own string representation

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
