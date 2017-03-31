using Microsoft.AspNet.Identity.EntityFramework;

namespace BAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
