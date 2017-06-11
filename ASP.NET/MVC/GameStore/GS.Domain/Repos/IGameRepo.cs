using GS.Domain.Entities;

namespace GS.Domain.Repos
{
    public interface IGameRepo : IBaseRepo<Game>
    {
        Game Get(string id);
    }
}
