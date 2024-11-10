using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    public class AdministradorController : Controller
    {
        public ActionResult Index()
        {
            var usersByRole = db.Usuarios
                                .GroupBy(u => u.Rol.Nombre)
                                .Select(g => new { Role = g.Key, Count = g.Count() })
                                .ToList();

            var pokemonsByType = db.Pokemons
                                   .GroupBy(p => p.Tipo)
                                   .Select(g => new { Tipo = g.Key, Count = g.Count() })
                                   .ToList();

            ViewBag.UsersByRole = usersByRole;
            ViewBag.PokemonsByType = pokemonsByType;
            return View();
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