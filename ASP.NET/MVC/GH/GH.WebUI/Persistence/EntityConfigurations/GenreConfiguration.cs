using GH.WebUI.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GH.WebUI.Persistence.EntityConfigurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}