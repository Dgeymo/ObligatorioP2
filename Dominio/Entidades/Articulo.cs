
using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Articulo : IValidable
    {
        public int Id { get; set; }
        private static int _ultimoId;
        public string Nombre { get; set; }
        public Categoria UnaCategoria { get; set; }


        public decimal Precio { get; set; }

        public Articulo(string nombre, Categoria categoria, decimal precio)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            UnaCategoria = categoria;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"Id : {Id}\nNombre : {Nombre.ToUpper()}\nPrecio : {Precio}\nCategorias :\n";
        }

        public void Validar()
        {
            //TODO: falta validar Articulos
        }

        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> _aux = new List<Categoria>();


            return _aux;

        }
    }
}
