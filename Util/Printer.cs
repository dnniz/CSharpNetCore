using static System.Console;

namespace CSharpNetCore.Util
{
    public static class Printer
    {
        public static void PrintLinea(int length = 10)
        {
            WriteLine(string.Empty.PadLeft(length, '='));
        }

        public static void PrintTitulo(string titulo)
        {
            WriteLine(string.Format("{0}{1}{0}", string.Empty.PadLeft(10, '='), titulo));
        }
        
    }
}