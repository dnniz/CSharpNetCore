using System;
using System.Collections.Generic;
using System.Linq;
using Etapa1.Entidades;
using ETAPA1.Entidades;

namespace Etapa1.App
{
    public sealed class EscuelaEngine
    {
        public EscuelaEngine(Escuela escuela)
        {
            this.Escuela = escuela;

        }
        public Escuela Escuela { get; set; }
        public EscuelaEngine()
        {
            Escuela = new Escuela("Tokio Room", 2019, tiposEscuela: TiposEscuela.Secundaria);

        }

        public void Inicializar()
        {
            LoadCursos();
        }

        private List<Alumno> GenerarAlumnos(int cantidadAlumnos)
        {
            string[] primerNombre = { "Dennis", "Paul", "Franklin", "Juan", "Carlos", "Joaquin" };
            string[] segundoNombre = { "Hanna", "Kuro", "Haru", "Katou", "Genji", "Haki" };
            string[] primerApellido = { "Haruno", "Hamaru", "Yamato", "Tao", "Asakura", "Shinto" };

            var listAlumnos = from pNombre in primerNombre
                              from sNombre in segundoNombre
                              from pApellido in primerApellido
                              select new Alumno { Nombre = $"{pNombre} {sNombre} {pApellido}" };

            return listAlumnos.OrderBy(x => x.UniqueId).Take(cantidadAlumnos).ToList();
        }

        private List<Asignatura> GenerarAsignaturas()
        {
            var lstAsignaturas = new List<Asignatura>()
                {
                new Asignatura(){Nombre ="FUNDAMENTOS FISICOS" },
                new Asignatura(){Nombre ="LOGICA" },
                new Asignatura(){Nombre ="CALCULO" }
            };

            return lstAsignaturas;
        }

        private void LoadCursos()
        {
            var curso1 = new Curso()
            {
                Nombre = "BIO"
            };
            var curso2 = new Curso()
            {
                Nombre = "BOT"
            };
            Escuela.lstCursos = new List<Curso>();
            Escuela.lstCursos.Add(curso1);
            Escuela.lstCursos.Add(curso2);

            Random rnd = new Random();
            foreach (var curso in Escuela.lstCursos)
            {

                int cantidadAlumnos = rnd.Next(5, 15);

                //Carga de Alumnos
                curso.Alumnos = new List<Alumno>();
                curso.Alumnos = GenerarAlumnos(cantidadAlumnos);

                //Carga de Asignaturas
                curso.Asignaturas = new List<Asignatura>();
                curso.Asignaturas = GenerarAsignaturas();

                curso.Evaluaciones = GenerarEvaluaciones(curso.Alumnos, curso.Asignaturas);
            }
        }

        private List<Evaluacion> GenerarEvaluaciones(List<Alumno> alumnos, List<Asignatura> asignaturas)
        {
            
            var nombresEvaluaciones = ObtenerNombresEvaluaciones();
            var evaluaciones = from alumno in alumnos
                               from asignatura in asignaturas
                               from nombEvaluacion in nombresEvaluaciones
                               select new Evaluacion()
                               {
                                   Alumno = alumno,
                                   Asignatura = asignatura,
                                   Nota = ObtenerNotaAleatoria(0,5),
                                   Nombre = nombEvaluacion
                               };
            foreach (var alumno in alumnos)
            {
                alumno.Evaluaciones = new List<Evaluacion>();
                alumno.Evaluaciones = evaluaciones.Where(x => x.Alumno.UniqueId == alumno.UniqueId).ToList();
            }

            return evaluaciones.ToList();
        }

        private List<string> ObtenerNombresEvaluaciones()
        {
            var nombres = new List<string>() 
            {
                "evaluación final","microproyecto","evaluación final",
                "criterios de la evaluación","evaluación durante toda la ejecución",
                "evaluaciones del desarrollo","trabajo en equipo", "criterios cualitativos", 
                "criterios cuantitativos", "participación"
            };
            
            var rnd = new Random();
            var evaluaciones = new List<string>();

            for (int i = 1; i <= 5; i++)
            {
                var indice = rnd.Next(0,nombres.Count -1);
                var item = nombres.ElementAt(indice);
                evaluaciones.Add(item);
                nombres.RemoveAt(indice);
            }

            return evaluaciones;
        }

        private double ObtenerNotaAleatoria(int minNota,int maxNota)
        {
            var rnd = new Random();
            double nota = rnd.Next(minNota,maxNota);
            if (nota != maxNota)
            {
                nota += rnd.NextDouble(); 
                if (nota > maxNota)
                {
                    nota = maxNota;
                }
            }
            return nota;
        }
        
    }
}