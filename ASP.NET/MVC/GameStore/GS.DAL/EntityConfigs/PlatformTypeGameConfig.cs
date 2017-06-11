using GS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GS.DAL.EntityConfigs
{
    public class PlatformTypeGameConfig : EntityTypeConfiguration<PlatformTypeGame>
    {
        public PlatformTypeGameConfig()
        {
            HasKey(p => new { p.GameId, p.PlatformTypeId });
        }
    }
}
