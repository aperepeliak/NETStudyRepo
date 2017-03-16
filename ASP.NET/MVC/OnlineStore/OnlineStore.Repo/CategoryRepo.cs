using OnlineStore.DAL.Entities;
using OnlineStore.Repo.Common;
using System.Data.Entity;

namespace OnlineStore.Repo
{
    public class CategoryRepo : GenericRepo<Category>
    {
        IUnitOfWork _unit;
        public CategoryRepo(DbContext context, IUnitOfWork unit)
            : base(context)
        {
            _unit = unit;
        }
    }
}
