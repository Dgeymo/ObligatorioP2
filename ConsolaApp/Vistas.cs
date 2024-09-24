using Dominio;
using Dominio.Entidades;
using System;
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
        static void MenuUsuario()
        {
            EnConstruccion();
        }
        static void MenuAdministracion()
        {
            Console.Clear();
            Console.WriteLine("HERRAMIENTAS ADMINISTRATIVAS");
            int opcion = ConstructorMenu(["Categorias", "Productos", "Clientes", "Publicaciones", "Volver"]);
            lista.Clear();
            lista.Add(AdministrarCategorias);
            lista.Add(AdministrarProductos);
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
            string[] opciones = ["Todas las publicaciones", "Ventas", "Subastas", "Volver"];
            int opcion = ConstructorMenu(["Todas las publicaciones", "Ventas", "Subastas", "Volver"]);
            switch (opcion)
            {
                case 0:
                    VerPublicaciones("Todas las publicaciones", "todos", Estado.TODOS);
                    TextoColor("yellow", "Presione cualquier tecla para continuar...");
                    ListarPublicaciones();
                    break;
                case 1:
                    VerPublicaciones("VENTAS", "venta", Estado.TODOS);
                    TextoColor("yellow", "Presione cualquier tecla para continuar...");
                    ListarPublicaciones();
                    break;
                case 2:
                    VerPublicaciones("SUBASTAS", "subasta", Estado.TODOS);
                    TextoColor("yellow", "Presione cualquier tecla para continuar...");
                    ListarPublicaciones();
                    break;
                case 3:
                    AdministrarPublicaciones();
                    break;
                default:
                    break;
            }
        }
        private static void VerPublicaciones(string titulo, string tipo, Estado estado)
        {
            Console.Clear();
            Console.WriteLine(titulo);
            List<string> ventas = _sistema.ListaPublicaciones(tipo, estado);
            for (int i = 0; i < ventas.Count; i++)
            {
                Console.WriteLine(ventas[i]);
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
            List<string> listaUsuarios = new(_sistema.MostrarUsuarios(false));
            foreach (string usuario in listaUsuarios)
            {
                Console.WriteLine(usuario.ToString() + "\n");
            }
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            AdministrarClientes();
        }
        private static void ListarAdministradores()
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRADORES\n");
            List<string> listaUsuarios = new(_sistema.MostrarUsuarios(true));
            foreach (string usuario in listaUsuarios)
            {
                Console.WriteLine(usuario.ToString() + "\n");
            }
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            AdministrarClientes();
        }

        private static void AdministrarProductos()
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRACION DE PRODUCTOS");
            int opcion = ConstructorMenu(["Listar productos", "Agregar producto", "Modificar producto",
                "Volver"]);
            lista.Clear();
            lista.Add(ListarProductos);
            lista.Add(AgregarProducto);
            lista.Add(EnConstruccion);
            lista.Add(MenuAdministracion);
            lista[opcion]();
        }

        private static void ListarProductos()
        {
            Console.Clear();
            Console.WriteLine("LISTAR PRODUCTOS");
            int opcion = ConstructorMenu(["Todos los productos", "Por categoria", "Volver"]);
            lista.Clear();
            lista.Add(ListarProductosTodos);
            lista.Add(ListarProductosFiltrado);
            lista.Add(AdministrarProductos);
            lista[opcion]();
        }

        private static void ListarProductosTodos()
        {
            Console.Clear();
            List<string> lista = new(_sistema.MostrarArticulos("TODOS"));
            foreach (string unArticulo in lista)
            {
                Console.WriteLine(unArticulo);
            }
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            ListarProductos();
        }
        private static void ListarProductosFiltrado()
        {
            Console.Clear();
            Console.WriteLine("LISTAR PRODUCTOS POR CATEGORIA");
            Console.WriteLine("Seleccione una categoria");
            List<string> categorias = new(_sistema.MostrarCategoriasNombre());
            categorias.Add("Volver");
            int opcion = ConstructorMenu(categorias.ToArray());
            if (opcion == categorias.Count - 1) ListarProductos();
            categorias = _sistema.MostrarCategoriasNombre();
            List<string> articulos = new(_sistema.MostrarArticulos(categorias[opcion]));
            Console.Clear();
            foreach (string articulo in articulos)
            {
                Console.WriteLine(articulo);
            }
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            ListarProductos();
        }
        private static void AgregarProducto()
        {
            Console.Clear();
            Console.WriteLine("AGREGAR ARTICULO NUEVO");
            List<string> categorias = new();
            categorias = SeleccionarCategorias(categorias);
            categorias = LimpiarRepetidos(categorias);
            Console.Clear();
            Console.WriteLine("Ingrese un nombre para el artículo:");
            string nombre = Console.ReadLine();
            bool flag = false;
            decimal precio = 0;
            do
            {
                try
                {
                    Console.WriteLine("Ingrese un precio para el articulo:");
                    precio = int.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception)
                {
                    TextoColor("red", "Ingrese solo numeros!!! Presione cualquier tecla para continuar....");
                }
            } while (!flag);
            AceptarArticulo(categorias, nombre, precio);
        }
        private static List<string> SeleccionarCategorias(List<string> categorias)
        {
            int opcion;
            List<string> listaCategorias = new(_sistema.MostrarCategoriasNombre());
            listaCategorias.Add("Terminar");
            do
            {
                Console.Clear();
                if (categorias.Count > 0)
                {
                    Console.WriteLine("CATEGORIAS SELECCIONADAS :");
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (string laCategoria in categorias)
                    {
                        Console.WriteLine(laCategoria);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("Seleccione una categoria para agregar al nuevo artículo");
                opcion = ConstructorMenu(listaCategorias.ToArray());
                string categoria = listaCategorias[opcion];
                Categoria unaCategoria = _sistema.BuscarCategoria(categoria);
                if (opcion != listaCategorias.Count - 1) categorias.Add(unaCategoria.Nombre);
            } while (opcion != listaCategorias.Count - 1);
            return categorias;
        }
        private static List<string> LimpiarRepetidos(List<string> listaRepetidos)
        {
            List<string> ret = new List<string>();
            foreach (string unaCat in listaRepetidos)
            {
                if (ret.IndexOf(unaCat) == -1) ret.Add(unaCat);
            }
            return ret;
        }
        private static void AceptarArticulo(List<string> categorias, string nombre, decimal precio)
        {
            Console.Clear();
            Console.WriteLine("CONFIRMAR ARTICULO NUEVO");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nNOMBRE : {nombre.ToUpper()}");
            Console.WriteLine($"PRECIO : {precio}");
            string cat = "CATEGORIAS :";
            foreach (string categoria in categorias)
            {
                cat += " " + categoria + " ";
            }
            cat += "\n";
            Console.WriteLine(cat);
            Console.ForegroundColor= ConsoleColor.White;
            List<Categoria> lasCategorias = new List<Categoria>();
            foreach (string categoria in categorias)
            {
                lasCategorias.Add(_sistema.BuscarCategoria(categoria));
            }
            int opcion = ConstructorMenu(["ACEPTAR", "CANCELAR"]);
            if (opcion == 0 && !string.IsNullOrEmpty(nombre) && categorias.Count > 0 && precio > 0)
            {
                _sistema.AgregarArticulo(new Articulo(nombre, lasCategorias, precio));
                Console.WriteLine("Producto agregado correctamente. Presione cualquier tecla para continuar");
                Console.ReadKey();
                AdministrarProductos();
            }
            else if (opcion == 1 && !string.IsNullOrEmpty(nombre) && categorias.Count > 0 && precio > 0)
            {
                Console.WriteLine("Cancelado. Presione cualquier tecla para continuar...");
                Console.ReadKey();
                AdministrarProductos();
            }
            else
            {
                Console.WriteLine("Cancelado. Campo Categorias/Nombre vacias o precio incorrecto. Presione cualquier tecla para continuar...");
                Console.ReadKey();
                AdministrarProductos();
            }
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
                            Program._sistema.AgregarCategoria(nuevaCategoria);
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
            List<string> lista = _sistema.MostrarCategorias();
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine(lista[i]);
            }
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            AdministrarCategorias();
        }

        private static void Salir()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Has salido del sistema...\n-> Presiona cualquier tecla para cerrar esta ventanta");
            Console.ForegroundColor = ConsoleColor.White;
            lista.Clear();
        }
        static void EnConstruccion()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(" EN CONSTRUCCION ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadKey();
            MenuInicio();
        }
        static int ConstructorMenu(string[] opciones)
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
        static int SelectorMenu(int opciones)
        {
            int opcion = 0;
            bool flag = false;
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Seleccione una opcion del menú");
                    opcion = int.Parse(Console.ReadLine());
                    flag = true;
                    if (opcion > opciones - 1) flag = false;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un valor numerico...\n");
                }
            }
            while (!flag);
            if (opcion == 0) return opciones - 1;
            return opcion - 1;
        }
        private static void ImprimirLogo()
        {
            //Console.WriteLine("OBLIGATORIO P2\n==============");  
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
            Console.ReadKey();
        }
    }
}
