using GH.WebUI.Core.Models;
using System.Collections.Generic;

namespace GH.WebUI.Core.Repositories
{
    public interface IUserNotificationsRepository
    {
        IEnumerable<Notification> GetNewNotifications(string userId);
        IEnumerable<UserNotification> GetUnreadUserNotifications(string userId);
    }
}