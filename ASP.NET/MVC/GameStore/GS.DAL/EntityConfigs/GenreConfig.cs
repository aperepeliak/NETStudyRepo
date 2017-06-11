using GS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GS.DAL.EntityConfigs
{
    public class GenreConfig: EntityTypeConfiguration<Genre>
    {
        public GenreConfig()
        {
            Property(g => g.Name)
                .HasMaxLength(50);
        }
    }
}
