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
            Console.Clear(); //comentar para ver precargas         
            ImprimirLogo();
            int opcion = ConstructorMenu(["Usuario", "Administrador", "Salir"]);
            lista.Clear();
            lista.Add(MenuUsuario);
            lista.Add(MenuAdministracion);
            lista.Add(Salir);
            lista[opcion]();
        }
        private static void MenuUsuario()
        {
            EnConstruccion();
        }
        private static void MenuAdministracion()
        {
            Console.Clear();
            Console.WriteLine("HERRAMIENTAS ADMINISTRATIVAS");
            int opcion = ConstructorMenu(["Categorias", "Articulos", "Clientes", "Publicaciones", "Volver"]);
            lista.Clear();
            lista.Add(AdministrarCategorias);
            lista.Add(AdministrarArticulos);
            lista.Add(AdministrarClientes);
            lista.Add(AdministrarPublicaciones);
            lista.Add(MenuInicio);
            lista[opcion]();
        }
        private static void AdministrarPublicaciones()
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRACION DE PUBLICACIONES");
            int opcion = ConstructorMenu(["Listar publicaciones", "Crear nueva publicacion (VENTA)", "Crear nueva publicacion (SUBASTA)",
                "Administrar publicaciones ABIERTAS", "Volver"]);
            lista.Clear();
            lista.Add(ListarPublicaciones);
            lista.Add(EnConstruccion);
            lista.Add(EnConstruccion);
            lista.Add(EnConstruccion);
            lista.Add(MenuAdministracion);
            lista[opcion]();
        }
        private static void ListarPublicaciones()
        {
            Console.Clear();
            Console.WriteLine("PUBLICACIONES");
            string[] opciones = ["Todas las publicaciones", "Ventas", "Subastas", "Ofertas de las SUBASTAS", "Volver"];
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
                    AdministrarPublicaciones();
                    break;
                default:
                    break;
            }
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
            if (opcion == nombres.Count - 1) ListarPublicaciones();
            Subasta publicacion = ventas[opcion] as Subasta;
            publicacion.MostrarOfertas();

        }
        private static void VerPublicaciones(string titulo, string tipo, Estado estado)
        {
            Console.Clear();
            Console.WriteLine(titulo);
            List<Publicacion> ventas = _sistema.ListaPublicaciones(tipo, estado);
            for (int i = 0; i < ventas.Count; i++)
            {
                Console.WriteLine(ventas[i].ToString());
            }
        }
        private static void AdministrarClientes()
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRACION DE CLIENTES");
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
            foreach (Usuario usuario in listaUsuarios)
            {
                Console.WriteLine(usuario.ToString() + "\n");
            }
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            Console.ReadKey();
            AdministrarClientes();
        }
        private static void ListarAdministradores()
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRADORES\n");
            List<Usuario> listaUsuarios = new(_sistema.MostrarUsuarios(true));
            foreach (Usuario usuario in listaUsuarios)
            {
                Console.WriteLine(usuario.ToString() + "\n");
            }
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            Console.ReadKey();
            AdministrarClientes();
        }
        private static void AdministrarArticulos()
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRACION DE ARTICULOS");
            int opcion = ConstructorMenu(["Listar", "Agregar", "Modificar",
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
            List<Articulo> lista = new(_sistema.MostrarArticulos("TODOS"));
            foreach (Articulo unArticulo in lista)
            {
                Console.WriteLine(unArticulo.ToString());
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
            List<string> categorias = new(MostrarCategoriasNombre());
            categorias.Add("Volver");
            int opcion = ConstructorMenu(categorias.ToArray());
            if (opcion == categorias.Count - 1) ListarArticulos();
            categorias = MostrarCategoriasNombre();
            List<Articulo> articulos = new(_sistema.MostrarArticulos(categorias[opcion]));
            Console.Clear();
            foreach (Articulo articulo in articulos)
            {
                Console.WriteLine(articulo.ToString());
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
                decimal precio = PedirNumero("Ingrese un precio para el articulo:", 11);
                AceptarArticulo(categoria, nombre, precio);
            }
            else
            {
                AdministrarArticulos();
            }
        }
        private static void AceptarArticulo(string categoria, string nombre, decimal precio)
        {
            Console.Clear();
            Console.WriteLine("CONFIRMAR ARTICULO NUEVO");
            TextoColor("yellow", $"\nNOMBRE : {nombre.ToUpper()}\nPRECIO : {precio}\nCATEGORIA : {categoria}\n");
            int opcion = ConstructorMenu(["ACEPTAR", "CANCELAR"]);
            if (opcion == 0 && !string.IsNullOrEmpty(nombre) && precio > 0) //&& categorias.Count > 0
            {
                _sistema.AgregarArticulo(new Articulo(nombre, _sistema.BuscarCategoria(categoria), precio));
                Console.WriteLine("Producto agregado correctamente. Presione cualquier tecla para continuar...");
                Console.ReadKey();
                AdministrarArticulos();
            }
            else if (opcion != 0 && !string.IsNullOrEmpty(nombre) && precio > 0) // && categorias.Count > 0
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
            foreach (Categoria unaCategoria in lista)
            {
                Console.WriteLine($"({contador}) " + unaCategoria.ToString());
                contador++;
            }
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            Console.ReadKey();
            AdministrarCategorias();
        }
        private static void Salir()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Has salido del sistema...\n-> Presiona cualquier tecla para cerrar esta ventanta");
            Console.ForegroundColor = ConsoleColor.White;
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
                //{

                //}
                //else
                //{
                //    TextoColor("red", "Ingrese un valor numerico...\n");
                //}
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
            Console.WriteLine(mensaje);
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
