using System;
using System.Collections.Generic;
using CSharpNetCore.Entidades;
using Etapa1.Util;

namespace Etapa1.Entidades
{
    public class Curso  : ObjetoEscuelaBase, ILugar
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

    }
}