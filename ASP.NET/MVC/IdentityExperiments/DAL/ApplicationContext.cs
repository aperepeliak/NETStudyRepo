using BAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DAL
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) 
            : base(conectionString) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
