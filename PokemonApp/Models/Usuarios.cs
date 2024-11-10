using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonApp.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public Role Rol { get; set; }
    }