using System;
using System.Collections.Generic;
using CSharpNetCore.Entidades;

namespace Etapa1.Entidades
{
    public class Curso  : ObjetoEscuelaBase
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Nombre} {Environment.NewLine}UniqueId: {UniqueId} {Environment.NewLine}Jornada: {Jornada}";
        }
    }
}