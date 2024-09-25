using Dominio;
using Dominio.Entidades;

namespace ConsolaApp
{
    public class PreCarga : Program
    {
        public static void PreCargas()
        {
            PrecargaUsuarios();
            PrecargaCategoria();
            PrecargaArticulo();
            PrecargaPublicaciones();
            PreCargaOfertas();
        }
        private static void PrecargaUsuarios()
        {
            _sistema.AgregarUsuario(new Cliente("Diego", "Geymonat", "dgeymonat84@gmail.com", "Geymon4t", 135000));
            _sistema.AgregarUsuario(new Cliente("Ernaldo", "Rodriguez", "ernaldo.rodriguez.dev@gmail.com", "1234", 150000));
            _sistema.AgregarUsuario(new Administrador("Diego", "Geymonat", "dgeymonat85@gmail.com", "Geymon4t"));
            _sistema.AgregarUsuario(new Administrador("Ernaldo", "Rodriguez", "ernaldo.rodriguez.dev1@gmail.com", "1234"));
        }
        private static void PrecargaCategoria()
        {
            _sistema.AgregarCategoria(new Categoria("Deportes", "Todo lo necesario para el deporte"));
            _sistema.AgregarCategoria(new Categoria("Indumentaria", "Distintas prendas para distintas ocasiones"));
            _sistema.AgregarCategoria(new Categoria("Salud", "Todo para el cuidado"));
            _sistema.AgregarCategoria(new Categoria("Tecnología", "Celulares, computadoras, consolas y más..."));
            _sistema.AgregarCategoria(new Categoria("Niños", "Todo para los peques"));
            _sistema.AgregarCategoria(new Categoria("Hogar", "Accesorio para el hogar"));
            _sistema.AgregarCategoria(new Categoria("Entretenimiento", "Para tu tiempo libre"));
            _sistema.AgregarCategoria(new Categoria("Educación", "Para crecer y aprender"));
        }
        private static void PrecargaArticulo()
        {
            _sistema.AgregarArticulo(new Articulo("Zapatillas de correr", new List<Categoria> {  _sistema.BuscarCategoria("Indumentaria") }, 80));
            _sistema.AgregarArticulo(new Articulo("Camiseta de fútbol", new List<Categoria> {_sistema.BuscarCategoria("Indumentaria") }, 25));
            _sistema.AgregarArticulo(new Articulo("Suplemento de creatina", new List<Categoria> { _sistema.BuscarCategoria("Salud") }, 40));
            _sistema.AgregarArticulo(new Articulo("Smartphone", new List<Categoria> {_sistema.BuscarCategoria("Tecnología") }, 600));
            _sistema.AgregarArticulo(new Articulo("Sofá", new List<Categoria> {_sistema.BuscarCategoria("Hogar") }, 300));
            _sistema.AgregarArticulo(new Articulo("Libro de programación", new List<Categoria> { _sistema.BuscarCategoria("Educación") }, 30));
            _sistema.AgregarArticulo(new Articulo("Juguetes educativos", new List<Categoria> {_sistema.BuscarCategoria("Educación") }, 20));
            _sistema.AgregarArticulo(new Articulo("Cera para duchas", new List<Categoria> { _sistema.BuscarCategoria("Salud")}, 15));
            _sistema.AgregarArticulo(new Articulo("Consola de videojuegos", new List<Categoria> { _sistema.BuscarCategoria("Entretenimiento") }, 400));
            _sistema.AgregarArticulo(new Articulo("Ropa interior", new List<Categoria> {_sistema.BuscarCategoria("Indumentaria") }, 18));
            _sistema.AgregarArticulo(new Articulo("Tablet", new List<Categoria> {_sistema.BuscarCategoria("Entretenimiento") }, 350));
            _sistema.AgregarArticulo(new Articulo("Lavadora", new List<Categoria> { _sistema.BuscarCategoria("Hogar") }, 250));
            _sistema.AgregarArticulo(new Articulo("Película de acción", new List<Categoria> { _sistema.BuscarCategoria("Tecnología") }, 15));
            _sistema.AgregarArticulo(new Articulo("Bicicleta eléctrica", new List<Categoria> {_sistema.BuscarCategoria("Salud") }, 800));
            _sistema.AgregarArticulo(new Articulo("Perfume femenino", new List<Categoria> {_sistema.BuscarCategoria("Hogar") }, 60));
            _sistema.AgregarArticulo(new Articulo("Refrigerador", new List<Categoria> {_sistema.BuscarCategoria("Hogar") }, 450));
            _sistema.AgregarArticulo(new Articulo("Videojuego de estrategia", new List<Categoria> {_sistema.BuscarCategoria("Entretenimiento") }, 45));
            _sistema.AgregarArticulo(new Articulo("Pantalones de trabajo", new List<Categoria> {_sistema.BuscarCategoria("Indumentaria") }, 35));
            _sistema.AgregarArticulo(new Articulo("Smartwatch", new List<Categoria> {_sistema.BuscarCategoria("Tecnología") }, 200));
            _sistema.AgregarArticulo(new Articulo("Televisor", new List<Categoria> {_sistema.BuscarCategoria("Entretenimiento") }, 500));
            _sistema.AgregarArticulo(new Articulo("Gorra de béisbol", new List<Categoria> {_sistema.BuscarCategoria("Deportes") }, 22));
            _sistema.AgregarArticulo(new Articulo("Acondicionador para cabello", new List<Categoria> { _sistema.BuscarCategoria("Salud") }, 12));
            _sistema.AgregarArticulo(new Articulo("Consola virtual", new List<Categoria> {_sistema.BuscarCategoria("Tecnología") }, 100));
            _sistema.AgregarArticulo(new Articulo("Tenis", new List<Categoria> {_sistema.BuscarCategoria("Indumentaria") }, 70));
            _sistema.AgregarArticulo(new Articulo("Kit de programación", new List<Categoria> {_sistema.BuscarCategoria("Educación") }, 120));
            _sistema.AgregarArticulo(new Articulo("Cama elástica", new List<Categoria> {_sistema.BuscarCategoria("Deportes") }, 180));
            _sistema.AgregarArticulo(new Articulo("Jugador de golf", new List<Categoria> { _sistema.BuscarCategoria("Indumentaria") }, 90));
            _sistema.AgregarArticulo(new Articulo("Cera para pestañas", new List<Categoria> {_sistema.BuscarCategoria("Salud") }, 10));
            _sistema.AgregarArticulo(new Articulo("Computadora portátil", new List<Categoria> {_sistema.BuscarCategoria("Tecnología") }, 700));
            _sistema.AgregarArticulo(new Articulo("Microondas", new List<Categoria> { _sistema.BuscarCategoria("Hogar") }, 150));
            _sistema.AgregarArticulo(new Articulo("Libro de historia", new List<Categoria> {_sistema.BuscarCategoria("Educación") }, 28));
            _sistema.AgregarArticulo(new Articulo("Juguetes educativos", new List<Categoria> {_sistema.BuscarCategoria("Educación") }, 25));
            _sistema.AgregarArticulo(new Articulo("Desodorante", new List<Categoria> {_sistema.BuscarCategoria("Salud") }, 15));
            _sistema.AgregarArticulo(new Articulo("Consola de juegos", new List<Categoria> {_sistema.BuscarCategoria("Entretenimiento") }, 300));
            _sistema.AgregarArticulo(new Articulo("Ropa de baño", new List<Categoria> {_sistema.BuscarCategoria("Hogar") }, 30));
            _sistema.AgregarArticulo(new Articulo("Tableta grasa corporal", new List<Categoria> {_sistema.BuscarCategoria("Salud") }, 50));
            _sistema.AgregarArticulo(new Articulo("Aspiradora", new List<Categoria> {_sistema.BuscarCategoria("Hogar") }, 200));
            _sistema.AgregarArticulo(new Articulo("Película de animación", new List<Categoria> {_sistema.BuscarCategoria("Entretenimiento") }, 15));
            _sistema.AgregarArticulo(new Articulo("Bicicleta de montaña", new List<Categoria> {_sistema.BuscarCategoria("Deportes") }, 750));
            _sistema.AgregarArticulo(new Articulo("Perfume masculino", new List<Categoria> {_sistema.BuscarCategoria("Hogar") }, 65));
            _sistema.AgregarArticulo(new Articulo("Refrigerador compacto", new List<Categoria> {  _sistema.BuscarCategoria("Hogar") }, 350));
            _sistema.AgregarArticulo(new Articulo("Videojuego de simulación", new List<Categoria> {  _sistema.BuscarCategoria("Entretenimiento") }, 55));
            _sistema.AgregarArticulo(new Articulo("Pantalones de yoga", new List<Categoria> {  _sistema.BuscarCategoria("Deportes") }, 40));
            _sistema.AgregarArticulo(new Articulo("Smartwatch fitness", new List<Categoria> { _sistema.BuscarCategoria("Salud") }, 220));
            _sistema.AgregarArticulo(new Articulo("Televisor inteligente", new List<Categoria> { _sistema.BuscarCategoria("Tecnología") }, 650));
            _sistema.AgregarArticulo(new Articulo("Gorra de beisbol", new List<Categoria> {  _sistema.BuscarCategoria("Deportes") }, 25));
            _sistema.AgregarArticulo(new Articulo("Acondicionador para cabello", new List<Categoria> { _sistema.BuscarCategoria("Salud") }, 15));
            _sistema.AgregarArticulo(new Articulo("Consola virtual", new List<Categoria> { _sistema.BuscarCategoria("Tecnología") }, 100));
            _sistema.AgregarArticulo(new Articulo("Tenis", new List<Categoria> { _sistema.BuscarCategoria("Indumentaria") }, 70));
            _sistema.AgregarArticulo(new Articulo("Kit de programación", new List<Categoria> { _sistema.BuscarCategoria("Educación") }, 120));
        }
        private static void PrecargaPublicaciones()
        {
            //VENTAS
            _sistema.AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
               _sistema.BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {_sistema.BuscarArticulo(4), _sistema.BuscarArticulo(6),
               _sistema.BuscarArticulo(9), _sistema.BuscarArticulo(45)}, FechaRandom()));
            _sistema.AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
               _sistema.BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {_sistema.BuscarArticulo(45), _sistema.BuscarArticulo(38),
               _sistema.BuscarArticulo(25)}, FechaRandom()));
            _sistema.AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
               _sistema.BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {_sistema.BuscarArticulo(42), _sistema.BuscarArticulo(25),
               _sistema.BuscarArticulo(20), _sistema.BuscarArticulo(45)}, FechaRandom()));
            _sistema.AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
               _sistema.BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {_sistema.BuscarArticulo(26), _sistema.BuscarArticulo(48),
               _sistema.BuscarArticulo(17), _sistema.BuscarArticulo(9)}, FechaRandom()));
            _sistema.AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
               _sistema.BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {_sistema.BuscarArticulo(46), _sistema.BuscarArticulo(13),
               _sistema.BuscarArticulo(7)}, FechaRandom()));
            _sistema.AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
               _sistema.BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {_sistema.BuscarArticulo(43), _sistema.BuscarArticulo(35),
               _sistema.BuscarArticulo(2), _sistema.BuscarArticulo(32)}, FechaRandom()));
            _sistema.AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
               _sistema.BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {_sistema.BuscarArticulo(41), _sistema.BuscarArticulo(8),
               _sistema.BuscarArticulo(10)}, FechaRandom()));
            _sistema.AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
               _sistema.BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {_sistema.BuscarArticulo(31), _sistema.BuscarArticulo(49),
               _sistema.BuscarArticulo(24), _sistema.BuscarArticulo(5)}, FechaRandom()));
            _sistema.AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
               _sistema.BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {_sistema.BuscarArticulo(28), _sistema.BuscarArticulo(22),
               _sistema.BuscarArticulo(12), _sistema.BuscarArticulo(3)}, FechaRandom()));
            _sistema.AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
               _sistema.BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {_sistema.BuscarArticulo(17), _sistema.BuscarArticulo(9),
               _sistema.BuscarArticulo(1), _sistema.BuscarArticulo(0)}, FechaRandom()));

            //SUBASTAS
            _sistema.AgregarPublicacion(new Subasta("Verano en la Playa", Estado.ABIERTA,
               _sistema.BuscarUsuario("dgeymonat84@gmail.com"), false, new List<Articulo> {_sistema.BuscarArticulo(4), _sistema.BuscarArticulo(6),
               _sistema.BuscarArticulo(9), _sistema.BuscarArticulo(45)}, FechaRandom()));
        }
        private static void PreCargaOfertas()
        {
            Subasta unaPublicacion = _sistema.BuscarPublicacionSubasta(10);
            unaPublicacion.CargarOferta(new Oferta(_sistema.BuscarUsuario("ernaldo.rodriguez.dev1@gmail.com"), 1334));
            unaPublicacion.CargarOferta(new Oferta(_sistema.BuscarUsuario("dgeymonat84@gmail.com"), 256));
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
                fecha = new DateTime(anio,mes,dia);
                DateTime fechaActual = DateTime.Now;
                if(fechaActual > fecha)
                    flag = true;
            } while (!flag);
            return fecha;
        }
    }
}
