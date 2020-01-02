using System;

namespace CSharpNetCore.Entidades
{
    public class Evaluacion : ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public double Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota} {Alumno.Nombre} {Asignatura.Nombre}";
        }

        public override string PrintExclusive()
        {
            return $"{Nota} {Alumno.Nombre} {Asignatura.Nombre}";
        }
    }
}