using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apaterno { get; set; } = null!;
        public int PerfilId { get; set; }
        public int DireccionId { get; set; }
        public DateTime FecNac { get; set; }
        public string Email { get; set; } = null!;
        public string Pass { get; set; } = null!;

        public virtual Direccione Direccion { get; set; } = null!;
        public virtual Perfile Perfil { get; set; } = null!;
    }
}
