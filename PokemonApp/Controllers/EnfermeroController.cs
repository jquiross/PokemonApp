using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    private PokemondbContext db = new PokemondbContext();

    public class EnfermeroController : Controller
    {
        public ActionResult Index()
        {
            var pokemons = db.Pokemons.ToList();
            var averageWeight = pokemons.Average(p => p.Peso);
            var pokemonsByType = pokemons
                .GroupBy(p => p.Tipo)
                .Select(g => new { Tipo = g.Key, Count = g.Count() })
                .ToList();

            ViewBag.AverageWeight = averageWeight;
            ViewBag.PokemonsByType = pokemonsByType;

            return View(pokemons);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}