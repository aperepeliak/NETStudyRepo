using GH.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GH.WebUI.Repositories
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