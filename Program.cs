using System.Collections.Generic;
using Etapa1.App;
using Etapa1.Entidades;
using Etapa1.Util;
using ETAPA1.Entidades;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer.PrintTitulo("Implementación de Lista Genérica y ejemplo de delegados con lambda");
            

           var escuelaEng = new EscuelaEngine();
           escuelaEng.Inicializar();
           
            foreach (var item in escuelaEng.Escuela.lstCursos)
            {
                WriteLine(item.ToString());
            }
            
        }
    }
}
