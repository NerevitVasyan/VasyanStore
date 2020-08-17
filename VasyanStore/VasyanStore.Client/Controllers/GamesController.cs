using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VasyanStore.Client.Models;
using VasyanStore.Domain.Services.Abstraction;

namespace VasyanStore.Client.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesService _gamesService;
        private readonly IMapper _mapper;
        public GamesController(IGamesService gamesService,IMapper mapper)
        {
            _gamesService = gamesService;
            _mapper = mapper;
        }

        // GET: Games
        public ActionResult Index()
        {
            var games = _gamesService.GetAllGames();

            //var gameModels = new List<GameViewModel>();
            ////Mapping
            //foreach(var game in games)
            //{
            //    gameModels.Add(new GameViewModel
            //    {
            //        Id = game.Id,
            //        Name = game.Name,
            //        Genre = game.Genre.Name,
            //        Developer = game.Developer.Name,
            //        Price = game.Price,
            //        ReleaseDate = game.ReleaseDate
            //    });
            //}

            var gameModels = _mapper.Map<ICollection<GameViewModel>>(games);

            //var test = _mapper.Map<ICollection<DataAccess.Entities.Game>>(gameModels);

            ViewBag.Games = gameModels;
            return View();
        }
    }
}