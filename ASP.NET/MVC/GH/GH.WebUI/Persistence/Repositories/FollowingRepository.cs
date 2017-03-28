using GH.WebUI.Core.Models;
using GH.WebUI.Core.Repositories;
using GH.WebUI.Persistence;
using System.Linq;
using System;
using System.Collections.Generic;

namespace GH.WebUI.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public IEnumerable<ApplicationUser> GetFollowedArtists(string userId)
        {
            return _context.Followings
                    .Where(f => f.FollowerId == userId)
                    .Select(f => f.Followee)
                    .ToList();
        }

        public Following GetFollowing(string userId, string artistId)
        {
            return _context.Followings
                   .SingleOrDefault(f => f.FolloweeId == artistId && f.FollowerId == userId);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }
    }
}