using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.DataLayer.DbLayer
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        [ForeignKey("Roles")]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

    }
}