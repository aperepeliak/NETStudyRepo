using GS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GS.DAL.EntityConfigs
{
    public class PlatformTypeConfig : EntityTypeConfiguration<PlatformType>
    {
        public PlatformTypeConfig()
        {
            Property(p => p.Type)
                .HasMaxLength(50);
        }
    }
}
