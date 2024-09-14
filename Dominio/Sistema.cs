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
        private List<Tipo> _tipos = new List<Tipo>();
           
   
        public void CargarPublicacion(Publicacion publicacion)
        {
            publicacion.Validar();
            _publicaciones.Add(publicacion);
        }
        public Estado BuscarEstado(string estado)
        {
            //todo: no implementado
            return null!;
        }

        public Tipo BuscarTipo(string tipo)
        {
            //todo: no implementado
            return null!;
        }

      
        public Categoria BuscarCategoria(string categoria)
        {
            for (int i = 0; i < _categorias.Count; i++)
            {
                if (_categorias[i].Nombre == categoria) return _categorias[i];
            }
            return null!;
        }
        public void AgregarArticulo(Articulo nuevoArticulo)
        {
            nuevoArticulo.Validar();
            _articulos.Add(nuevoArticulo);
        }
        public void AgregarCategoria(Categoria nuevaCategoria)
        {
            nuevaCategoria.Validar();
            _categorias.Add(nuevaCategoria);
        }
        public List<string> MostrarCategorias()
        {
            List<string> listaCategorias = new List<string>();
            for(int i = 0; i < _categorias.Count; i++)
            {
                listaCategorias.Add($"({i + 1}) " + _categorias[i].ToString());
            }

            return listaCategorias;
        }
        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            nuevoUsuario.Validar();
            if (ExisteUsuario(nuevoUsuario.Email)) throw new Exception("El usuario ya existe");
            _usuarios.Add(nuevoUsuario);
        }
        public Usuario MostrarUsuario(string Nombre)
        {
            bool existe = false;
            int i = 0;
            if (string.IsNullOrEmpty(Nombre)) throw new Exception("No se ha cargado el nombre el parametro");
            while (!existe && i < _usuarios.Count)
            {
                if (string.IsNullOrEmpty(_usuarios[i].Nombre)) throw new Exception("No existe el nombre en el objeto");
                if (_usuarios[i] != null && _usuarios[i].Nombre == Nombre)
                {
                    existe = true;
                    return (Cliente)_usuarios[i];
                }
                i++;
            }
            return null!;
        }
        private bool ExisteUsuario(string email)
        {
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
        public Usuario BuscarUsuario(string email)
        {
            foreach (Usuario unUsuario in _usuarios)
            {
                if (unUsuario.Email == email)
                {
                    return unUsuario;
                }
            }
            return null!;
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
        public void AgregarEstado(Estado estado)
        {
            //todo: no implementado
        }

        public void AgregarTipo(Tipo tipo)
        {
            //todo: no implementado
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
