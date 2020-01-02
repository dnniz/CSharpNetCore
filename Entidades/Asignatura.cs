namespace CSharpNetCore.Entidades
{
    public class Asignatura : ObjetoEscuelaBase
    {
        public override string PrintExclusive()
        {
            return $"Nombre: {Nombre.ToUpper()}";
        }
    }
}