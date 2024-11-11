using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PokemonApp.Models;

namespace PokemonApp.Models
{
    public class PokemonPokedex //tuve que crear otro modelo para poder hacer la consulta ya que no me aparecia el modelo Pokemon pero si me aparecia creado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    }
}