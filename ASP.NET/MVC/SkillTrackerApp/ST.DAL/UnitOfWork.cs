using ST.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST.Core.Repos;
using ST.DAL.Repos;

namespace ST.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ISkillRepo Skills { get; private set; }
        public ICategoryRepo Categories { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Skills = new SkillRepo(_context);
            Categories = new CategoryRepo(_context);
        }


        public void Complete() => _context.SaveChanges();
    }
}
