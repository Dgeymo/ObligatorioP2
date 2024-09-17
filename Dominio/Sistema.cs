using Dominio.Entidades;
namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Categoria> _categorias = new List<Categoria>();
        private List<Estado> _estados = new List<Estado>();
        //  private List<Tipo> _tipos = new List<Tipo>();

        //Bloque de busquedas por parametro
        public Estado BuscarEstado(string estado)
        {
            if (String.IsNullOrEmpty(estado)) throw new Exception("Debe elegir un ESTADO de publicacion");
            foreach (Estado unEstado in _estados)
            {
                if (unEstado.Nombre.ToUpper() == estado.ToUpper()) return unEstado;
            }
            return null!;
        }
        public Usuario BuscarUsuario(string email)
        {
            if (String.IsNullOrEmpty(email)) throw new Exception("No se ha cargado el email en el parametro");
            foreach (Usuario unUsuario in _usuarios)
            {
                if (unUsuario.Email == email)
                {
                    return unUsuario;
                }
            }
            return null!;
        }
        public Categoria BuscarCategoria(string categoria)
        {
            if (String.IsNullOrEmpty(categoria)) throw new Exception("No se ha cargado la categoria en el parametro");
            foreach (Categoria unaCategoria in _categorias)
            {
                if (unaCategoria.Nombre == categoria) return unaCategoria;
            }
            return null!;
        }
        public Articulo BuscarArticulo(int idArticulo)
        {
            if (!int.TryParse(idArticulo.ToString(), out _)) throw new Exception("No se ha pasado un número");
            foreach (Articulo unArticulo in _articulos)
            {
                if (unArticulo.Id == idArticulo) return unArticulo;
            }
            return null!;
        }
        public Subasta BuscarPublicacionSubasta(int idPublicacion)
        {
            if (!int.TryParse(idPublicacion.ToString(), out _)) throw new Exception("ingrese un id valido de publicacion");
            foreach (Publicacion unaPublicacion in _publicaciones)
            {
                if (unaPublicacion.Id == idPublicacion)
                {
                    if (unaPublicacion is not Subasta) throw new Exception("El id ingresado no es una subasta");
                    return (Subasta)unaPublicacion;
                }
            }
            return null!;
        }

        //Bloque de muestra de listas como strings
        public List<string> MostrarCategorias()
        {
            List<string> listaCategorias = new List<string>();
            for (int i = 0; i < _categorias.Count; i++)
            {
                listaCategorias.Add($"({i + 1}) " + _categorias[i].ToString());
            }

            return listaCategorias;
        }
        public List<string> ListaPublicaciones(string tipo, string estado)
        {
            if (string.IsNullOrEmpty(estado)) throw new Exception("No se ha cargado el estado en el parametro");
            if (string.IsNullOrEmpty(tipo)) throw new Exception("No se ha cargado el tipo en el parametro");
            List<string> publicaciones = new List<string>();

            foreach (Publicacion unaPublicacion in _publicaciones) //.nombre == tipo.ToUpper())
            {
                if (tipo.ToUpper() == "TODOS")
                {
                    if (estado.ToUpper() == unaPublicacion.Estado.Nombre.ToUpper())
                    {
                        publicaciones.Add(unaPublicacion.ToString());
                    }
                    else if (estado.ToUpper() == "TODOS")
                    {
                        publicaciones.Add(unaPublicacion.ToString());
                    }
                }
                else if (tipo.ToUpper() == "VENTA" && unaPublicacion is Venta)
                {
                    if (estado.ToUpper() == unaPublicacion.Estado.Nombre.ToUpper())
                    {
                        publicaciones.Add(unaPublicacion.ToString());
                    }
                    else if (estado.ToUpper() == "TODOS")
                    {
                        publicaciones.Add(unaPublicacion.ToString());
                    }
                }
                else if (tipo.ToUpper() == "SUBASTA" && unaPublicacion is Subasta)
                {
                    if (estado.ToUpper() == unaPublicacion.Estado.Nombre.ToUpper())
                    {
                        publicaciones.Add(unaPublicacion.ToString());
                    }
                    else if (estado.ToUpper() == "TODOS")
                    {
                        publicaciones.Add(unaPublicacion.ToString());
                    }
                }
            }
            return publicaciones;
        }
        //bloque de muestra de objetos
        public Usuario MostrarUsuario(string nombre)
        {
            bool existe = false;
            int i = 0;
            if (string.IsNullOrEmpty(nombre)) throw new Exception("No se ha cargado el nombre en el parametro");
            while (!existe && i < _usuarios.Count)
            {
                if (string.IsNullOrEmpty(_usuarios[i].Nombre)) throw new Exception("No existe el nombre en el objeto");
                if (_usuarios[i] != null && _usuarios[i].Nombre == nombre)
                {
                    existe = true;
                    return (Cliente)_usuarios[i];
                }
                i++;
            }
            return null!;
        }
        //Bloque de Add en las listas
        public void AgregarArticulo(Articulo nuevoArticulo)
        {
            if (nuevoArticulo == null) throw new Exception("Valor nulo en el parametro de agregar artículo");
            nuevoArticulo.Validar();
            _articulos.Add(nuevoArticulo);
        }
        public void AgregarPublicacion(Publicacion nuevaPublicacion)
        {
            if (nuevaPublicacion == null) throw new Exception("Valor nulo en el parametro publicacion");
            nuevaPublicacion.Validar();
            _publicaciones.Add(nuevaPublicacion);
        }
        public void AgregarCategoria(Categoria nuevaCategoria)
        {
            if (nuevaCategoria == null) throw new Exception("Valor nulo en el parametro de agregar categoría");
            nuevaCategoria.Validar();
            _categorias.Add(nuevaCategoria);
        }
        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            if (nuevoUsuario == null) throw new Exception("Valor nulo en el parametro de agregar usuario");
            nuevoUsuario.Validar();
            if (ExisteUsuario(nuevoUsuario.Email)) throw new Exception("El usuario ya existe");
            _usuarios.Add(nuevoUsuario);
        }
        public void AgregarEstado(Estado estado)
        {
            if (estado == null) throw new Exception("Valor nulo en el parametro de agregar estado");
            estado.Validar();
            if (ExisteEstado(estado.Nombre)) throw new Exception("El estado ya existe");
            _estados.Add(estado);
        }
        private bool ExisteEstado(string estado)
        {
            if (estado == null) throw new Exception("Valor nulo en el parametro de agregar estado");
            bool repetido = false;
            for (int i = 0; i < _estados.Count; i++)
            {
                Estado unEstado = _estados[i];
                if (unEstado.Nombre.ToUpper() == estado.ToUpper()) repetido = true;
            }
            return repetido;
        }
        private bool ExisteUsuario(string email)
        {
            if (String.IsNullOrEmpty(email)) throw new Exception("Valor nulo en el parametro email");
            bool esRepetido = false;
            int incremental = 0;
            while (!esRepetido && incremental < _usuarios.Count)
            {
                if (_usuarios[incremental].Email.Equals(email))
                {
                    esRepetido = true;
                }
                incremental++;
            }
            return esRepetido;
        }
        /// <summary>
        /// ESTE METODO NO VA A INCLUIRSE EN EL PROYECTO FINAL. ES A MODO DE VER LOS REGISTROS DE CATEGORIA Y ARTICULOS INGRESADOS
        /// </summary>
        public void MostrarPrecargas()
        {
            for (int i = 0; i < _categorias.Count; i++)
            {
                Console.WriteLine(_categorias[i]);
            }
            for (int i = 0; i < _articulos.Count; i++)
            {
                Console.WriteLine(_articulos[i]);
            }
            for (int i = 0; i < _usuarios.Count; i++)
            {
                Console.WriteLine(_usuarios[i]);
            }
            for (int i = 0; i < _estados.Count; i++)
            {
                Console.WriteLine(_estados[i]);
            }
        }



        //public object Obtener(List<object> lista, Categoria parametro, Categoria valor)
        //{
        //    //if (valor == null || lista == null) throw new ArgumentException("Parámetros inválidos"));

        //    //foreach (var obj in lista)
        //    //{
        //    //    if (obj != null && obj.GetType().GetProperty(parametro) != null &&
        //    //        obj.GetType().GetProperty(parametro).GetValue(obj) == valor)
        //    //    {
        //    //        return obj;
        //    //    }
        //    //}
        //    return null;
        //}
    }
}
