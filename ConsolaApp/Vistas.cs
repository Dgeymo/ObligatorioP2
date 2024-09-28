using Dominio;
using Dominio.Entidades;
using System;
using System.Drawing;
namespace ConsolaApp
{
    public class Vistas : Program
    {
        private delegate void Parametro1();
        private static List<Parametro1> lista = new List<Parametro1>();
        public static void MenuInicio()
        {
            Console.Clear();
            ImprimirLogo();
            int opcion = ConstructorMenu(["Ingresar PRECARGAS", "Administrador", "Salir"]);
            lista.Clear();
            lista.Add(PreCargar);
            lista.Add(MenuAdministracion);
            lista.Add(Salir);
            lista[opcion]();
        }

        private static void PreCargar()
        {
            _sistema.PreCargar();
            TextoColor("green", "Precargas ingresadas. Presione cualquier tecla para continuar...");
            Console.ReadKey();
            MenuInicio();
        }

        private static void MenuAdministracion()
        {
            Console.Clear();
            Console.WriteLine("HERRAMIENTAS ADMINISTRATIVAS");
            int opcion = ConstructorMenu(["Categorias", "Articulos", "Clientes", "Publicaciones", "Volver"]);
            lista.Clear();
            lista.Add(AdministrarCategorias);
            lista.Add(AdministrarArticulos);
            lista.Add(ListarUsuarios);
            lista.Add(AdministrarPublicaciones);
            lista.Add(MenuInicio);
            lista[opcion]();
        }
        private static void AdministrarPublicaciones()
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRACION DE PUBLICACIONES");
            int opcion = ConstructorMenu(["Listar publicaciones", "Volver"]);
            lista.Clear();
            lista.Add(ListarPublicaciones);
            lista.Add(MenuAdministracion);
            lista[opcion]();
        }
        private static void ListarPublicaciones()
        {
            Console.Clear();
            Console.WriteLine("PUBLICACIONES");
            string[] opciones = ["Todas las publicaciones", "Ventas", "Subastas", "Ofertas de las SUBASTAS", "Listar entre fechas", "Volver"];
            int opcion = ConstructorMenu(opciones);
            switch (opcion)
            {
                case 0:
                    VerPublicaciones("Todas las publicaciones", "todos", Estado.TODOS);
                    TextoColor("yellow", "Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    ListarPublicaciones();
                    break;
                case 1:
                    VerPublicaciones("VENTAS", "venta", Estado.TODOS);
                    TextoColor("yellow", "Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    ListarPublicaciones();
                    break;
                case 2:
                    VerPublicaciones("SUBASTAS", "subasta", Estado.TODOS);
                    TextoColor("yellow", "Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    ListarPublicaciones();
                    break;
                case 3:
                    OfertasSubastas();
                    break;
                case 4:
                    ListarEntreFechas();
                    break;
                case 5:
                    AdministrarPublicaciones();
                    break;
                default:
                    break;
            }
        }

        private static void ListarEntreFechas()
        {
            List<Publicacion> publicaciones = new List<Publicacion>(_sistema.ListaPublicaciones("TODOS", Estado.TODOS));
            Console.Clear();
            Console.WriteLine("Filtrar Publicaciones entre dos fechas.");
            Console.WriteLine("Ingrese una fecha de inicio (DD/MM/YYYY).");
            DateTime fechaIncio = ObtenerFecha();
            Console.WriteLine("Ingrese una fecha final (DD/MM/YYYY).");
            DateTime fechaFinal = ObtenerFecha();
            DateTime fechaMayor = fechaIncio;
            if (fechaIncio > fechaFinal)
            {
                fechaIncio = fechaFinal;
                fechaFinal = fechaMayor;
            }
            int contador = 0;
            foreach (Publicacion publicacion in publicaciones)
            {
                if (publicacion.FechaPublicacion >= fechaIncio && publicacion.FechaPublicacion <= fechaFinal)
                {
                    contador++;
                    string tipo = publicacion.GetType().Name;
                    Console.WriteLine($"ID: {publicacion.Id}\nTIPO: {tipo}\nESTADO: {publicacion.EstadoPublicacion}\n" +
                        $"FECHA DE PUBLICACION: {publicacion.FechaPublicacion.ToShortDateString()}\n");
                }
            }
            if ( contador == 0 ) TextoColor("yellow", $"No hay Publicaciones entre {fechaIncio.ToShortDateString()} y " +
                $"{fechaFinal.ToShortDateString()}");
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            Console.ReadKey();
            AdministrarPublicaciones();
        }

        private static DateTime ObtenerFecha()
        {
            DateTime fecha = DateTime.Now;
            bool flag = false;
            do
            {
                try
                {
                    fecha = DateTime.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ingrese un fecha válida en formato DD/MM/YYYY");
                }
            } while (!flag);
            return fecha;
        }

        private static void OfertasSubastas()
        {
            Console.Clear();
            List<Publicacion> ventas = _sistema.ListaPublicaciones("SUBASTA", Estado.ABIERTA);
            List<string> nombres = new List<string>();
            foreach (Publicacion item in ventas)
            {
                nombres.Add(item.Nombre);
            }
            nombres.Add("Volver");
            int opcion = ConstructorMenu(nombres.ToArray());
            if (opcion == nombres.Count - 1) ListarPublicaciones(); //opcion de volver
            Subasta publicacion = ventas[opcion] as Subasta;
            List<Oferta> ofertas = publicacion.MostrarOfertas();
            if (ofertas.Count == 0)
            {
                TextoColor("yellow", "Esta Subasta no tiene Ofertas para mostrar.");
            }
            else
            {
                foreach (Oferta oferta in ofertas)
                {
                    Console.WriteLine(oferta.ToString());
                }
            }
        }
        private static void VerPublicaciones(string titulo, string tipo, Estado estado)
        {
            Console.Clear();
            Console.WriteLine(titulo);
            List<Publicacion> ventas = _sistema.ListaPublicaciones(tipo, estado);
            if (ventas.Count == 0)
            {
                TextoColor("yellow", $"No hay Publicaciones tipo {tipo} para mostrar.");
            }
            else
            {
                for (int i = 0; i < ventas.Count; i++)
                {
                    Console.WriteLine(ventas[i].ToString());
                }
            }
        }
        private static void ListarUsuarios()
        {
            Console.Clear();
            Console.WriteLine("LISTAR USUARIOS");
            int opcion = ConstructorMenu(["Listar clientes", "Listar administradores", "Volver"]);
            lista.Clear();
            lista.Add(ListarClientes);
            lista.Add(ListarAdministradores);
            lista.Add(MenuAdministracion);
            lista[opcion]();
        }
        private static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("CLIENTES\n");
            List<Usuario> listaUsuarios = new(_sistema.MostrarUsuarios(false));
            if (listaUsuarios.Count == 0)
            {
                TextoColor("yellow", "No hay Clientes para mostrar.");
            }
            else
            {
                foreach (Usuario usuario in listaUsuarios)
                {
                    Console.WriteLine(usuario.ToString() + "\n");
                }
            }
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            Console.ReadKey();
            ListarUsuarios();
        }
        private static void ListarAdministradores()
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRADORES\n");
            List<Usuario> listaUsuarios = new(_sistema.MostrarUsuarios(true));
            if (listaUsuarios.Count == 0)
            {
                TextoColor("yellow", "No hay Administradores para mostrar.");
            }
            else
            {
                foreach (Usuario usuario in listaUsuarios)
                {
                    Console.WriteLine(usuario.ToString() + "\n");
                }
            }
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            Console.ReadKey();
            ListarUsuarios();
        }
        private static void AdministrarArticulos()
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRACION DE ARTICULOS");
            int opcion = ConstructorMenu(["Listar", "Agregar", "Modificar (en construccion)",
                "Volver"]);
            lista.Clear();
            lista.Add(ListarArticulos);
            lista.Add(AgregarArticulos);
            lista.Add(EnConstruccion);
            lista.Add(MenuAdministracion);
            lista[opcion]();
        }
        private static void ListarArticulos()
        {
            Console.Clear();
            Console.WriteLine("LISTAR ARTÍCULOS");
            int opcion = ConstructorMenu(["Todos", "Por categoria", "Volver"]);
            lista.Clear();
            lista.Add(ListarArticulosTodos);
            lista.Add(ListarArticulosFiltrado);
            lista.Add(AdministrarArticulos);
            lista[opcion]();
        }
        private static void ListarArticulosTodos()
        {
            Console.Clear();
            List<Articulo> lista = new List<Articulo>(_sistema.MostrarArticulos("TODOS"));
            if (lista.Count == 0)
            {
                TextoColor("yellow", "No hay Artículos que mostrar.");
            }
            else
            {
                foreach (Articulo unArticulo in lista)
                {
                    Console.WriteLine(unArticulo.ToString());
                }
            }
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            Console.ReadKey();
            ListarArticulos();
        }
        private static void ListarArticulosFiltrado()
        {
            Console.Clear();
            Console.WriteLine("LISTAR ARTICULOS POR CATEGORIA");
            Console.WriteLine("Seleccione una categoria");
            List<string> categorias = new List<string>(MostrarCategoriasNombre());
            categorias.Add("Volver");
            int opcion = ConstructorMenu(categorias.ToArray());
            if (opcion == categorias.Count - 1) ListarArticulos();
            categorias = MostrarCategoriasNombre();
            List<Articulo> articulos = new List<Articulo>(_sistema.MostrarArticulos(categorias[opcion]));
            Console.Clear();
            if (articulos.Count == 0)
            {
                TextoColor("yellow", "No hay Artículos para mostrar.");
            }
            else
            {
                foreach (Articulo articulo in articulos)
                {
                    Console.WriteLine(articulo.ToString());
                }
            }
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            Console.ReadKey();
            ListarArticulos();
        }
        private static void AgregarArticulos()
        {
            Console.Clear();
            Console.WriteLine("AGREGAR ARTICULO NUEVO");
            string categoria = SeleccionarCategorias(_sistema.MostrarCategorias());
            if (categoria != "Cancelar")
            {
                TextoColor("yellow", $"Categoría elegida: {categoria}");
                Console.WriteLine("Ingrese un nombre para el artículo:");
                string nombre = Console.ReadLine()!;
                decimal precio = PedirPrecio();
                AceptarArticulo(categoria, nombre, precio);
            }
            else
            {
                AdministrarArticulos();
            }
        }

