using Dominio.Entidades;

namespace ConsolaApp
{
    public  class PreCarga:Program
    {
        public static void PreCargas()
        {
            PrecargaUsuarios();
            PrecargaCategoria();
            PrecargaArticulo();
            PrecargaEstado();
            PrecargaTipo();
            PrecargaPublicaciones();
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
            _sistema.AgregarArticulo(new Articulo("Zapatillas de correr", new List<Categoria> { _sistema.BuscarCategoria("Deportes"), _sistema.BuscarCategoria("Indumentaria") }, 80));
            _sistema.AgregarArticulo(new Articulo("Camiseta de fútbol", new List<Categoria> { _sistema.BuscarCategoria("Deportes"), _sistema.BuscarCategoria("Indumentaria") }, 25));
            _sistema.AgregarArticulo(new Articulo("Suplemento de creatina", new List<Categoria> { _sistema.BuscarCategoria("Salud"), _sistema.BuscarCategoria("Tecnología") }, 40));
            _sistema.AgregarArticulo(new Articulo("Smartphone", new List<Categoria> { _sistema.BuscarCategoria("Tecnología"), _sistema.BuscarCategoria("Entretenimiento") }, 600));
            _sistema.AgregarArticulo(new Articulo("Sofá", new List<Categoria> { _sistema.BuscarCategoria("Hogar"), _sistema.BuscarCategoria("Entretenimiento") }, 300));
            _sistema.AgregarArticulo(new Articulo("Libro de programación", new List<Categoria> { _sistema.BuscarCategoria("Entretenimiento"), _sistema.BuscarCategoria("Tecnología") }, 30));
            _sistema.AgregarArticulo(new Articulo("Juguetes educativos", new List<Categoria> { _sistema.BuscarCategoria("Niños"), _sistema.BuscarCategoria("Educación") }, 20));
            _sistema.AgregarArticulo(new Articulo("Cera para duchas", new List<Categoria> { _sistema.BuscarCategoria("Salud"), _sistema.BuscarCategoria("Hogar") }, 15));
            _sistema.AgregarArticulo(new Articulo("Consola de videojuegos", new List<Categoria> { _sistema.BuscarCategoria("Entretenimiento"), _sistema.BuscarCategoria("Tecnología") }, 400));
            _sistema.AgregarArticulo(new Articulo("Ropa interior", new List<Categoria> { _sistema.BuscarCategoria("Indumentaria"), _sistema.BuscarCategoria("Salud") }, 18));
            _sistema.AgregarArticulo(new Articulo("Tablet", new List<Categoria> { _sistema.BuscarCategoria("Tecnología"), _sistema.BuscarCategoria("Entretenimiento") }, 350));
            _sistema.AgregarArticulo(new Articulo("Lavadora", new List<Categoria> { _sistema.BuscarCategoria("Hogar"), _sistema.BuscarCategoria("Tecnología") }, 250));
            _sistema.AgregarArticulo(new Articulo("Película de acción", new List<Categoria> { _sistema.BuscarCategoria("Entretenimiento"), _sistema.BuscarCategoria("Tecnología") }, 15));
            _sistema.AgregarArticulo(new Articulo("Bicicleta eléctrica", new List<Categoria> { _sistema.BuscarCategoria("Deportes"), _sistema.BuscarCategoria("Tecnología") }, 800));
            _sistema.AgregarArticulo(new Articulo("Perfume femenino", new List<Categoria> { _sistema.BuscarCategoria("Salud"), _sistema.BuscarCategoria("Indumentaria") }, 60));
            _sistema.AgregarArticulo(new Articulo("Refrigerador", new List<Categoria> { _sistema.BuscarCategoria("Hogar"), _sistema.BuscarCategoria("Tecnología") }, 450));
            _sistema.AgregarArticulo(new Articulo("Videojuego de estrategia", new List<Categoria> { _sistema.BuscarCategoria("Entretenimiento"), _sistema.BuscarCategoria("Tecnología") }, 45));
            _sistema.AgregarArticulo(new Articulo("Pantalones de trabajo", new List<Categoria> { _sistema.BuscarCategoria("Indumentaria"), _sistema.BuscarCategoria("Deportes") }, 35));
            _sistema.AgregarArticulo(new Articulo("Smartwatch", new List<Categoria> { _sistema.BuscarCategoria("Tecnología"), _sistema.BuscarCategoria("Salud") }, 200));
            _sistema.AgregarArticulo(new Articulo("Televisor", new List<Categoria> { _sistema.BuscarCategoria("Hogar"), _sistema.BuscarCategoria("Entretenimiento") }, 500));
            _sistema.AgregarArticulo(new Articulo("Gorra de béisbol", new List<Categoria> { _sistema.BuscarCategoria("Indumentaria"), _sistema.BuscarCategoria("Deportes") }, 22));
            _sistema.AgregarArticulo(new Articulo("Acondicionador para cabello", new List<Categoria> { _sistema.BuscarCategoria("Salud"), _sistema.BuscarCategoria("Indumentaria") }, 12));
            _sistema.AgregarArticulo(new Articulo("Consola virtual", new List<Categoria> { _sistema.BuscarCategoria("Entretenimiento"), _sistema.BuscarCategoria("Tecnología") }, 100));
            _sistema.AgregarArticulo(new Articulo("Tenis", new List<Categoria> { _sistema.BuscarCategoria("Deportes"), _sistema.BuscarCategoria("Indumentaria") }, 70));
            _sistema.AgregarArticulo(new Articulo("Kit de programación", new List<Categoria> { _sistema.BuscarCategoria("Tecnología"), _sistema.BuscarCategoria("Entretenimiento") }, 120));
            _sistema.AgregarArticulo(new Articulo("Cama elástica", new List<Categoria> { _sistema.BuscarCategoria("Hogar"), _sistema.BuscarCategoria("Salud") }, 180));
            _sistema.AgregarArticulo(new Articulo("Jugador de golf", new List<Categoria> { _sistema.BuscarCategoria("Deportes"), _sistema.BuscarCategoria("Indumentaria") }, 90));
            _sistema.AgregarArticulo(new Articulo("Cera para pestañas", new List<Categoria> { _sistema.BuscarCategoria("Salud"), _sistema.BuscarCategoria("Indumentaria") }, 10));
            _sistema.AgregarArticulo(new Articulo("Computadora portátil", new List<Categoria> { _sistema.BuscarCategoria("Tecnología"), _sistema.BuscarCategoria("Entretenimiento") }, 700));
            _sistema.AgregarArticulo(new Articulo("Microondas", new List<Categoria> { _sistema.BuscarCategoria("Hogar"), _sistema.BuscarCategoria("Tecnología") }, 150));
            _sistema.AgregarArticulo(new Articulo("Libro de historia", new List<Categoria> { _sistema.BuscarCategoria("Entretenimiento"), _sistema.BuscarCategoria("Educación") }, 28));
            _sistema.AgregarArticulo(new Articulo("Juguetes educativos", new List<Categoria> { _sistema.BuscarCategoria("Niños"), _sistema.BuscarCategoria("Educación") }, 25));
            _sistema.AgregarArticulo(new Articulo("Desodorante", new List<Categoria> { _sistema.BuscarCategoria("Salud"), _sistema.BuscarCategoria("Indumentaria") }, 15));
            _sistema.AgregarArticulo(new Articulo("Consola de juegos", new List<Categoria> { _sistema.BuscarCategoria("Entretenimiento"), _sistema.BuscarCategoria("Tecnología") }, 300));
            _sistema.AgregarArticulo(new Articulo("Ropa de baño", new List<Categoria> { _sistema.BuscarCategoria("Indumentaria"), _sistema.BuscarCategoria("Salud") }, 30));
            _sistema.AgregarArticulo(new Articulo("Tableta grasa corporal", new List<Categoria> { _sistema.BuscarCategoria("Salud"), _sistema.BuscarCategoria("Tecnología") }, 50));
            _sistema.AgregarArticulo(new Articulo("Aspiradora", new List<Categoria> { _sistema.BuscarCategoria("Hogar"), _sistema.BuscarCategoria("Tecnología") }, 200));
            _sistema.AgregarArticulo(new Articulo("Película de animación", new List<Categoria> { _sistema.BuscarCategoria("Entretenimiento"), _sistema.BuscarCategoria("Tecnología") }, 15));
            _sistema.AgregarArticulo(new Articulo("Bicicleta de montaña", new List<Categoria> { _sistema.BuscarCategoria("Deportes"), _sistema.BuscarCategoria("Tecnología") }, 750));
            _sistema.AgregarArticulo(new Articulo("Perfume masculino", new List<Categoria> { _sistema.BuscarCategoria("Salud"), _sistema.BuscarCategoria("Indumentaria") }, 65));
            _sistema.AgregarArticulo(new Articulo("Refrigerador compacto", new List<Categoria> { _sistema.BuscarCategoria("Hogar"), _sistema.BuscarCategoria("Tecnología") }, 350));
            _sistema.AgregarArticulo(new Articulo("Videojuego de simulación", new List<Categoria> { _sistema.BuscarCategoria("Entretenimiento"), _sistema.BuscarCategoria("Tecnología") }, 55));
            _sistema.AgregarArticulo(new Articulo("Pantalones de yoga", new List<Categoria> { _sistema.BuscarCategoria("Indumentaria"), _sistema.BuscarCategoria("Deportes") }, 40));
            _sistema.AgregarArticulo(new Articulo("Smartwatch fitness", new List<Categoria> { _sistema.BuscarCategoria("Tecnología"), _sistema.BuscarCategoria("Salud") }, 220));
            _sistema.AgregarArticulo(new Articulo("Televisor inteligente", new List<Categoria> { _sistema.BuscarCategoria("Hogar"), _sistema.BuscarCategoria("Entretenimiento") }, 650));
            _sistema.AgregarArticulo(new Articulo("Gorra de beisbol", new List<Categoria> { _sistema.BuscarCategoria("Indumentaria"), _sistema.BuscarCategoria("Deportes") }, 25));
            _sistema.AgregarArticulo(new Articulo("Acondicionador para cabello", new List<Categoria> { _sistema.BuscarCategoria("Salud"), _sistema.BuscarCategoria("Indumentaria") }, 15));
            _sistema.AgregarArticulo(new Articulo("Consola virtual", new List<Categoria> { _sistema.BuscarCategoria("Entretenimiento"), _sistema.BuscarCategoria("Tecnología") }, 100));
            _sistema.AgregarArticulo(new Articulo("Tenis", new List<Categoria> { _sistema.BuscarCategoria("Deportes"), _sistema.BuscarCategoria("Indumentaria") }, 70));
            _sistema.AgregarArticulo(new Articulo("Kit de programación", new List<Categoria> { _sistema.BuscarCategoria("Tecnología"), _sistema.BuscarCategoria("Entretenimiento") }, 120));
        }
        private static void PrecargaEstado()
        {
            _sistema.AgregarEstado(new Estado("ABIERTA"));
            _sistema.AgregarEstado(new Estado("CERRADA"));
            _sistema.AgregarEstado(new Estado("CANCELADA"));
        }
        private static void PrecargaTipo()
        {
            _sistema.AgregarTipo(new Tipo("VENTA"));
            _sistema.AgregarTipo(new Tipo("SUBASTA"));
        }
        private static void PrecargaPublicaciones()
        {
            _sistema.CargarPublicacion(new Publicacion("Verano en la Playa", _sistema.BuscarEstado("ABIERTA"), DateTime.Now, _sistema.BuscarUsuario("dgeymonat84@gmail.com"), _sistema.BuscarTipo("VENTA"), false));
        }
    }
}
