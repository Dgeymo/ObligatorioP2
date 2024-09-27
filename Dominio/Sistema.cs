using Dominio.Entidades;
namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Categoria> _categorias = new List<Categoria>();

        #region "PRE CARGAS DEL SISTEMA"
        public void PreCargas()
        {
            PrecargaUsuarios();
            PrecargaCategoria();
            PrecargaArticulo();
            PrecargaPublicaciones();
            PreCargaOfertas();
        }
        private void PrecargaUsuarios()
        {
            AgregarUsuario(new Cliente("Diego", "Geymonat", "dgeymonat84@gmail.com", "Geymon4t", 135000));
            AgregarUsuario(new Cliente("Ernaldo", "Rodriguez", "ernaldo.rodriguez.dev@gmail.com", "1234", 150000));
            AgregarUsuario(new Administrador("Diego", "Geymonat", "dgeymonat85@gmail.com", "Geymon4t"));
            AgregarUsuario(new Administrador("Ernaldo", "Rodriguez", "ernaldo.rodriguez.dev1@gmail.com", "1234"));
        }
        private void PrecargaCategoria()
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
        private void PrecargaArticulo()
        {
            AgregarArticulo(new Articulo("Zapatillas de correr", BuscarCategoria("Indumentaria"), 80));
            AgregarArticulo(new Articulo("Camiseta de fútbol", BuscarCategoria("Indumentaria"), 25));
            AgregarArticulo(new Articulo("Suplemento de creatina", BuscarCategoria("Salud"), 40));
            AgregarArticulo(new Articulo("Smartphone", BuscarCategoria("Tecnología"), 600));
            AgregarArticulo(new Articulo("Sofá", BuscarCategoria("Hogar"), 300));
            AgregarArticulo(new Articulo("Libro de programación", BuscarCategoria("Educación"), 30));
            AgregarArticulo(new Articulo("Abaco infantil", BuscarCategoria("Educación"), 20));
            AgregarArticulo(new Articulo("Cera para duchas", BuscarCategoria("Salud"), 15));
            AgregarArticulo(new Articulo("Consola de videojuegos", BuscarCategoria("Entretenimiento"), 400));
            AgregarArticulo(new Articulo("Ropa interior", BuscarCategoria("Indumentaria"), 18));
            AgregarArticulo(new Articulo("Tablet", BuscarCategoria("Entretenimiento"), 350));
            AgregarArticulo(new Articulo("Lavadora", BuscarCategoria("Hogar"), 250));
            AgregarArticulo(new Articulo("Película de acción", BuscarCategoria("Tecnología"), 15));
            AgregarArticulo(new Articulo("Bicicleta eléctrica", BuscarCategoria("Salud"), 800));
            AgregarArticulo(new Articulo("Perfume femenino", BuscarCategoria("Hogar"), 60));
            AgregarArticulo(new Articulo("Refrigerador", BuscarCategoria("Hogar"), 450));
            AgregarArticulo(new Articulo("Videojuego de estrategia", BuscarCategoria("Entretenimiento"), 45));
            AgregarArticulo(new Articulo("Pantalones de trabajo", BuscarCategoria("Indumentaria"), 35));
            AgregarArticulo(new Articulo("Smartwatch", BuscarCategoria("Tecnología"), 200));
            AgregarArticulo(new Articulo("Televisor", BuscarCategoria("Entretenimiento"), 500));
            AgregarArticulo(new Articulo("Pelota de playa", BuscarCategoria("Deportes"), 22));
            AgregarArticulo(new Articulo("Acondicionador para cabello", BuscarCategoria("Salud"), 12));
            AgregarArticulo(new Articulo("Consola virtual", BuscarCategoria("Tecnología"), 100));
            AgregarArticulo(new Articulo("Tenis", BuscarCategoria("Indumentaria"), 70));
            AgregarArticulo(new Articulo("Calculadora científica", BuscarCategoria("Educación"), 120));
            AgregarArticulo(new Articulo("Cama elástica", BuscarCategoria("Deportes"), 180));
            AgregarArticulo(new Articulo("Jugador de golf", BuscarCategoria("Indumentaria"), 90));
            AgregarArticulo(new Articulo("Cera para pestañas", BuscarCategoria("Salud"), 10));
            AgregarArticulo(new Articulo("Computadora portátil", BuscarCategoria("Tecnología"), 700));
            AgregarArticulo(new Articulo("Microondas", BuscarCategoria("Hogar"), 150));
            AgregarArticulo(new Articulo("Libro de historia", BuscarCategoria("Educación"), 28));
            AgregarArticulo(new Articulo("Juguetes educativos", BuscarCategoria("Educación"), 25));
            AgregarArticulo(new Articulo("Desodorante", BuscarCategoria("Salud"), 15));
            AgregarArticulo(new Articulo("Consola de juegos", BuscarCategoria("Entretenimiento"), 300));
            AgregarArticulo(new Articulo("Ropa de baño", BuscarCategoria("Hogar"), 30));
            AgregarArticulo(new Articulo("Tableta grasa corporal", BuscarCategoria("Salud"), 50));
            AgregarArticulo(new Articulo("Aspiradora", BuscarCategoria("Hogar"), 200));
            AgregarArticulo(new Articulo("Película de animación", BuscarCategoria("Entretenimiento"), 15));
            AgregarArticulo(new Articulo("Bicicleta de montaña", BuscarCategoria("Deportes"), 750));
            AgregarArticulo(new Articulo("Perfume masculino", BuscarCategoria("Hogar"), 65));
            AgregarArticulo(new Articulo("Refrigerador compacto", BuscarCategoria("Hogar"), 350));
            AgregarArticulo(new Articulo("Videojuego de simulación", BuscarCategoria("Entretenimiento"), 55));
            AgregarArticulo(new Articulo("Pantalones de yoga", BuscarCategoria("Deportes"), 40));
            AgregarArticulo(new Articulo("Smartwatch fitness", BuscarCategoria("Salud"), 220));
            AgregarArticulo(new Articulo("Televisor inteligente", BuscarCategoria("Tecnología"), 650));
            AgregarArticulo(new Articulo("Gorra de beisbol", BuscarCategoria("Deportes"), 25));
            AgregarArticulo(new Articulo("Acondicionador para cabello", BuscarCategoria("Salud"), 15));
            AgregarArticulo(new Articulo("Consola virtual", BuscarCategoria("Tecnología"), 100));
            AgregarArticulo(new Articulo("Tenis", BuscarCategoria("Indumentaria"), 70));
            AgregarArticulo(new Articulo("Kit de programación", BuscarCategoria("Educación"), 120));
        }
        private void PrecargaPublicaciones()
        {
            //VENTAS
            AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
               BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {BuscarArticulo(20), BuscarArticulo(25),
               BuscarArticulo(42), BuscarArticulo(38)}, FechaRandom()));
            AgregarPublicacion(new Venta("Mantente en forma", Estado.ABIERTA,
               BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {BuscarArticulo(45), BuscarArticulo(38),
               BuscarArticulo(25)}, FechaRandom()));
            AgregarPublicacion(new Venta("Sal de tu casa", Estado.ABIERTA, BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> { BuscarArticulo(42), BuscarArticulo(25), BuscarArticulo(20), BuscarArticulo(45) }, FechaRandom()));
            AgregarPublicacion(new Venta("Luce el mejor look", Estado.ABIERTA,
               BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {BuscarArticulo(26), BuscarArticulo(48),
               BuscarArticulo(17), BuscarArticulo(9)}, FechaRandom()));
            AgregarPublicacion(new Venta("Mantente saludable", Estado.ABIERTA,
               BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {BuscarArticulo(46), BuscarArticulo(13),
               BuscarArticulo(7)}, FechaRandom()));
            AgregarPublicacion(new Venta("Para cuidar tu cuerpo", Estado.ABIERTA,
               BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {BuscarArticulo(43), BuscarArticulo(35),
               BuscarArticulo(2), BuscarArticulo(32)}, FechaRandom()));
            AgregarPublicacion(new Venta("Para quedarte en casa", Estado.ABIERTA,
               BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {BuscarArticulo(41), BuscarArticulo(8),
               BuscarArticulo(10)}, FechaRandom()));
            AgregarPublicacion(new Venta("Cultiva tu mente", Estado.ABIERTA,
               BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {BuscarArticulo(31), BuscarArticulo(49),
               BuscarArticulo(24), BuscarArticulo(5)}, FechaRandom()));
            AgregarPublicacion(new Venta("Mantente actualizado", Estado.ABIERTA,
               BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {BuscarArticulo(28), BuscarArticulo(22),
               BuscarArticulo(12), BuscarArticulo(3)}, FechaRandom()));
            AgregarPublicacion(new Venta("Lo que no te puede faltar", Estado.ABIERTA,
               BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {BuscarArticulo(17), BuscarArticulo(9),
               BuscarArticulo(1), BuscarArticulo(0)}, FechaRandom()));

            //SUBASTAS
            AgregarPublicacion(new Subasta("Verano en la Playa", Estado.ABIERTA,
               BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {BuscarArticulo(4), BuscarArticulo(6),
               BuscarArticulo(9), BuscarArticulo(45)}, FechaRandom()));
        }
        private void PreCargaOfertas()
        {
            Subasta unaPublicacion = BuscarPublicacionSubasta(10);
            unaPublicacion.CargarOferta(new Oferta(BuscarUsuario("ernaldo.rodriguez.dev1@gmail.com"), 1334));
            unaPublicacion.CargarOferta(new Oferta(BuscarUsuario("dgeymonat84@gmail.com"), 256));
        }

        public static DateTime FechaRandom()
        {
            bool flag = false;
            DateTime fecha = new DateTime();
            do
            {
                int anio = new Random().Next(2022, 2024);
                int mes = new Random().Next(1, 12);
                int dia = new Random().Next(28);
                fecha = new DateTime(anio, mes, dia);
                DateTime fechaActual = DateTime.Now;
                if (fechaActual > fecha)
                    flag = true;
            } while (!flag);
            return fecha;
        }
        #endregion

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



        public List<Usuario> MostrarUsuarios(bool admin)
        {
            List<Usuario> unaLista = new List<Usuario>();

            foreach (Usuario usuario in _usuarios)
            {
                if (usuario is Cliente && !admin)
                {
                    unaLista.Add(usuario);
                }
                else if (usuario is Administrador && admin)
                {
                    unaLista.Add(usuario);
                }
            }
            return unaLista;
        }
        public List<Categoria> MostrarCategorias()
        {
            return _categorias;
        }

        public List<Publicacion> ListaPublicaciones(string tipo, Estado estado)
        {
            if (string.IsNullOrEmpty(tipo)) throw new Exception("No se ha cargado el tipo en el parametro");
            List<Publicacion> publicaciones = new List<Publicacion>();

            foreach (Publicacion unaPublicacion in _publicaciones) //.nombre == tipo.ToUpper())
            {
                if (tipo.ToUpper() == "TODOS")
                {
                    if (estado == unaPublicacion.EstadoPublicacion)
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                    else if (estado.ToString() == "TODOS")
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                }
                else if (tipo.ToUpper() == "VENTA" && unaPublicacion is Venta)
                {
                    if (estado == unaPublicacion.EstadoPublicacion)
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                    else if (estado.ToString() == "TODOS")
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                }
                else if (tipo.ToUpper() == "SUBASTA" && unaPublicacion is Subasta)
                {
                    if (estado == unaPublicacion.EstadoPublicacion)
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                    else if (estado.ToString() == "TODOS")
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                }
            }
            return publicaciones;
        }

        public List<Articulo> MostrarArticulos(string categoria)
        {
            List<Articulo> resultado = new List<Articulo>();
            if (categoria.ToUpper() == "TODOS")
            {
                foreach (Articulo unArticulo in _articulos) resultado.Add(unArticulo);
            }
            else
            {
                foreach (Articulo unArticulo in _articulos)
                {
                    List<Categoria> categorias = new List<Categoria>();
                    categorias = unArticulo.ObtenerCategorias();
                    foreach (Categoria unaCategoria in categorias)
                    {
                        if (unaCategoria.Nombre == categoria)
                            resultado.Add(unArticulo);
                    }
                }
            }
            return resultado;
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
            if (BuscarUsuario(nuevoUsuario.Email) != null) throw new Exception("El usuario ya existe");
            _usuarios.Add(nuevoUsuario);
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
