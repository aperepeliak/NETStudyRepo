using GH.WebUI.Core.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using GH.WebUI.Persistence;

namespace GH.WebUI.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs
                    .Include(g => g.Attendances.Select(a => a.Attendee))
                    .Single(g => g.Id == id && userId == g.ArtistId);

            if (gig.IsCanceled) return NotFound();

            gig.Cancel();

            _context.SaveChanges();

            return Ok();
        }
    }
}
