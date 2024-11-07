using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonApp.Models
{
    public class Pokemon
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Debilidad { get; set; }
        public string Evolucion { get; set; }
        public decimal Peso { get; set; }
        public int Numero { get; set; }
    }