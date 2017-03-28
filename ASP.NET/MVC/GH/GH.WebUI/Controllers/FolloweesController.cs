using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using GH.WebUI.Core.Models;
using GH.WebUI.Persistence;
using GH.WebUI.Core;

namespace GH.WebUI.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FolloweesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Index()
        {
            var artists = _unitOfWork.Followings
                .GetFollowedArtists(User.Identity.GetUserId());

            return View(artists);
        }
    }
}