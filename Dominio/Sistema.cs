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

        public void Precargas()
        {
            PrecargaUsuarios();           
            PrecargaCategoria();
            PrecargaArticulo();           
            PrecargaEstado();
            PrecargaTipo();
            PrecargaPublicaciones();
        }

        private void PrecargaPublicaciones()
        {
           CargarPublicacion(new Publicacion("Verano en la Playa",BuscarEstado("ABIERTA"),DateTime.Now,BuscarUsuario("dgeymonat84@gmail.com"),BuscarTipo("VENTA"),false)
        }
        private void CargarPublicacion(Publicacion publicacion)
        {
            publicacion.Validar();
            _publicaciones.Add(publicacion);
        }
        private Estado BuscarEstado(string v)
        {
            throw new NotImplementedException();
        }

        private Tipo BuscarTipo(string v)
        {
            throw new NotImplementedException();
        }

        private void PrecargaUsuarios()
        {
            AgregarUsuario(new Cliente("Diego", "Geymonat", "dgeymonat84@gmail.com", "Geymon4t", 135000));
            AgregarUsuario(new Cliente("Ernaldo", "Rodriguez", "ernaldo.rodriguez.dev@gmail.com", "1234", 150000));
            AgregarUsuario(new Administrador("Diego", "Geymonat", "dgeymonat85@gmail.com", "Geymon4t"));
            AgregarUsuario(new Administrador("Ernaldo", "Rodriguez", "ernaldo.rodriguez.dev1@gmail.com", "1234"));
        }
        public void PrecargaCategoria()
        {
            AgregarCategoria(new Categoria("Deportes", "Todo lo necesario para el deporte"));
            AgregarCategoria(new Categoria("Indumentaria", "Distintas prendas para distintas ocasiones"));
            AgregarCategoria(new Categoria("Salud", "Todo para el cuidado"));
            AgregarCategoria(new Categoria("Tecnología", "Celulares, computadoras, consolas y más..."));
            AgregarCategoria(new Categoria("Niños", "Todo para los peques"));
            AgregarCategoria(new Categoria("Hogar", "Accesorio para el hogar"));
            AgregarCategoria(new Categoria("Entretenimiento", "Para tu tiempo libre"));
            AgregarCategoria(new Categoria("Educación", "Para crecer y aprender"));
        }
        public void PrecargaArticulo()
        {
            AgregarArticulo(new Articulo("Zapatillas de correr", new List<Categoria> { BuscarCategoria("Deportes"), BuscarCategoria("Indumentaria") }, 80));
            AgregarArticulo(new Articulo("Camiseta de fútbol", new List<Categoria> { BuscarCategoria("Deportes"), BuscarCategoria("Indumentaria") }, 25));
            AgregarArticulo(new Articulo("Suplemento de creatina", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Tecnología") }, 40));
            AgregarArticulo(new Articulo("Smartphone", new List<Categoria> { BuscarCategoria("Tecnología"), BuscarCategoria("Entretenimiento") }, 600));
            AgregarArticulo(new Articulo("Sofá", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Entretenimiento") }, 300));
            AgregarArticulo(new Articulo("Libro de programación", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 30));
            AgregarArticulo(new Articulo("Juguetes educativos", new List<Categoria> { BuscarCategoria("Niños"), BuscarCategoria("Educación") }, 20));
            AgregarArticulo(new Articulo("Cera para duchas", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Hogar") }, 15));
            AgregarArticulo(new Articulo("Consola de videojuegos", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 400));
            AgregarArticulo(new Articulo("Ropa interior", new List<Categoria> { BuscarCategoria("Indumentaria"), BuscarCategoria("Salud") }, 18));
            AgregarArticulo(new Articulo("Tablet", new List<Categoria> { BuscarCategoria("Tecnología"), BuscarCategoria("Entretenimiento") }, 350));
            AgregarArticulo(new Articulo("Lavadora", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Tecnología") }, 250));
            AgregarArticulo(new Articulo("Película de acción", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 15));
            AgregarArticulo(new Articulo("Bicicleta eléctrica", new List<Categoria> { BuscarCategoria("Deportes"), BuscarCategoria("Tecnología") }, 800));
            AgregarArticulo(new Articulo("Perfume femenino", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Indumentaria") }, 60));
            AgregarArticulo(new Articulo("Refrigerador", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Tecnología") }, 450));
            AgregarArticulo(new Articulo("Videojuego de estrategia", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 45));
            AgregarArticulo(new Articulo("Pantalones de trabajo", new List<Categoria> { BuscarCategoria("Indumentaria"), BuscarCategoria("Deportes") }, 35));
            AgregarArticulo(new Articulo("Smartwatch", new List<Categoria> { BuscarCategoria("Tecnología"), BuscarCategoria("Salud") }, 200));
            AgregarArticulo(new Articulo("Televisor", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Entretenimiento") }, 500));
            AgregarArticulo(new Articulo("Gorra de béisbol", new List<Categoria> { BuscarCategoria("Indumentaria"), BuscarCategoria("Deportes") }, 22));
            AgregarArticulo(new Articulo("Acondicionador para cabello", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Indumentaria") }, 12));
            AgregarArticulo(new Articulo("Consola virtual", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 100));
            AgregarArticulo(new Articulo("Tenis", new List<Categoria> { BuscarCategoria("Deportes"), BuscarCategoria("Indumentaria") }, 70));
            AgregarArticulo(new Articulo("Kit de programación", new List<Categoria> { BuscarCategoria("Tecnología"), BuscarCategoria("Entretenimiento") }, 120));
            AgregarArticulo(new Articulo("Cama elástica", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Salud") }, 180));
            AgregarArticulo(new Articulo("Jugador de golf", new List<Categoria> { BuscarCategoria("Deportes"), BuscarCategoria("Indumentaria") }, 90));
            AgregarArticulo(new Articulo("Cera para pestañas", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Indumentaria") }, 10));
            AgregarArticulo(new Articulo("Computadora portátil", new List<Categoria> { BuscarCategoria("Tecnología"), BuscarCategoria("Entretenimiento") }, 700));
            AgregarArticulo(new Articulo("Microondas", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Tecnología") }, 150));
            AgregarArticulo(new Articulo("Libro de historia", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Educación") }, 28));
            AgregarArticulo(new Articulo("Juguetes educativos", new List<Categoria> { BuscarCategoria("Niños"), BuscarCategoria("Educación") }, 25));
            AgregarArticulo(new Articulo("Desodorante", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Indumentaria") }, 15));
            AgregarArticulo(new Articulo("Consola de juegos", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 300));
            AgregarArticulo(new Articulo("Ropa de baño", new List<Categoria> { BuscarCategoria("Indumentaria"), BuscarCategoria("Salud") }, 30));
            AgregarArticulo(new Articulo("Tableta grasa corporal", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Tecnología") }, 50));
            AgregarArticulo(new Articulo("Aspiradora", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Tecnología") }, 200));
            AgregarArticulo(new Articulo("Película de animación", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 15));
            AgregarArticulo(new Articulo("Bicicleta de montaña", new List<Categoria> { BuscarCategoria("Deportes"), BuscarCategoria("Tecnología") }, 750));
            AgregarArticulo(new Articulo("Perfume masculino", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Indumentaria") }, 65));
            AgregarArticulo(new Articulo("Refrigerador compacto", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Tecnología") }, 350));
            AgregarArticulo(new Articulo("Videojuego de simulación", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 55));
            AgregarArticulo(new Articulo("Pantalones de yoga", new List<Categoria> { BuscarCategoria("Indumentaria"), BuscarCategoria("Deportes") }, 40));
            AgregarArticulo(new Articulo("Smartwatch fitness", new List<Categoria> { BuscarCategoria("Tecnología"), BuscarCategoria("Salud") }, 220));
            AgregarArticulo(new Articulo("Televisor inteligente", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Entretenimiento") }, 650));
            AgregarArticulo(new Articulo("Gorra de beisbol", new List<Categoria> { BuscarCategoria("Indumentaria"), BuscarCategoria("Deportes") }, 25));
            AgregarArticulo(new Articulo("Acondicionador para cabello", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Indumentaria") }, 15));
            AgregarArticulo(new Articulo("Consola virtual", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 100));
            AgregarArticulo(new Articulo("Tenis", new List<Categoria> { BuscarCategoria("Deportes"), BuscarCategoria("Indumentaria") }, 70));
            AgregarArticulo(new Articulo("Kit de programación", new List<Categoria> { BuscarCategoria("Tecnología"), BuscarCategoria("Entretenimiento") }, 120));
        }
        public void PrecargaEstado()
        {
            _estados.Add(new Estado("ABIERTA"));
            _estados.Add(new Estado("CERRADA"));
            _estados.Add(new Estado("CANCELADA"));
        }
        public void PrecargaTipo()
        {
            _tipos.Add(new Tipo("VENTA"));
            _tipos.Add(new Tipo("SUBASTA"));
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
        private Usuario BuscarUsuario(string email)
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
