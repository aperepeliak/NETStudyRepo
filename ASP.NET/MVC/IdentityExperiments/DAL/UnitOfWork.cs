using BAL.Repos;
using DAL.Repos;

namespace DAL
{
    public class UnitOfWork
    {
        private readonly ApplicationContext _context;

        public IClientProfileRepo ClientProfiles { get; private set; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;

            ClientProfiles = new ClientProfileRepo(_context);
        }
    }
}
