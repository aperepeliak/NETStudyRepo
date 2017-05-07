using CodeFirstPractice.Entities;
using System.Data.Entity;

namespace CodeFirstPractice
{
    public class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=DefaultConnection")
        { }

        public DbSet<Course>   Courses { get; set; }
        public DbSet<Author>   Authors { get; set; }
        public DbSet<Tag>      Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(t => t.Description)
                .IsRequired();
        }
    } 
}
