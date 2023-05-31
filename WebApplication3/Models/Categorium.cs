using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Cursos = new HashSet<Curso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int NCursos { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
