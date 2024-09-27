
using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Categoria:IValidable
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Categoria(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
        public override string ToString()
        {
            return $"Categoria: {Nombre.ToUpper()}\nDescripción : {Descripcion}\n";
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new Exception("Nombre de la Categoría, sin datos");
            if (string.IsNullOrEmpty(Descripcion)) throw new Exception("Decripción de la categoria, sin datos");
        }
    }
}
