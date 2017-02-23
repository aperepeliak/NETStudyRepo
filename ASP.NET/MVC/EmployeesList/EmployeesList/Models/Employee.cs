using System.ComponentModel.DataAnnotations;

namespace EmployeesList.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public System.DateTime DateBirthday { get; set; }

        [Display(Name = "Hire Date")]
        public System.DateTime HireDate { get; set; }

        public string INN { get; set; }
    }
}