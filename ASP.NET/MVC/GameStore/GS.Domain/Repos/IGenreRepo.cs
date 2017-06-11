using GS.Domain.Entities;

namespace GS.Domain.Repos
{
    public interface IGenreRepo : IBaseRepo<Genre>
    {
        Genre Get(int id);
    }
}
