using GH.WebUI.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GH.WebUI.Persistence.EntityConfigurations
{
    public class UserNotificationConfiguration : EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfiguration()
        {
            HasKey(n => new { n.UserId, n.NotificationId });
            
            HasRequired(n => n.User)
                .WithMany(u => u.UserNotifications)
                .WillCascadeOnDelete(false);
        }
    }
}