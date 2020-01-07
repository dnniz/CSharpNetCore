using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSharpNetCore.Entidades
{
    public class Alumno : ObjetoEscuelaBase
    {
        public string AlumnoId { get; set; }
        public virtual List<Evaluacion> Evaluaciones { get; set; }
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