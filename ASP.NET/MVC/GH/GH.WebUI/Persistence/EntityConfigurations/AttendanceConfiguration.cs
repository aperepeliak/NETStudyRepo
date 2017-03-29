using GH.WebUI.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GH.WebUI.Persistence.EntityConfigurations
{
    public class AttendanceConfiguration : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            HasKey(a => new { a.GigId, a.AttendeeId });
        }
    }
}