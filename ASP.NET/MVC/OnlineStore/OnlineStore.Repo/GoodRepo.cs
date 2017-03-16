using OnlineStore.DAL.Entities;
using OnlineStore.Repo.Common;
using System.Data.Entity;

namespace OnlineStore.Repo
{
    public class GoodRepo : GenericRepo<Good>
    {
        IUnitOfWork _unit;
        public GoodRepo(DbContext context, IUnitOfWork unit) :
            base(context)
        {
            _unit = unit;
        }
    }
}
