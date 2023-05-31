using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Direccione
    {
        public Direccione()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Calle { get; set; } = null!;
        public string Colonia { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Municipio { get; set; } = null!;
        public string Telefono { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
