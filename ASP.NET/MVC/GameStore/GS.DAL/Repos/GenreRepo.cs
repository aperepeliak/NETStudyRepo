using GS.Domain.Repos;
using GS.Domain.Entities;

namespace GS.DAL.Repos
{
    public class GenreRepo : BaseRepo<Genre>, IGenreRepo
    {
        public GenreRepo(AppContext context) : base(context)
        {
            _table = _context.Genres;
        }

        public Genre Get(int id)
        {
            return _table.Find(id);
        }
    }
}
