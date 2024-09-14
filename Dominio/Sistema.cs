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

        //Bloque de busquedas por parametro
        public Estado BuscarEstado(string estado)
        {
            if (estado == null) throw new Exception("Debe elegir un ESTADO de publicacion");
            for (int i = 0; i < _estados.Count; i++)
            {
                Estado unEstado = _estados[i];
                if (unEstado.Nombre.ToUpper() == estado.ToUpper())
                {
                    return unEstado;
                }
            }
            throw new Exception("No se encontro un ESTADO de Publicacion que coincida con los existentes.");
        }
        public Tipo BuscarTipo(string tipo)
        {
            if (tipo == null) throw new Exception("Debe elegir un TIPO de publicacion");
            for (int i = 0; i < _tipos.Count; i++)
            {
                Tipo untipo = _tipos[i];
                if (untipo.Nombre.ToUpper() == tipo.ToUpper())
                {
                    return untipo;
                }
            }
            throw new Exception("No se encontro un TIPO de Publicacion que coincida con las existentes.");
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
        public Categoria BuscarCategoria(string categoria)
        {
            for (int i = 0; i < _categorias.Count; i++)
            {
                if (_categorias[i].Nombre == categoria) return _categorias[i];
            }
            return null!;
        }

        public Articulo BuscarArticulo(int idArticulo)
        {
            for (int i = 0; i < _articulos.Count; i++)
            {
                Articulo unArticulo = _articulos[i];
                if (unArticulo.Id == idArticulo) return unArticulo;
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
            List<string> publicaciones = new List<string>();
            if (tipo.ToUpper() != "TODOS")
            {
                Tipo untipo = BuscarTipo(tipo);
            }
            if (estado.ToUpper() != "TODOS")
            {
                Estado unEstado = BuscarEstado(estado);
            }
            for (int i = 0; i < _publicaciones.Count; i++)
            {
                Publicacion unaPublicacion = _publicaciones[i];
                if (tipo.ToUpper() == "TODOS" || unaPublicacion.Tipo.Nombre == _publicaciones[i].Tipo.Nombre)
                {
                    if (estado.ToUpper() == "TODOS" || unaPublicacion.Estado.Nombre == _publicaciones[i].Estado.Nombre)
                    {
                        publicaciones.Add(unaPublicacion.ToString());
                    }
                }
            }
            return publicaciones;
        }
        //bloque de muestra de listas como objetos
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
        //Bloque de Add en las listas
        public void AgregarArticulo(Articulo nuevoArticulo)
        {
            nuevoArticulo.Validar();
            _articulos.Add(nuevoArticulo);
        }
        public void CargarPublicacion(Publicacion publicacion)
        {
            for (int i = 0; i < publicacion.IdArticulos.Count; i++)
            {
                Articulo unArticulo = BuscarArticulo(publicacion.IdArticulos[i]);
                for (int j = 0; j < _articulos.Count; j++)
                {
                    Articulo elArticulo = BuscarArticulo(j);
                    if (unArticulo != null && unArticulo.Id == elArticulo.Id)
                    {
                        publicacion.AgregarArticulo(elArticulo);
                    }
                }
            }
            publicacion.Validar();
            _publicaciones.Add(publicacion);
        }
        public void AgregarCategoria(Categoria nuevaCategoria)
        {
            nuevaCategoria.Validar();
            _categorias.Add(nuevaCategoria);
        }
        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            nuevoUsuario.Validar();
            if (ExisteUsuario(nuevoUsuario.Email)) throw new Exception("El usuario ya existe");
            _usuarios.Add(nuevoUsuario);
        }
        public void AgregarEstado(Estado estado)
        {
            estado.Validar();
            if (ExisteEstado(estado.Nombre)) throw new Exception("El estado ya existe");
            _estados.Add(estado);
        }

        public void AgregarTipo(Tipo tipo)
        {
            tipo.Validar();
            if (ExisteTipo(tipo.Nombre)) throw new Exception("El tipo ya existe");
            _tipos.Add(tipo);
        }
        //Comparadores para repetidos
        private bool ExisteTipo(string tipo)
        {
            bool repetido = false;
            for (int i = 0; i < _tipos.Count; i++)
            {
                Tipo unTipo = _tipos[i];
                if (unTipo.Nombre.ToUpper() == tipo.ToUpper()) repetido = true;
            }
            return repetido;
        }
        private bool ExisteEstado(string estado)
        {
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
