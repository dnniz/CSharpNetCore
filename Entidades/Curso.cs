using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNetCore.Util;

namespace CSharpNetCore.Entidades
{
    public class Curso : ObjetoEscuelaBase, ILugar
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; }
        public string Direccion { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Nombre} {Environment.NewLine}UniqueId: {UniqueId} {Environment.NewLine}Jornada: {Jornada}";
        }

        public void ActualizarReferencia()
        {
            Printer.PrintTitulo("Actualizando Referencia Del Curso...");

            Printer.PrintTitulo("::::Referencia Del Curso Actualizada::::");
        }

        public Curso() => (Direccion) = $"[CURSO EN LINEA]";

        public override string PrintExclusive()
        {
            var groupByAlumno = Evaluaciones.GroupBy(x => x.Alumno);
            var lstNotasPorAlumno = groupByAlumno.Select(group => new Evaluacion { Alumno = group.Key, Nota = (group.Sum(x => x.Nota)/group.Count()) });
            var mejorAlumno = lstNotasPorAlumno.OrderByDescending( x => x.Nota).FirstOrDefault();

            return $"Nombre: {Nombre}, Mejor Alumno del curso: {mejorAlumno.Alumno.Nombre} con la Nota Promedio de: {Math.Round( mejorAlumno.Nota, 2)}";
        }

    }
}