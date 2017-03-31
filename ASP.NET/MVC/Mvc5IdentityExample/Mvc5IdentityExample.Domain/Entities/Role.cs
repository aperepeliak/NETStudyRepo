using System;
using System.Collections.Generic;

namespace Mvc5IdentityExample.Domain.Entities
{
    public class Role
    {
        private ICollection<User> _users;

        public Guid RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users
        {
            get => _users ?? (_users = new List<User>());
            set => _users = value;
        }
    }
}