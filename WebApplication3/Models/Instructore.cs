using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Instructore
    {
        public Instructore()
        {
            CursoInstructorAuxiliarNavigations = new HashSet<Curso>();
            CursoInstructorTitulars = new HashSet<Curso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apaterno { get; set; } = null!;
        public string? UrlFoto { get; set; }
        public TimeSpan HoraClase { get; set; }
        public int CodigoInstruc { get; set; }
        public string Genero { get; set; } = null!;

        public virtual ICollection<Curso> CursoInstructorAuxiliarNavigations { get; set; }
        public virtual ICollection<Curso> CursoInstructorTitulars { get; set; }
    }
}
