using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Perfile
    {
        public Perfile()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
