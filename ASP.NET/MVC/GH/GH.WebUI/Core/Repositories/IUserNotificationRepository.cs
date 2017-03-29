using GH.WebUI.Core.Models;
using System.Collections.Generic;

namespace GH.WebUI.Core.Repositories
{
    public interface IUserNotificationRepository
    {
        IEnumerable<UserNotification> GetUserNotificationsFor(string userId);
    }
}