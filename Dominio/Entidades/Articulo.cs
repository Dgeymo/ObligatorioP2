
namespace Dominio.Entidades
{
    public class Articulo
    {
        public int Id { get; set; }
        private static int _ultimoId;
        public string Nombre { get; set; }
        private List<Categoria> _categorias;
        public decimal Precio { get; set; }

        public Articulo(string nombre, List<Categoria> categoria, decimal precio)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            _categorias = categoria;
            Precio = precio;
        }

        public List<Categoria> ObtenerCategorias()
        {
            return _categorias;
        }

        public override string ToString()
        {
            string mensaje = string.Empty;
            mensaje += $"Id : {Id}\nNombre : {Nombre.ToUpper()}\nPrecio : {Precio}\nCategorias : ";
            for (int i = 0; i < _categorias.Count; i++)
            {
                if (_categorias[i] != null)
                {
                    if (i < _categorias.Count - 1)
                    {
                        mensaje += _categorias[i].Nombre + ", ";
                    }
                    else
                    {
                        mensaje += _categorias[i].Nombre;
                    }
                }
            }
            mensaje += "\n";
            return mensaje;
        }

        internal void Validar()
        {
            //TODO: falta validar Articulos
        }
    }
}
