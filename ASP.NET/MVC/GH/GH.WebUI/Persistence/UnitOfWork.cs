using GH.WebUI.Core;
using GH.WebUI.Core.Repositories;
using GH.WebUI.Persistence.Repositories;

namespace GH.WebUI.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGigRepository              Gigs              { get; private set; }
        public IAttendanceRepository       Attendances       { get; private set; }
        public IFollowingRepository        Followings        { get; private set; }
        public IGenreRepository            Genres            { get; private set; }
        public IUserNotificationRepository UserNotifications { get; private set; }
        public INotificationRepository     Notifications     { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Gigs                = new GigRepository             (_context);
            Attendances         = new AttendanceRepository      (_context);
            Followings          = new FollowingRepository       (_context);
            Genres              = new GenreRepository           (_context);
            UserNotifications   = new UserNotificationRepository(_context);
            Notifications       = new NotificationRepository    (_context);
        }

        public void Complete() => _context.SaveChanges();
    }
}