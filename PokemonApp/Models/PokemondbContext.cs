using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PokemonApp.Models
{
    public class PokemondbContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        }