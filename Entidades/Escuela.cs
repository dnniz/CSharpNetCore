using System.Collections.Generic;
using CSharpNetCore.Util;

namespace CSharpNetCore.Entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {
        public string EscuelaId { get; set; }
        public int AñoCreación { get; set; }
        public TiposEscuela TipoEscuela { get; set; }

        public int CantAlumnos { get; set; }
        public virtual List<Curso> lstCursos { get; set; }
        public string Direccion { get; set; }

        public Escuela(string nombre, int año) => (Nombre, AñoCreación, EscuelaId) = (nombre, año, UniqueId);

        public Escuela(string nombre, int año, TiposEscuela tiposEscuela = TiposEscuela.PreEscolar, int cantAlumnos = 2000)
        {
            (Nombre, AñoCreación, TipoEscuela, CantAlumnos, EscuelaId) = (nombre, año, tiposEscuela, cantAlumnos, UniqueId);
        }

        public Escuela() => EscuelaId = UniqueId;
        
        public override string ToString()
        {
            return $"Nombre: {Nombre} {System.Environment.NewLine}Año Creación: {AñoCreación} {System.Environment.NewLine}Tipo Escuela: {TipoEscuela} ";
        }

        public void ActualizarReferencia()
        {
            Printer.PrintTitulo("Actualizando Referencia de la Escuela...");

            Printer.PrintTitulo("::::Referencia de la Escuela Actualizada::::");
        }

        public override string PrintExclusive()
        {
            return $"Nombre: {Nombre}, Cantidad Cursos: {lstCursos.Count}";
        }
    }
}