        private static decimal PedirPrecio()
        {
            decimal precio = 0;
            bool flag = false;
            do
            {
                try
                {
                    Console.WriteLine("Ingrese el precio para el artículo:");
                    precio = decimal.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ingrese solo números.");
                }
            } while (!flag);
            return precio;
        }

        private static void AceptarArticulo(string categoria, string nombre, decimal precio)
        {
            Console.Clear();
            Console.WriteLine("CONFIRMAR ARTICULO NUEVO");
            TextoColor("yellow", $"\nNOMBRE : {nombre.ToUpper()}\nPRECIO : {precio}\nCATEGORIA : {categoria}\n");
            int opcion = ConstructorMenu(["ACEPTAR", "CANCELAR"]);
            if (opcion == 0 && !string.IsNullOrEmpty(nombre) && precio > 0)
            {
                _sistema.AgregarArticulo(new Articulo(nombre, _sistema.BuscarCategoria(categoria), precio));
                Console.WriteLine("Producto agregado correctamente. Presione cualquier tecla para continuar...");
                Console.ReadKey();
                AdministrarArticulos();
            }
            else if (opcion != 0 && !string.IsNullOrEmpty(nombre) && precio > 0)
            {
                TextoColor("yellow", "Cancelado. Presione cualquier tecla para continuar...");
                Console.ReadKey();
                AdministrarArticulos();
            }
            else if (opcion == 0 || string.IsNullOrEmpty(nombre) || precio <= 0)
            {
                TextoColor("yellow", "Cancelado. Campo Categorias/Nombre vacias o precio incorrecto. Presione cualquier tecla para continuar...");
                Console.ReadKey();
                AdministrarArticulos();
            }
        }
        private static string SeleccionarCategorias(List<Categoria> categorias)
        {
            int opcion;
            List<string> listaCategorias = new List<String>(MostrarCategoriasNombre());
            listaCategorias.Add("Cancelar");
            Console.Clear();
            Console.WriteLine("Seleccione una categoria para agregar al nuevo artículo");
            opcion = ConstructorMenu(listaCategorias.ToArray());
            string categoria = listaCategorias[opcion];
            return categoria;
        }
        //Bloque de muestra de listas como strings
        private static List<string> MostrarCategoriasNombre()
        {
            List<string> listaCategorias = new List<string>();
            foreach (Categoria item in _sistema.MostrarCategorias())
            {
                listaCategorias.Add(item.Nombre.ToString());
            }
            return listaCategorias;
        }
        private static void AdministrarCategorias()
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRACION DE CATEGORÍAS");
            int opcion = ConstructorMenu(["Listar categorías", "Agregar categoría", "Volver"]);
            lista.Clear();
            lista.Add(ListarCategoria);
            lista.Add(AgregarCategoria);
            lista.Add(MenuAdministracion);
            lista[opcion]();
        }
        private static void AgregarCategoria()
        {
            bool flag = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese un título para la categoria.  (0) Cancelar");
                    string titulo = Console.ReadLine()!;
                    if (titulo != "0")
                    {
                        Console.WriteLine("Ingrese una breve descripción de la categoria.  (0) Cancelar");
                        string descripcion = Console.ReadLine()!;
                        if (descripcion != "0")
                        {
                            Categoria nuevaCategoria = new Categoria(titulo, descripcion);
                            _sistema.AgregarCategoria(nuevaCategoria);
                        }
                    }
                    flag = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            } while (!flag);
            AdministrarCategorias();
        }
        private static void ListarCategoria()
        {
            Console.Clear();
            Console.WriteLine("CATEGORÍAS\n");
            List<Categoria> lista = _sistema.MostrarCategorias();
            int contador = 1;
            if (lista.Count == 0)
            {
                TextoColor("yellow", "No hay categorías que mostrar.");
            }
            else
            {
                foreach (Categoria unaCategoria in lista)
                {
                    Console.WriteLine($"({contador}) " + unaCategoria.ToString());
                    contador++;
                }
            }
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            Console.ReadKey();
            AdministrarCategorias();
        }
        private static void Salir()
        {
            TextoColor("green", "Has salido del sistema...\n-> Presiona cualquier tecla para cerrar esta ventanta");
            lista.Clear();
        }
        private static void EnConstruccion()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(" EN CONSTRUCCION ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadKey();
            MenuInicio();
        }
        private static int ConstructorMenu(string[] opciones)
        {
            string menu = string.Empty;
            for (int i = 0; i < opciones.Length - 1; i++)
            {
                menu += $"\n({i + 1})_{opciones[i]}";
            }
            menu += $"\n(0)_{opciones[opciones.Length - 1]}\n";
            Console.WriteLine(menu);
            return SelectorMenu(opciones.Length);
        }
        private static int SelectorMenu(int opciones)
        {
            int opcion = 0;
            bool flag = false;
            do
            {
                opcion = PedirNumero("Seleccione una opcion del menú", opciones);
                flag = true;
                if (opcion > opciones - 1) flag = false;
            }
            while (!flag);
            if (opcion == 0) return opciones - 1;
            return opcion - 1;
        }
        private static void ImprimirLogo()
        {
            string C = "█";//alt+219
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t=============================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\t{C}{C}{C}{C}  {C}{C}{C}   {C}{C}{C}  {C}   {C}   {C}{C}{C}{C}");
            Console.WriteLine($"\t{C}    {C}   {C} {C}     {C}   {C}  {C}");
            Console.WriteLine($"\t{C}{C}   {C}   {C} {C}     {C}   {C}   {C}{C}{C}");
            Console.WriteLine($"\t{C}    {C}   {C} {C}     {C}   {C}      {C}");
            Console.WriteLine($"\t{C}     {C}{C}{C}   {C}{C}{C}   {C}{C}{C}   {C}{C}{C}{C}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t=============Tu Tienda Online\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void TextoColor(string color, string mensaje)
        {
            switch (color)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    break;
            }
            Console.WriteLine("\n" + mensaje);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static int PedirNumero(string titulo, int opciones)
        {
            bool flag = false;
            int numero = 0;
            do
            {
                try
                {
                    if (opciones > 10)
                    {
                        Console.WriteLine(titulo);
                        numero = int.Parse(Console.ReadLine()!);
                    }
                    else
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        numero = int.Parse($"{key.KeyChar}");
                    }
                    flag = true;
                }
                catch (Exception)
                {
                    TextoColor("red", "Ingrese solo numeros!!! Presione cualquier tecla para continuar...");
                }
            } while (!flag);
            return numero;
        }
    }
}
