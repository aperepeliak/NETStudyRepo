using BAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ClientProfileRepo : IClientProfileRepo
    {
        private readonly ApplicationContext _context;

        public ClientProfileRepo(ApplicationContext context)
        {
            _context = context;
        }
    }
}
