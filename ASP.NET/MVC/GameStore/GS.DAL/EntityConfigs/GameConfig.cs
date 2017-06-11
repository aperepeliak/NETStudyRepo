using GS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GS.DAL.EntityConfigs
{
    public class GameConfig : EntityTypeConfiguration<Game>
    {
        public GameConfig()
        {
            HasKey(g => g.Id);

            Property(g => g.Name)
                .HasMaxLength(50);

            Property(g => g.Description)
                .HasMaxLength(150);
        }
    }
}
