using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VasyanStore.Domain.Services.Abstraction;

namespace VasyanStore.Client.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesService _gamesService;
        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        // GET: Games
        public ActionResult Index()
        {
            var games = _gamesService.GetAllGames();
            ViewBag.Games = games;
            return View();
        }
    }
}