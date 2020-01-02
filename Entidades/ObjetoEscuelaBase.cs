using System;

namespace CSharpNetCore.Entidades
{
    public abstract class ObjetoEscuelaBase : IPrintExclusive
    {
        public string UniqueId { get; set; }
        public string Nombre { get; set; }
        public ObjetoEscuelaBase() => UniqueId = Guid.NewGuid().ToString();

        public override string ToString()
        {
            return $"{Nombre}";
        }

        public  abstract string PrintExclusive();
    }
    
}