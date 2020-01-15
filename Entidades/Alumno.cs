using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSharpNetCore.Entidades
{
    [Table("Alumnos")]
    public class Alumno : ObjetoEscuelaBase
    {
        [Key]
        public string AlumnoId { get; set; }
        public virtual List<Evaluacion> Evaluaciones { get; set; }

        [Required]
        public override string Nombre { get; set; }

        public string CursoId { get; set; }
        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
        public override string PrintExclusive()
        {
            var mayorPuntaje = Evaluaciones?.OrderByDescending(x => x.Nota).FirstOrDefault();
            return $"Nombre: {Nombre}, Mejor Nota: {Math.Round(mayorPuntaje.Nota, 2)}";
        }

        public Alumno() => AlumnoId = UniqueId;
    }
}