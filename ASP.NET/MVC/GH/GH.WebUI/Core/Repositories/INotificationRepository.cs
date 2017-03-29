using GH.WebUI.Core.Models;
using System.Collections.Generic;

namespace GH.WebUI.Core.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetNewNotificationsFor(string userId);
    }
}