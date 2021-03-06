﻿using System.Linq;
using CSharpNetCore.Entidades;
using CSharpNetCore.App;
using CSharpNetCore.Util;
using static System.Console;

namespace CSharpNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer.PrintTitulo("Implementación de Lista Genérica y ejemplo de delegados con lambda");

            var escuelaEng = new EscuelaEngine();
            escuelaEng.Inicializar();

            ImprimirCursosEscuela(escuelaEng);

            Printer.PrintTitulo("Pruebas de Polimorfismo");


            var lstObjetos = escuelaEng.ListarObjetoBase(
                out int cantCursos,
                out int cantAlumnos,
                out int cantAsignaturas,
                out int cantEvaluaciones);

            var listaIlugar = lstObjetos.Where(x => x is ILugar).ToList();

            var diccionario = escuelaEng.ObtenerDiccionarioEscuela();
            
            escuelaEng.ImprimirDiccionario(diccionario, LlaveDiccionario.Evaluacion);

            var reporte = new Reporte(diccionario);
            var dicEvalByAsignatura = reporte.EvaluacionesPorAsignatura();
            var dicAsigPromedioByAlum = reporte.AsignaturaPromedioPorAlumno();
            var topAlumnosByAsignatura = reporte.PromediosPorAsignatura(3);
        }

        private static void ImprimirCursosEscuela(EscuelaEngine escuelaEng)
        {
            foreach (var item in escuelaEng.Escuela.lstCursos)
            {
                WriteLine(item.ToString());
            }
        }
    }
}
