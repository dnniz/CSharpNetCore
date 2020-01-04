using System.Collections.Generic;
using System.Linq;

namespace CSharpNetCore.Entidades
{
    public class Reporte
    {
        Dictionary<LlaveDiccionario, List<ObjetoEscuelaBase>> _diccionario;
        public Reporte(Dictionary<LlaveDiccionario, List<ObjetoEscuelaBase>> diccionario)
        {
            _diccionario = diccionario;
        }

        public List<Escuela> ListarEscuela()
        {
            var lstEscuela = new List<ObjetoEscuelaBase>();

            if (_diccionario.TryGetValue(LlaveDiccionario.Escuela, out lstEscuela))
                return lstEscuela.Cast<Escuela>().ToList();
            else
                return null;
        }
        public List<Asignatura> ListaAsignaturas()
        {
            return _diccionario.TryGetValue(LlaveDiccionario.Asignatura, out var lstAsignatura)? 
                                lstAsignatura.Cast<Asignatura>()
                                .GroupBy(x => x.Nombre)
                                .Select(x => new Asignatura{ Nombre = x.FirstOrDefault().Nombre})
                                .ToList()
                                : null;
        }
        public List<Evaluacion> ListaEvaluacionesByAsignatura(string asignatura)
        {
            return _diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out var lstEvaluacion )?
                    lstEvaluacion.Cast<Evaluacion>()
                    .Where(x => x.Asignatura.Nombre == asignatura)
                    .ToList()
                    : null;
        }
        public Dictionary<Asignatura, List<Evaluacion>> EvaluacionesPorAsignatura()
        {
            var asignaturas = ListaAsignaturas();
            var diccionario = new Dictionary<Asignatura, List<Evaluacion>>();

            if(asignaturas != null)
                foreach (var asignatura in asignaturas)
                {
                    diccionario.Add(asignatura, ListaEvaluacionesByAsignatura(asignatura.Nombre));
                }

            return diccionario;
        }

        private List<Evaluacion> PromedioEvaluacionPorAsignatura(string asignatura)
        {
            return ListaEvaluacionesByAsignatura(asignatura)
                                            .GroupBy(x => x.Alumno.UniqueId)
                                            .Select(x => new Evaluacion
                                            {
                                                Alumno = x.FirstOrDefault().Alumno,
                                                Promedio = x.Average(x => x.Nota)
                                            })
                                            .ToList();
        }
        public Dictionary<Asignatura, List<Evaluacion>> AsignaturaPromedioPorAlumno(string nombreAsig = null)
        {
            var asignaturas = ListaAsignaturas();
            var diccionario = new Dictionary<Asignatura, List<Evaluacion>>();

            if(nombreAsig != null)
            {
                diccionario.Add(asignaturas.Where(x => x.Nombre == nombreAsig).FirstOrDefault(), PromedioEvaluacionPorAsignatura(nombreAsig));
                return diccionario;
            }
            if(asignaturas != null)
                foreach (var asignatura in asignaturas)
                {
                    List<Evaluacion> promedioPorAlumno = PromedioEvaluacionPorAsignatura(asignatura.Nombre);
                    diccionario.Add(asignatura, promedioPorAlumno);
                }

            return diccionario;
        }
        
        public Dictionary<Asignatura, List<Evaluacion>> PromediosPorAsignatura( int top, string asignatura = null)
        {
            return AsignaturaPromedioPorAlumno(asignatura)
                       .Where(x => asignatura == null || x.Key.Nombre == asignatura )
                       .ToDictionary(x => x.Key, x => x.Value.OrderByDescending(x => x.Promedio).Take(top).ToList() );
            
        }

        
    }
}