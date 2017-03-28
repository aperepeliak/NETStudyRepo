using GH.WebUI.Repositories;

namespace GH.WebUI.Persistence
{
    public interface IUnitOfWork
    {
        IAttendanceRepository Attendances { get; }
        IFollowingRepository  Followings { get; }
        IGenreRepository      Genres { get; }
        IGigRepository        Gigs { get; }

        void Complete();
    }
}