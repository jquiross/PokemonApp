using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    public class EntrenadorController : Controller
    {

        private PokemondbContext db = new PokemondbContext();


        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var pokemons = db.Pokemons.Where(p => p.UsuarioId == userId).ToList(); 
            var totalPokemons = pokemons.Count();
            var pokemonsByType = pokemons.GroupBy(p => p.Tipo)
                                         .Select(g => new { Tipo = g.Key, Count = g.Count() })
                                         .ToList();

            ViewBag.TotalPokemons = totalPokemons;
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