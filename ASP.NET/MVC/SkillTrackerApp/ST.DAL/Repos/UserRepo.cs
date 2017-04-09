using ST.Core.Repos;
using System.Collections.Generic;
using ST.Core.Models;
using System.Linq;

namespace ST.DAL.Repos
{
    public class UserRepo : IUserRepo
    {
        private ApplicationDbContext _context;
        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetAll()    => _context.Users;
        public string GetUserRole(ApplicationUser user) => _context.Roles
                                                           .Find(user.Roles.FirstOrDefault()
                                                           .RoleId).Name;
    }
}
