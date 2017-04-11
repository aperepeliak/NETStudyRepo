using Data.EF.Models;
using System.Data.Entity.ModelConfiguration;

namespace Data.EF.EntityConfigs
{
    public class CategoryConfig : EntityTypeConfiguration<Category>
    {
        public CategoryConfig()
        {
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
