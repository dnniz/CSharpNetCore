using System;
using CSharpNetCore.Entidades;

namespace Etapa1.Entidades
{
    public class Evaluacion  : ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public double Nota { get; set; }
    }
}