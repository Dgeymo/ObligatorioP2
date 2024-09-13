namespace ConsolaApp
{
    public class Vistas
    {
        public static void MenuInicio()
        {
            //Console.Clear(); //esta comentado para que se vean las precargas           
            ImprimirLogo();

            //esta funcion construye los menus en funcion de string que mandemos, pide y verifica la seleccion y devuelve la opcion.
            //y de ahi derivamos en un switch a que funcion queremos ir con la opcion que devuelve la funcion.
            int opcion = ConstructorMenu(["Usuario", "Administrador"]);
            switch (opcion)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Has salido del sistema...\n-> Presiona cualquier tecla para cerrar esta ventanta");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.WriteLine("En construcción...");
                    break;
            }
        }
        private static int ConstructorMenu(string[] opciones)
        {
            Console.WriteLine("\t<<Menu PRINCIPAL>>");
            string menu = string.Empty;
            for (int i = 0; i < opciones.Length; i++)
            {
                menu += $"\n({i + 1})_{opciones[i]}";
            }
            menu += "\n(0)_Salir\n";
            Console.WriteLine(menu);
            return SelectorMenu(opciones.Length);
        }
        private static int SelectorMenu(int opciones)
        {
            int opcion = 0;
            bool flag = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Seleccione una opcion del menú");
                try
                {
                    opcion = int.Parse(Console.ReadLine()!);
                    flag = true;
                    if (opcion > opciones) flag = false;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un valor numerico...\n");
                }
            }
            while (!flag);
            return opcion;
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
