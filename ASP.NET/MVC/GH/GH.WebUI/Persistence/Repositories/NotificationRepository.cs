using GH.WebUI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GH.WebUI.Core.Models;
using System.Data.Entity;

namespace GH.WebUI.Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private ApplicationDbContext _context;
        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetNewNotificationsFor(string userId)
        {
            return _context.UserNotifications
                    .Where(un => un.UserId == userId && !un.IsRead)
                    .Select(un => un.Notification)
                    .Include(n => n.Gig.Artist)
                    .ToList();
        }
    }
}