using GH.WebUI.Models;
using GH.WebUI.Repositories;
using GH.WebUI.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GH.WebUI.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly AttendanceRepository _attendanceRepository;
        private readonly FollowingRepository  _followingRepository;
        private readonly GigRepository        _gigRepository;
        private readonly GenreRepository      _genreRepository;

        public GigsController()
        {
            _context              = new ApplicationDbContext();

            _attendanceRepository = new AttendanceRepository (_context);
            _gigRepository        = new GigRepository        (_context);
            _genreRepository      = new GenreRepository      (_context);
            _followingRepository  = new FollowingRepository  (_context);
        }

        public ActionResult Details(int id)
        {
            var gig = _gigRepository.GetGig(id);

            if (gig == null)
                return HttpNotFound();

            var viewModel = new GigDetailsViewModel { Gig = gig };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                viewModel.IsGoing = 
                    _attendanceRepository.GetAttendance(userId, id) != null;

                viewModel.IsFollowing =
                    _followingRepository.GetFollowing(userId, gig.ArtistId) != null;
            }

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Mine()
        {
            var gigs = _gigRepository.GetUpcomingGigsByArtist(User.Identity.GetUserId());
            return View(gigs);
        }

        [Authorize]
        public ActionResult Attending()
        {
            // can't write it in a query, cause linqtoEF can't translate it into SQL
            var userId = User.Identity.GetUserId();

            var viewModel = new GigsViewModel
            {
                UpcomingGigs = _gigRepository.GetGigsUserAttending(userId),
                Attendances = _attendanceRepository.GetFutureAttendances(userId).ToLookup(a => a.GigId),
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Gigs I'm Attending"
            };

            return View("Gigs", viewModel);
        }

        [HttpPost]
        public ActionResult Search(GigsViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _genreRepository.GetGenres(),
                Heading = "Add a Gig"
            };

            return View("GigForm", viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var gig = _gigRepository.GetGig(id);

            if (gig == null)
                return HttpNotFound();

            if (gig.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            var viewModel = new GigFormViewModel
            {
                Id = gig.Id,
                Genres = _genreRepository.GetGenres(),
                Date = gig.DateTime.ToString("d MMM yyyy"),
                Time = gig.DateTime.ToString("HH:mm"),
                Genre = gig.GenreId,
                Venue = gig.Venue,
                Heading = "Edit a Gig"
            };

            return View("GigForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _genreRepository.GetGenres();
                return View("GigForm", viewModel);
            }

            var gig = _gigRepository.GetGigWithAttendees(viewModel.Id);

            if (gig == null)
                return HttpNotFound();

            if (gig.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            gig.Modify(viewModel.GetDateTime(), viewModel.Venue, viewModel.Genre);

            _context.SaveChanges();

            return RedirectToAction("Mine", "Gigs");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _genreRepository.GetGenres();
                return View("GigForm", viewModel);
            }

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _gigRepository.AddGig(gig);
            _context.SaveChanges();

            return RedirectToAction("Mine", "Gigs");
        }
    }
}