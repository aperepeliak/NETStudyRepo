using GH.WebUI.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using GH.WebUI.Core.Models;

namespace GH.WebUI.Persistence.Repositories
{
    public class UserNotificationRepository : IUserNotificationRepository
    {
        private ApplicationDbContext _context;
        public UserNotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserNotification> GetUserNotificationsFor(string userId)
        {
            return _context.UserNotifications
                    .Where(un => un.UserId == userId && !un.IsRead)
                    .ToList();
        }
    }
}