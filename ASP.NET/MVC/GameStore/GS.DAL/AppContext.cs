using GS.DAL.EntityConfigs;
using GS.Domain.Entities;
using System.Data.Entity;

namespace GS.DAL
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("GameStoreDb") { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreGame> GenreGames { get; set; }
        public DbSet<PlatformType> PlatformTypes { get; set; }
        public DbSet<PlatformTypeGame> PlatformTypeGames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GameConfig());
            modelBuilder.Configurations.Add(new CommentConfig());
            modelBuilder.Configurations.Add(new GenreConfig());
            modelBuilder.Configurations.Add(new GenreGameConfig());
            modelBuilder.Configurations.Add(new PlatformTypeConfig());
            modelBuilder.Configurations.Add(new PlatformTypeGameConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
