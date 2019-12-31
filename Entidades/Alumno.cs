using System.Collections.Generic;
using CSharpNetCore.Entidades;

namespace CSharpNetCore.Entidades
{
    public class Alumno : ObjetoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones { get; set; }
    }
}