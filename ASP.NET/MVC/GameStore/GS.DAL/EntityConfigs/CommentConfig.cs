using GS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GS.DAL.EntityConfigs
{
    public class CommentConfig : EntityTypeConfiguration<Comment>
    {
        public CommentConfig()
        {
            Property(c => c.GameId)
                .IsRequired();

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Body)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
