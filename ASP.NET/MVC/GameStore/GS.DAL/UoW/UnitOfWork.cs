using GS.Domain.UoW;
using GS.Domain.Repos;
using GS.DAL.Repos;

namespace GS.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _db;

        public IGameRepo Games { get; }
        public ICommentRepo Comments { get; }
        public IGenreRepo Genres { get; }
        public IPlatformRepo PlatformTypes { get; }


        public UnitOfWork(AppContext db)
        {
            _db = db;

            Games = new GameRepo(_db);
            Comments = new CommentRepo(_db);
            Genres = new GenreRepo(_db);
            PlatformTypes = new PlatformRepo(_db);
        }

        public void Complete()
        {
            _db.SaveChanges();
        }
    }
}
