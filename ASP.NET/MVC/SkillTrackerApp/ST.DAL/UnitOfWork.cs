using ST.Core;
using ST.Core.Repos;
using ST.DAL.Repos;

namespace ST.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ISkillRepo       Skills      { get; private set; }
        public ICategoryRepo    Categories  { get; private set; }
        public IDeveloperRepo   Developers  { get; private set; }
        public IManagerRepo     Managers    { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Skills      = new SkillRepo     (_context);
            Categories  = new CategoryRepo  (_context);
            Developers  = new DeveloperRepo (_context);
            Managers    = new ManagerRepo   (_context);
        }

        public void Complete() => _context.SaveChanges();
    }
}
