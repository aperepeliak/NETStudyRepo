using ST.Core.Repos;
using System.Collections.Generic;
using ST.Core.Models;
using System.Data.Entity;

namespace ST.DAL.Repos
{
    public class DeveloperRepo : IDeveloperRepo
    {
        private ApplicationDbContext _context;
        public DeveloperRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Developer developer)     => _context.Developers.Add(developer);
        public IEnumerable<Developer> GetAll()   => _context.Developers;
        public Developer GetDeveloper(string id) => _context.Developers.Find(id);
        public void Remove(Developer developer)  => _context.Entry(developer).State = EntityState.Deleted;
    }
}
