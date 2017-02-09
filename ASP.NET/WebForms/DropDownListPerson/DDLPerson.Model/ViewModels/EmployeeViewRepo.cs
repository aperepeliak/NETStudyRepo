using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDLPerson.Model.ViewModels
{
    public class EmployeeViewRepo
    {
        public static List<EmployeeView> GetAll()
        {
            List<Employee> source = EmployeeRepo.GetAll();

            return source
                .Select(e =>
                {
                    return new EmployeeView
                    {
                        EmployeeId = e.EmployeeId,
                        FullName = $"{e.LastName} {e.FirstName}"
                    };
                }).ToList();
        }

        public static EmployeeView Get(int id)
        {
            List<EmployeeView> collection = GetAll();
            return collection.Where(e => e.EmployeeId == id).FirstOrDefault();
        }
    }
}
