using System;

namespace Mvc5IdentityExample.Domain.Entities
{
    public class ExternalLogin
    {
        private User _user;

        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
        public virtual Guid UserId { get; set; }

        public virtual User User
        {
            get => _user;

            set
            {
                _user = value;
                UserId = value.UserId;
            }
        }
    }
}