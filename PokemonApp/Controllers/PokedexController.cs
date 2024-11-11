using PokemonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokemonApp.Controllers
{
    public class PokedexController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PokedexController()
        {
            _context = new ApplicationDbContext();
        }

        //show all pokemons
        public ActionResult Index()
        {
            ViewBag.Title = "Pokedex - Lista de Pokémons";

            //fetch all pokemons from the database
            var pokemons = _context.Pokemons.ToList();

            //convert the list of pokemons to a list of Pokemon models
            var pokemonList = pokemons.Select(p => new Pokemon
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Tipo = p.Tipo,
                Debilidad = p.Debilidad,
                Evolucion = p.Evolucion,
                Peso = p.Peso,
                Numero = p.Numero,
                //Descripcion = p.Descripcion,  
                //Imagen = p.Imagen             //unable to add these fields because they do not exist in the database
            }).ToList();

            return View(pokemonList);
        }

        //details
        public ActionResult Detalles(int id)
        {
            //find
            var pokemonEntity = _context.Pokemons.FirstOrDefault(p => p.Id == id);

            if (pokemonEntity == null)
            {
                return HttpNotFound();  //404 Not Found pokemon
            }

            //convert the pokemon entity to a Pokemon model
            var pokemon = new Pokemon
            {
                Id = pokemonEntity.Id,
                Nombre = pokemonEntity.Nombre,
                Tipo = pokemonEntity.Tipo,
                Debilidad = pokemonEntity.Debilidad,
                Evolucion = pokemonEntity.Evolucion,
                Peso = pokemonEntity.Peso,
                Numero = pokemonEntity.Numero,
            };

            return View(pokemon);  //return the view with the pokemon model
        }

        //close the database connection
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
