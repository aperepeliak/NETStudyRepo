using GS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GS.DAL.EntityConfigs
{
    public class GenreGameConfig : EntityTypeConfiguration<GenreGame>
    {
        public GenreGameConfig()
        {
            HasKey(g => new { g.GameId, g.GenreId });
        }
    }
}