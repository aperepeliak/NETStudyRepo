using System;
using System.Collections.Generic;

namespace Mvc5IdentityExample.Domain.Entities
{
    public class User
    {
        private ICollection<Claim>          _claims;
        private ICollection<ExternalLogin>  _externalLogins;
        private ICollection<Role>           _roles;

        // scalar props
        public Guid           UserId { get; set; }
        public string         UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }

        // Nav props
        public virtual ICollection<Claim> Claims
        {
            get => _claims ?? (_claims = new List<Claim>());
            set => _claims = value;
        }

        public virtual ICollection<ExternalLogin> Logins
        {
            get => _externalLogins ??
                    (_externalLogins = new List<ExternalLogin>());

            set => _externalLogins = value;
        }

        public virtual ICollection<Role> Roles
        {
            get => _roles ?? (_roles = new List<Role>());
            set => _roles = value;
        }
    }
}
