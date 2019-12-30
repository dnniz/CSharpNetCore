namespace CSharpNetCore.Entidades
{
    public interface ILugar
    {
         public string Direccion { get; set; }

         public void ActualizarReferencia();
    }
}