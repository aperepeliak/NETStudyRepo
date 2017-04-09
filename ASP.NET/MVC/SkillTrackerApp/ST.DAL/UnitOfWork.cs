using ST.Core;
using ST.Core.Repos;
using ST.DAL.Repos;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace ST.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ISkillRepo       Skills      { get; private set; }
        public ICategoryRepo    Categories  { get; private set; }
        public IDeveloperRepo   Developers  { get; private set; }
        public IManagerRepo     Managers    { get; private set; }
        public IUserRepo        AppUsers    { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Skills      = new SkillRepo     (_context);
            Categories  = new CategoryRepo  (_context);
            Developers  = new DeveloperRepo (_context);
            Managers    = new ManagerRepo   (_context);
            AppUsers    = new UserRepo      (_context);
        }

        public void Complete()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }

        } 
    }
}
