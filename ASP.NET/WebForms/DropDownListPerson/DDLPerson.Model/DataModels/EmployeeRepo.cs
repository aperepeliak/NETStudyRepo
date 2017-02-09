using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDLPerson.Model
{
    public class EmployeeRepo
    {
        public static List<Employee> GetAll()
        {
            return new List<Employee>()
            {
                new Employee { EmployeeId = 1, FirstName = "Андрей", LastName = "Иванов",
                    DateBirthday = new DateTime(1989, 5, 10), INN = "222-222-22" },
                new Employee { EmployeeId = 2, FirstName = "Борис", LastName = "Петров",
                    DateBirthday = new DateTime(1992, 1, 17), INN = "123-456-00" },
                new Employee { EmployeeId = 3, FirstName = "Виталий", LastName = "Кличко",
                    DateBirthday = new DateTime(1980, 9, 1), INN = "777-766-55" },
                new Employee { EmployeeId = 4, FirstName = "Василий", LastName = "Уткин",
                    DateBirthday = new DateTime(1976, 5, 5), INN = "111-555-99" },
                new Employee { EmployeeId = 5, FirstName = "Скотт", LastName = "Аллен",
                    DateBirthday = new DateTime(1981, 8, 7), INN = "111-777-77" },
                new Employee { EmployeeId = 6, FirstName = "Гарри", LastName = "Гаррисон",
                    DateBirthday = new DateTime(1964, 3, 2), INN = "111-000-09" }
            };
        }

        public static Employee Get(int id)
        {
            List<Employee> collection = GetAll();

            return collection.Where(e => e.EmployeeId == id).FirstOrDefault();
        }
    }
}
