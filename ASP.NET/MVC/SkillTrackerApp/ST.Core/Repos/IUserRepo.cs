using ST.Core.Models;
using System.Collections.Generic;

namespace ST.Core.Repos
{
    public interface IUserRepo
    {
        IEnumerable<ApplicationUser> GetAll();
        string GetUserRole(ApplicationUser user);
    } 
}
