using GS.Domain.DTOs;
using GS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GS.WebAdmin.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [Route("games/{key:guid}")]
        public ActionResult GameDetails(string key)
        {
            var game = _gameService.GetGame(key);

            if (game == null)
                return HttpNotFound();

            var dto = new GameDto
            {
                Name = game.Name,
                Description = game.Description
            };

            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("games")]
        public ActionResult GetAllGames()
        {
            var games = _gameService.GetAll();

            if (games == null)
                return Json("no games in store", JsonRequestBehavior.AllowGet);

            var dtos = games.Select(g => new GameDto
            {
                Name = g.Name,
                Description = g.Description
            });

            return Json(dtos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("games/new")]
        public ActionResult Create(GameDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            _gameService.AddGame(dto.Name, dto.Description);

            return Json("The game was succesfully added");
        }
    }
}