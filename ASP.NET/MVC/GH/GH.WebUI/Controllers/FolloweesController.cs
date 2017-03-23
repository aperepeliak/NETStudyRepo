using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using GH.WebUI.Models;

namespace GH.WebUI.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public FolloweesController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var artists = _context.Followings
                    .Where(f => f.FollowerId == userId)
                    .Select(f => f.Followee)
                    .ToList();

            return View(artists);
        }
    }
}