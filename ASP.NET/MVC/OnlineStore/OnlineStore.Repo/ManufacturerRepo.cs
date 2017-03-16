using OnlineStore.DAL.Entities;
using OnlineStore.Repo.Common;
using System.Data.Entity;

namespace OnlineStore.Repo
{
    public class ManufacturerRepo : GenericRepo<Manufacturer>
    {
        IUnitOfWork _unit;
        public ManufacturerRepo(DbContext context, IUnitOfWork unit)
            : base(context)
        {
            _unit = unit;
        }
    }
}
