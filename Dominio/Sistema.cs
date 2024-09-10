using Dominio.Entidades;
namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Categoria> _categorias = new List<Categoria>();
        public object Obtener(List<object> lista, Categoria parametro, Categoria valor)
        {
            //if (valor == null || lista == null) throw new ArgumentException("Parámetros inválidos"));

            //foreach (var obj in lista)
            //{
            //    if (obj != null && obj.GetType().GetProperty(parametro) != null &&
            //        obj.GetType().GetProperty(parametro).GetValue(obj) == valor)
            //    {
            //        return obj;
            //    }
            //}
            return null;
        }
        public void Precargas()
        {
            PrecargaCategoria();
            PrecargaArticulo();
            PrecargaUsuarios();
        }
        private void PrecargaUsuarios()
        {
            AgregarUsuario(new Cliente("Diego", "Geymonat", "dgeymonat84@gmail.com", "Geymon4t", 135000));
            AgregarUsuario(new Cliente("Ernaldo", "Rodriguez", "ernaldo.rodriguez.dev@gmail.com", "1234", 150000));
        }
        public void PrecargaCategoria()
        {
            _categorias.Add(new Categoria("Deportes", "Todo lo necesario para el deporte"));
            _categorias.Add(new Categoria("Indumentaria", "Distintas prendas para distintas ocasiones"));
            _categorias.Add(new Categoria("Salud", "Todo para el cuidado"));
            _categorias.Add(new Categoria("Tecnología", "Celulares, computadoras, consolas y más..."));
            _categorias.Add(new Categoria("Niños", "Todo para los peques"));
            _categorias.Add(new Categoria("Hogar", "Accesorio para el hogar"));
            _categorias.Add(new Categoria("Entretenimiento", "Para tu tiempo libre"));
            _categorias.Add(new Categoria("Educación", "Para crecer y aprender"));
        }
        public Categoria BuscarCategoria(string categoria)
        {
            for (int i = 0; i < _categorias.Count; i++)
            {
                if (_categorias[i].Nombre == categoria) return _categorias[i];
            }
            return null;
        }
        public void PrecargaArticulo()
        {
            _articulos.Add(new Articulo("Zapatillas de correr", new List<Categoria> { BuscarCategoria("Deportes"), BuscarCategoria("Indumentaria") }, 80));
            _articulos.Add(new Articulo("Camiseta de fútbol", new List<Categoria> { BuscarCategoria("Deportes"), BuscarCategoria("Indumentaria") }, 25));
            _articulos.Add(new Articulo("Suplemento de creatina", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Tecnología") }, 40));
            _articulos.Add(new Articulo("Smartphone", new List<Categoria> { BuscarCategoria("Tecnología"), BuscarCategoria("Entretenimiento") }, 600));
            _articulos.Add(new Articulo("Sofá", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Entretenimiento") }, 300));
            _articulos.Add(new Articulo("Libro de programación", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 30));
            _articulos.Add(new Articulo("Juguetes educativos", new List<Categoria> { BuscarCategoria("Niños"), BuscarCategoria("Educación") }, 20));
            _articulos.Add(new Articulo("Cera para duchas", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Hogar") }, 15));
            _articulos.Add(new Articulo("Consola de videojuegos", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 400));
            _articulos.Add(new Articulo("Ropa interior", new List<Categoria> { BuscarCategoria("Indumentaria"), BuscarCategoria("Salud") }, 18));
            _articulos.Add(new Articulo("Tablet", new List<Categoria> { BuscarCategoria("Tecnología"), BuscarCategoria("Entretenimiento") }, 350));
            _articulos.Add(new Articulo("Lavadora", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Tecnología") }, 250));
            _articulos.Add(new Articulo("Película de acción", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 15));
            _articulos.Add(new Articulo("Bicicleta eléctrica", new List<Categoria> { BuscarCategoria("Deportes"), BuscarCategoria("Tecnología") }, 800));
            _articulos.Add(new Articulo("Perfume femenino", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Indumentaria") }, 60));
            _articulos.Add(new Articulo("Refrigerador", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Tecnología") }, 450));
            _articulos.Add(new Articulo("Videojuego de estrategia", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 45));
            _articulos.Add(new Articulo("Pantalones de trabajo", new List<Categoria> { BuscarCategoria("Indumentaria"), BuscarCategoria("Deportes") }, 35));
            _articulos.Add(new Articulo("Smartwatch", new List<Categoria> { BuscarCategoria("Tecnología"), BuscarCategoria("Salud") }, 200));
            _articulos.Add(new Articulo("Televisor", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Entretenimiento") }, 500));
            _articulos.Add(new Articulo("Gorra de béisbol", new List<Categoria> { BuscarCategoria("Indumentaria"), BuscarCategoria("Deportes") }, 22));
            _articulos.Add(new Articulo("Acondicionador para cabello", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Indumentaria") }, 12));
            _articulos.Add(new Articulo("Consola virtual", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 100));
            _articulos.Add(new Articulo("Tenis", new List<Categoria> { BuscarCategoria("Deportes"), BuscarCategoria("Indumentaria") }, 70));
            _articulos.Add(new Articulo("Kit de programación", new List<Categoria> { BuscarCategoria("Tecnología"), BuscarCategoria("Entretenimiento") }, 120));
            _articulos.Add(new Articulo("Cama elástica", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Salud") }, 180));
            _articulos.Add(new Articulo("Jugador de golf", new List<Categoria> { BuscarCategoria("Deportes"), BuscarCategoria("Indumentaria") }, 90));
            _articulos.Add(new Articulo("Cera para pestañas", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Indumentaria") }, 10));
            _articulos.Add(new Articulo("Computadora portátil", new List<Categoria> { BuscarCategoria("Tecnología"), BuscarCategoria("Entretenimiento") }, 700));
            _articulos.Add(new Articulo("Microondas", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Tecnología") }, 150));
            _articulos.Add(new Articulo("Libro de historia", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Educación") }, 28));
            _articulos.Add(new Articulo("Juguetes educativos", new List<Categoria> { BuscarCategoria("Niños"), BuscarCategoria("Educación") }, 25));
            _articulos.Add(new Articulo("Desodorante", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Indumentaria") }, 15));
            _articulos.Add(new Articulo("Consola de juegos", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 300));
            _articulos.Add(new Articulo("Ropa de baño", new List<Categoria> { BuscarCategoria("Indumentaria"), BuscarCategoria("Salud") }, 30));
            _articulos.Add(new Articulo("Tableta grasa corporal", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Tecnología") }, 50));
            _articulos.Add(new Articulo("Aspiradora", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Tecnología") }, 200));
            _articulos.Add(new Articulo("Película de animación", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 15));
            _articulos.Add(new Articulo("Bicicleta de montaña", new List<Categoria> { BuscarCategoria("Deportes"), BuscarCategoria("Tecnología") }, 750));
            _articulos.Add(new Articulo("Perfume masculino", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Indumentaria") }, 65));
            _articulos.Add(new Articulo("Refrigerador compacto", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Tecnología") }, 350));
            _articulos.Add(new Articulo("Videojuego de simulación", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 55));
            _articulos.Add(new Articulo("Pantalones de yoga", new List<Categoria> { BuscarCategoria("Indumentaria"), BuscarCategoria("Deportes") }, 40));
            _articulos.Add(new Articulo("Smartwatch fitness", new List<Categoria> { BuscarCategoria("Tecnología"), BuscarCategoria("Salud") }, 220));
            _articulos.Add(new Articulo("Televisor inteligente", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Entretenimiento") }, 650));
            _articulos.Add(new Articulo("Gorra de beisbol", new List<Categoria> { BuscarCategoria("Indumentaria"), BuscarCategoria("Deportes") }, 25));
            _articulos.Add(new Articulo("Acondicionador para cabello", new List<Categoria> { BuscarCategoria("Salud"), BuscarCategoria("Indumentaria") }, 15));
            _articulos.Add(new Articulo("Consola virtual", new List<Categoria> { BuscarCategoria("Entretenimiento"), BuscarCategoria("Tecnología") }, 100));
            _articulos.Add(new Articulo("Tenis", new List<Categoria> { BuscarCategoria("Deportes"), BuscarCategoria("Indumentaria") }, 70));
            _articulos.Add(new Articulo("Kit de programación", new List<Categoria> { BuscarCategoria("Tecnología"), BuscarCategoria("Entretenimiento") }, 120));
            //_articulos.Add(new Articulo("Cama elástica", new List<Categoria> { BuscarCategoria("Hogar"), BuscarCategoria("Salud") }, 180));
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
        }
        public void AgregarUsuario(Cliente nuevoUsuario)
        {
            nuevoUsuario.Validar();
            if (ExisteUsuario(nuevoUsuario.Email)) throw new Exception("El usuario ya existe");
            _usuarios.Add(nuevoUsuario);
        }
        public void AgregarUsuario(Administrador nuevoUsuario)
        {
            try
            {
                nuevoUsuario.Validar();
            }
            catch (Exception)
            {
                throw;
            }
            if (ExisteUsuario(nuevoUsuario.Email))
            {
                throw new Exception("El usuario ya existe");
            }
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
            return null;

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
    }
}
