using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpNetCore.Entidades
{
    public class Asignatura : ObjetoEscuelaBase
    {
        
        public string AsignaturaId { get; set; }
        public string CursoId { get; set; }
        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }

        public virtual List<Evaluacion> Evaluaciones { get; set; }
        public override string PrintExclusive()
        {
            return $"Nombre: {Nombre.ToUpper()}";
        }

        public Asignatura() => AsignaturaId = UniqueId;
    }
}