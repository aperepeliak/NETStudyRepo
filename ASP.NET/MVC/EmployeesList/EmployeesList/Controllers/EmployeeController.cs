using EmployeesList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeesList.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var model = _employees.OrderBy(e => e.HireDate);
            return View(model);
        }

        static List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                EmployeeId = 1,
                FirstName = "Zippy",
                LastName = "Yugo",
                DateBirthday = new DateTime(1989, 2, 23),
                HireDate = new DateTime(2007, 1, 1),
                INN = "333-222-11"
            },
            new Employee
            {
                EmployeeId = 2,
                FirstName = "Joe",
                LastName = "Dow",
                DateBirthday = new DateTime(1987, 3, 2),
                HireDate = new DateTime(2007, 10, 11),
                INN = "001-555-11"
            },
            new Employee
            {
                EmployeeId = 3,
                FirstName = "Foo",
                LastName = "Bar",
                DateBirthday = new DateTime(1980, 1, 3),
                HireDate = new DateTime(2017, 1, 19),
                INN = "333-000-11"
            },
            new Employee
            {
                EmployeeId = 4,
                FirstName = "John",
                LastName = "Johnson",
                DateBirthday = new DateTime(1988, 2, 2),
                HireDate = new DateTime(2000, 11, 1),
                INN = "333-777-99"
            },
            new Employee
            {
                EmployeeId = 5,
                FirstName = "Bruce",
                LastName = "Almighty",
                DateBirthday = new DateTime(1977, 7, 7),
                HireDate = new DateTime(2007, 7, 7),
                INN = "000-000-01"
            }
        };
    }
}