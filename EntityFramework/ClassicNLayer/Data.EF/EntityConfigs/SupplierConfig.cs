using Data.EF.Models;
using System.Data.Entity.ModelConfiguration;

namespace Data.EF.EntityConfigs
{
    public class SupplierConfig : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfig()
        {
            Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(s => s.Location)
               .IsRequired()
               .HasMaxLength(50);
        }
    }
}
