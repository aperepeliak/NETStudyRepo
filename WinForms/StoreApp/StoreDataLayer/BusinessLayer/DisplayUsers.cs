using StoreDataLayer.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDataLayer.BusinessLayer
{
    public class DisplayUsers
    {
        public static List<User> GetUsers(StoreContext context)
        {
            string queryString = @"SELECT   UserProfile.UserId, UserProfile.UserFirstName, UserProfile.UserLastName, UserProfile.UserLogin, UserProfile.UserPassword, Role.RoleName 
                                   FROM     UserProfile LEFT JOIN Role ON (UserProfile.RoleId = Role.RoleId)";

            var query = context
                .Database
                .SqlQuery<User>(queryString);

            return query.ToList();
        }
    }
}
