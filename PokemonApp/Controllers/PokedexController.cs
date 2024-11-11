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

        // Constructor del controlador, inicializa el contexto de la base de datos.
        public PokedexController()
        {
            _context = new ApplicationDbContext();
        }

        // Acción para mostrar la lista de Pokémon
        public ActionResult Index()
        {
            ViewBag.Title = "Pokedex - Lista de Pokémons";  // Asignando un título

            // Obteniendo todos los Pokémon de la base de datos
            var pokemons = _context.Pokemons.ToList();

            // Convertir la lista de Pokémon (modelo de base de datos) a la lista de PokemonPokedex
            var pokemonPokedexList = pokemons.Select(p => new PokemonPokedex
            {
                Id = p.Id,
                Nombre = p.Name,
                Tipo = p.Type,
                Descripcion = p.Description,
                Imagen = p.Image
            }).ToList();

            return View(pokemonPokedexList);  // Pasamos la lista de Pokémon a la vista
        }

        // Acción para mostrar los detalles de un Pokémon
        public ActionResult Detalles(int id)
        {
            var pokemon = _context.Pokemons.FirstOrDefault(p => p.Id == id);  // Buscando el Pokémon por ID
            if (pokemon == null)
            {
                return HttpNotFound();  // Si no se encuentra el Pokémon, se devuelve error 404
            }

            // Convertir el Pokémon encontrado en el modelo PokemonPokedex
            var pokemonPokedex = new PokemonPokedex
            {
                Id = pokemon.Id,
                Nombre = pokemon.Name,
                Tipo = pokemon.Type,
                Descripcion = pokemon.Description,
                Imagen = pokemon.Image
            };

            return View(pokemonPokedex);  // Pasamos el Pokémon a la vista de detalles
        }

        // Aseguramos de cerrar el contexto cuando el controlador sea destruido
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();  // Liberando recursos del contexto
            }
            base.Dispose(disposing);
        }
    }
}
