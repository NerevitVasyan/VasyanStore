﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VasyanStore.Client.Models;
using VasyanStore.DataAccess.Entities;
using VasyanStore.Domain.Filters;
using VasyanStore.Domain.Services.Abstraction;

namespace VasyanStore.Client.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesService _gamesService;
        private readonly IMapper _mapper;
        public GamesController(IGamesService gamesService, IMapper mapper)
        {
            _gamesService = gamesService;
            _mapper = mapper;
        }

        // GET: Games
        public ActionResult Index(string type, string name)
        {
            ViewBag.Developers = _gamesService.GetDevelopers();
            ViewBag.Genres = _gamesService.GetGenres();

            // якщо в метод прийшов новий фільтр
            if (type != null & name != null)
            {
                addFilter(type, name);
            }

            //відправляємо фільтри до сервісу, де по цим фільтрам виберуться ігри
            var games = _gamesService.GetAllGames(Session["GameFilters"] as List<GameFilter>);

            var gameModels = _mapper.Map<ICollection<GameViewModel>>(games);

            return View(gameModels);
        }

        [HttpGet]
        public ActionResult Filter(string type,string name)
        {
            addFilter(type, name);

            var games = _gamesService.GetAllGames(Session["GameFilters"] as List<GameFilter>);
            var gameModels = _mapper.Map<ICollection<GameViewModel>>(games);

            return PartialView("Partial/GamesPartial",gameModels);
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public ActionResult AddGame()
        {
            ViewBag.Developers = _gamesService.GetDevelopers();
            ViewBag.Genres = _gamesService.GetGenres();

            var def = new GameViewModel() { ReleaseDate = DateTime.Now, Price = 0 };

            return View(def);
        }

        [HttpPost]
        [Authorize(Roles ="ADMIN")]
        public ActionResult AddGame(GameViewModel model)
        {
            // Перевіряємо чи модель проходить валідацію
            if (ModelState.IsValid)
            {
                //Якщо проходить, то додаємо до бази данних
                var game = _mapper.Map<Game>(model);
                _gamesService.AddGame(game);
                return RedirectToAction("Index");
            }

            //Якщо ні, то заново показуємо сторінку додавання але з помилками валідації
            ViewBag.Developers = _gamesService.GetDevelopers();
            ViewBag.Genres = _gamesService.GetGenres();

            return View(model);
        }

        private void addFilter(string type, string name)
        {
            var filters = (Session["GameFilters"] as List<GameFilter>);

            //якщо раніше фільтрів не було то виділяємо під ний пям'ять
            if (filters == null)
            {
                filters = new List<GameFilter>();
            }

            // Якщо такий фільтр уже є то тоді його видаляємо
            var f = filters.FirstOrDefault(x => x.Type == type && x.Name == name);

            if(f != null)
            {
                filters.Remove(f);
                Session["GameFilters"] = filters;
                return;
            }

            //створюємо новий фільтр
            var filter = new GameFilter
            {
                Name = name,
                Type = type
            };

            //перевіряємо тип фільтра
            if (type == "Developer")
            {
                filter.Predicate = (x => x.Developer.Name == name);
            }
            else if (type == "Genre")
            {
                filter.Predicate = (x => x.Genre.Name == name);
            }

            //додаємо фільтр до нашої колекції фільтрів
            filters.Add(filter);

            Session["GameFilters"] = filters;
        }
    }
}