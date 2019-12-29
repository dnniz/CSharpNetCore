using System.Collections.Generic;
using CSharpNetCore.Entidades;

namespace Etapa1.Entidades
{
    public class Alumno : ObjetoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones { get; set; }
    }
}