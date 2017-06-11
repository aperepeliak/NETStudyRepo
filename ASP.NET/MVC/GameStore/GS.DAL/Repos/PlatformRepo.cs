using GS.Domain.Repos;
using GS.Domain.Entities;

namespace GS.DAL.Repos
{
    public class PlatformRepo : BaseRepo<PlatformType>, IPlatformRepo
    {
        public PlatformRepo(AppContext context) : base(context)
        {
            _table = _context.PlatformTypes;
        }

        public PlatformType Get(int id)
        {
            return _table.Find(id);
        }
    }
}
