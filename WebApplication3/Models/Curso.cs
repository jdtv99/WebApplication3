using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string Duracion { get; set; } = null!;
        public string Ilustracion { get; set; } = null!;
        public int CategoriaId { get; set; }
        public int InstructorTitularId { get; set; }
        public int InstructorAuxiliar { get; set; }

        public virtual Categorium Categoria { get; set; } = null!;
        public virtual Instructore InstructorAuxiliarNavigation { get; set; } = null!;
        public virtual Instructore InstructorTitular { get; set; } = null!;
    }
}
