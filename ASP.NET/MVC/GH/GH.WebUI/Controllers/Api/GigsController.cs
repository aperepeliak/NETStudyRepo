using Microsoft.AspNet.Identity;
using System.Web.Http;
using GH.WebUI.Core;

namespace GH.WebUI.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly IUnitOfWork _unitOfwork;
        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _unitOfwork.Gigs.GetGigWithAttendees(id);

            if (gig == null)
                return NotFound();

            if (gig.IsCanceled)
                return NotFound();

            if (gig.ArtistId != userId)
                return Unauthorized();

            gig.Cancel();

            _unitOfwork.Complete();

            return Ok();
        }
    }
}
