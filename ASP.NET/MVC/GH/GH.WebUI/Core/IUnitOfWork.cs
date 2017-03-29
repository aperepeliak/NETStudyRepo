using GH.WebUI.Core.Repositories;

namespace GH.WebUI.Core
{
    public interface IUnitOfWork
    {
        IAttendanceRepository        Attendances       { get; }
        IFollowingRepository         Followings        { get; }
        IGenreRepository             Genres            { get; }
        IGigRepository               Gigs              { get; }
        IUserNotificationRepository  UserNotifications { get; }
        INotificationRepository      Notifications     { get; }

        void Complete();
    }
}