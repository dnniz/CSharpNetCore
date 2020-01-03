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
        public Dictionary<Asignatura, List<Evaluacion>> EvaluacionesPorAsignatura()
        {
            var asignaturas = ListaAsignaturas();
            //var result = _diccionario.Where(x => x.)

            return null;
        }
    }
}