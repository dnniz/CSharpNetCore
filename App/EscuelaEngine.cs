using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNetCore.Entidades;
using CSharpNetCore.Util;
using static System.Console;

namespace CSharpNetCore.App
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

        private List<Alumno> GenerarAlumnos(int cantidadAlumnos, Curso curso)
        {
            string[] primerNombre = { "Dennis", "Paul", "Franklin", "Juan", "Carlos", "Joaquin" };
            string[] segundoNombre = { "Hanna", "Kuro", "Haru", "Katou", "Genji", "Haki" };
            string[] primerApellido = { "Haruno", "Hamaru", "Yamato", "Tao", "Asakura", "Shinto" };

            var listAlumnos = from pNombre in primerNombre
                              from sNombre in segundoNombre
                              from pApellido in primerApellido
                              select new Alumno { Nombre = $"{pNombre} {sNombre} {pApellido}", CursoId = curso.CursoId };

            return listAlumnos.OrderBy(x => x.UniqueId).Take(cantidadAlumnos).ToList();
        }

        private List<Asignatura> GenerarAsignaturas(Curso curso)
        {
            var lstAsignaturas = new List<Asignatura>()
                {
                new Asignatura(){Nombre ="FUNDAMENTOS FISICOS", CursoId = curso.CursoId },
                new Asignatura(){Nombre ="LOGICA" , CursoId = curso.CursoId },
                new Asignatura(){Nombre ="CALCULO" , CursoId = curso.CursoId }
            };

            return lstAsignaturas;
        }

        private void LoadCursos()
        {
            var curso1 = new Curso()
            {
                Nombre = "BIO",
                EscuelaId = Escuela.UniqueId
            };
            var curso2 = new Curso()
            {
                Nombre = "BOT",
                EscuelaId = Escuela.UniqueId
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
                curso.Alumnos = GenerarAlumnos(cantidadAlumnos, curso);

                //Carga de Asignaturas
                curso.Asignaturas = new List<Asignatura>();
                curso.Asignaturas = GenerarAsignaturas(curso);

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
                                   AlumnoId = alumno.AlumnoId,
                                   Asignatura = asignatura,
                                   AsignaturaId = asignatura.AsignaturaId,
                                   Nota = ObtenerNotaAleatoria(0, 5),
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
                var indice = rnd.Next(0, nombres.Count - 1);
                var item = nombres.ElementAt(indice);
                evaluaciones.Add(item);
                nombres.RemoveAt(indice);
            }

            return evaluaciones;
        }

        private double ObtenerNotaAleatoria(int minNota, int maxNota)
        {
            var rnd = new Random();
            double nota = rnd.Next(minNota, maxNota);
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

        public List<ObjetoEscuelaBase> ListarObjetoBase(
                    bool includeCurso = true,
                    bool includeAsignatura = true,
                    bool includeAlumnos = true,
                    bool includeEvaluaciones = true
                    )
        {
            int dummy = 0;
            return ListarObjetoBase(out dummy, out dummy, out dummy, out dummy, includeCurso, includeAsignatura, includeAlumnos, includeEvaluaciones);
        }
        public List<ObjetoEscuelaBase> ListarObjetoBase(
                    out int cantCursos,
                    out int cantAlumnos,
                    out int cantAsignaturas,
                    out int cantEvaluaciones,
                    bool includeCurso = true,
                    bool includeAsignatura = true,
                    bool includeAlumnos = true,
                    bool includeEvaluaciones = true
                    )
        {
            var lstEscuelaBase = new List<ObjetoEscuelaBase>();
            cantCursos = cantAlumnos = cantAsignaturas = cantEvaluaciones = 0;

            lstEscuelaBase.Add(Escuela);
            lstEscuelaBase.AddRange(Escuela.lstCursos);

            cantCursos = Escuela.lstCursos.Count;

            foreach (var curso in Escuela.lstCursos)
            {
                cantAlumnos += curso.Alumnos.Count;
                cantAsignaturas += curso.Asignaturas.Count;
                cantEvaluaciones += curso.Evaluaciones.Count;

                lstEscuelaBase.AddRange(curso.Alumnos);
                lstEscuelaBase.AddRange(curso.Asignaturas);
                lstEscuelaBase.AddRange(curso.Evaluaciones);
            }

            return lstEscuelaBase;
        }

        public Dictionary<LlaveDiccionario, List<ObjetoEscuelaBase>> ObtenerDiccionarioEscuela()
        {
            var diccionario = new Dictionary<LlaveDiccionario, List<ObjetoEscuelaBase>>();

            diccionario.Add(LlaveDiccionario.Escuela, new List<ObjetoEscuelaBase>() { Escuela });
            diccionario.Add(LlaveDiccionario.Curso, Escuela.lstCursos.Cast<ObjetoEscuelaBase>().ToList());

            var lstAlum = new List<ObjetoEscuelaBase>(); 
            var lstAsig = new List<ObjetoEscuelaBase>(); 
            var lstEval = new List<ObjetoEscuelaBase>(); 
            foreach (var curso in Escuela.lstCursos)
            {
                lstAlum.AddRange(curso.Alumnos);
                lstAsig.AddRange(curso.Asignaturas);
                lstEval.AddRange(curso.Evaluaciones);
            }
            diccionario.Add(LlaveDiccionario.Alumno, lstAlum);
            diccionario.Add(LlaveDiccionario.Asignatura, lstAsig);
            diccionario.Add(LlaveDiccionario.Evaluacion, lstEval);
            
            return diccionario;
        }
        
        public void ImprimirDiccionario<T>(Dictionary<LlaveDiccionario, List<T>> diccionario, LlaveDiccionario llaveNoImprimir) where T : IPrintExclusive
        {
            foreach (var item in diccionario)
            {
                if (item.Key != llaveNoImprimir)
                {
                    Printer.PrintTitulo(item.Key.ToString());
                    foreach (var value in item.Value)
                    {
                        WriteLine(value.PrintExclusive());
                    }
                }
                
            }
        }


    }

}