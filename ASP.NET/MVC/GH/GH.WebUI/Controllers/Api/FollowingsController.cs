using GH.WebUI.Dtos;
using GH.WebUI.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GH.WebUI.Controllers.Api
{
    public class FollowingsController : ApiController
    {
        ApplicationDbContext _context;
        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == dto.FolloweeId))
                return BadRequest("Following already exists.");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFollowing(string id)
        {
            var userId = User.Identity.GetUserId();
            var following = _context.Followings
                    .SingleOrDefault(f => f.FolloweeId == id && f.FollowerId == userId);

            if (following == null) return NotFound();

            _context.Followings.Remove(following);
            _context.SaveChanges();

            return Ok(id);
        }
    }
}
