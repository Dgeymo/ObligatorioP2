namespace ConsolaApp
{
    public class Vistas
    {
        private delegate void Parametro1();
        private static List<Parametro1> lista = new List<Parametro1>();

        public static void MenuInicio()
        {
            Console.Clear(); //comentar para ver precargas         
            ImprimirLogo();
            int opcion = ConstructorMenu(["Usuario", "Administrador", "Salir"]);
            lista.Clear();
            lista.Add(Vistas.MenuUsuario);
            lista.Add(Vistas.MenuAdministracion);
            lista.Add(Vistas.Salir);
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
            lista.Add(Vistas.AdministrarCategorias);
            lista.Add(Vistas.AdministrarProductos);
            lista.Add(Vistas.AdministrarClientes);
            lista.Add(Vistas.AdministrarPublicaciones);
            lista.Add(Vistas.MenuInicio);
            lista[opcion]();
        }

        private static void AdministrarPublicaciones()
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRACION DE PUBLICACIONES");
            int opcion = ConstructorMenu(["Ver publicaciones (VENTAS)", "Ver publicaciones (SUBASTAS)",
                "Crear nueva publicacion (VENTA)", "Crear nueva publicacion (SUBASTA)",
                "Administrar publicaciones ABIERTAS","Listar todas las publicaciones", "Volver"]);
            lista.Clear();
            lista.Add(Vistas.EnConstruccion);
            lista.Add(Vistas.EnConstruccion);
            lista.Add(Vistas.EnConstruccion);
            lista.Add(Vistas.EnConstruccion);
            lista.Add(Vistas.EnConstruccion);
            lista.Add(Vistas.EnConstruccion);
            lista.Add(Vistas.MenuAdministracion);
            lista[opcion]();
        }

        private static void AdministrarClientes()
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRACION DE CLIENTES");
            int opcion = ConstructorMenu(["Listar clientes", "Volver"]);
            lista.Clear();
            lista.Add(Vistas.EnConstruccion);
            lista.Add(Vistas.MenuAdministracion);
            lista[opcion]();
        }

        private static void AdministrarProductos()
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRACION DE PRODUCTOS");
            int opcion = ConstructorMenu(["Listar productos", "Agregar producto", "Modificar producto",
                "Volver"]);
            lista.Clear();
            lista.Add(Vistas.EnConstruccion);
            lista.Add(Vistas.EnConstruccion);
            lista.Add(Vistas.EnConstruccion);
            lista.Add(Vistas.MenuAdministracion);
            lista[opcion]();
        }

        private static void AdministrarCategorias()
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRACION DE CATEGORÍAS");
            int opcion = ConstructorMenu(["Listar categorías", "Agregar categoría", "Volver"]);
            lista.Clear();
            lista.Add(Vistas.EnConstruccion);
            lista.Add(Vistas.EnConstruccion);
            lista.Add(Vistas.MenuAdministracion);
            lista[opcion]();
        }

        static void Salir()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Has salido del sistema...\n-> Presiona cualquier tecla para cerrar esta ventanta");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void EnConstruccion()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(" EN CONSTRUCCION ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadKey();
            Vistas.MenuInicio();
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
    }
}
