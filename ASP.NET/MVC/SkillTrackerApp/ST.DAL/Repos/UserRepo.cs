using ST.Core.Repos;
using System.Collections.Generic;
using ST.Core.Models;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace ST.DAL.Repos
{
    public class UserRepo : IUserRepo
    {
        private ApplicationDbContext _context;
        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetAll()
                               => _context.Users
                                  .Where(u => u.Email != null);

        public ApplicationUser GetUserByEmail(string email)
                               => _context.Users
                                  .SingleOrDefault(u => u.Email == email);

        public string GetUserRole(ApplicationUser user) 
                               => _context.Roles
                                  .Find(user.Roles.FirstOrDefault()
                                  .RoleId).Name;

        public void Remove(ApplicationUser user)
                               => _context.Entry(user)
                                 .State = EntityState.Deleted;
    }
}
