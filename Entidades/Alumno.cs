using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpNetCore.Entidades
{
    public class Alumno : ObjetoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones { get; set; }

        public override string PrintExclusive()
        {
            var mayorPuntaje = Evaluaciones?.OrderByDescending(x => x.Nota).FirstOrDefault();
            return $"Nombre: {Nombre}, Mejor Nota: {Math.Round( mayorPuntaje.Nota, 2)}";
        }
    }
}