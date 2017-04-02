using ST.Core.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST.Core.Models;

namespace ST.DAL.Repos
{
    public class SkillRepo : ISkillRepo
    {
        private readonly ApplicationDbContext _context;

        public SkillRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Skill skill)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skill> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skill> GetByCategory()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Skill skill)
        {
            throw new NotImplementedException();
        }
    }
}
