using DomainLayer.Models;
using System.Data.Entity.ModelConfiguration;

namespace Data.EF.EntityConfigs
{
    public class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            Property(p => p.CategoryId)
                .IsRequired();

            Property(p => p.SupplierId)
                .IsRequired();

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            HasRequired(p => p.Category)
                .WithMany(c => c.Products);

            HasRequired(p => p.Supplier)
                .WithMany(s => s.Products);
        }
    }
}
