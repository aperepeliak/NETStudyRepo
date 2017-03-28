using GH.WebUI.Core.Models;
using GH.WebUI.Core.Repositories;
using GH.WebUI.Persistence;
using System.Linq;

namespace GH.WebUI.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string userId, string artistId)
        {
            return _context.Followings
                   .SingleOrDefault(f => f.FolloweeId == artistId && f.FollowerId == userId);
        }
    }
}