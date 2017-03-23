using GH.WebUI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
            var gig = _context.Gigs.Single(g => g.Id == id && userId == g.ArtistId);

            if (gig.IsCanceled) return NotFound();

            gig.IsCanceled = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
