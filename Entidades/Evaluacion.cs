using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpNetCore.Entidades
{
    public class Evaluacion : ObjetoEscuelaBase
    {
        public string EvaluacionId { get; set; }
        public string AlumnoId { get; set; }
        [ForeignKey("AlumnoId")]
        public Alumno Alumno { get; set; }
        public string AsignaturaId { get; set; }

        [ForeignKey("AsignaturaId")]
        public Asignatura Asignatura { get; set; }
        public double Nota { get; set; }

        public double Promedio { get; set; }
        
        public override string ToString()
        {
            return $"{Nota} {Alumno.Nombre} {Asignatura.Nombre}";
        }

        public override string PrintExclusive()
        {
            return $"{Nota} {Alumno.Nombre} {Asignatura.Nombre}";
        }
        public Evaluacion() => EvaluacionId = UniqueId;
    }
}