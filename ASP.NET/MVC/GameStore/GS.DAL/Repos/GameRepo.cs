using GS.Domain.Repos;
using GS.Domain.Entities;
using System;

namespace GS.DAL.Repos
{
    public class GameRepo : BaseRepo<Game>, IGameRepo
    {
        public GameRepo(AppContext context) : base(context)
        {
            _table = _context.Games;
        }

        public Game Get(string id)
        {
            return _table.Find(id);
        }
    }
}
