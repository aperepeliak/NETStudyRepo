using GH.WebUI.Core.Dtos;
using GH.WebUI.Core.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using GH.WebUI.Persistence;
using GH.WebUI.Core;

namespace GH.WebUI.Controllers.Api
{
    public class FollowingsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_unitOfWork.Followings.GetFollowing(userId, dto.FolloweeId) != null)
                return BadRequest("Following already exists.");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            _unitOfWork.Followings.Add(following);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFollowing(string id)
        {
            var userId = User.Identity.GetUserId();
            var following = _unitOfWork.Followings.GetFollowing(userId, id);

            if (following == null) return NotFound();

            _unitOfWork.Followings.Remove(following);
            _unitOfWork.Complete();

            return Ok(id);
        }
    }
}
