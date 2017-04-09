using ST.Core.Repos;
using System.Collections.Generic;
using ST.Core.Models;
using System.Data.Entity;

namespace ST.DAL.Repos
{
    public class ManagerRepo : IManagerRepo
    {
        private ApplicationDbContext _context;
        public ManagerRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Manager manager)     => _context.Managers.Add(manager);
        public IEnumerable<Manager> GetAll() => _context.Managers;
        public Manager GetManager(string id) => _context.Managers.Find(id);
        public void Remove(Manager manager)  => _context.Entry(manager).State = EntityState.Deleted;
    }
}
