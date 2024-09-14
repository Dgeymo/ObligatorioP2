using Dominio;

namespace ConsolaApp
{
    public class Program
    {
        public static Sistema _sistema = new Sistema();
        static void Main(string[] args)
        {
            try
            {
                PreCarga.PreCargas();
                //_sistema.MostrarPrecargas(); //NO SE DEBE INCLUIR EN PROYECTO FINAL
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Vistas.MenuInicio(); //MENU DEL PROGRAMA
        }

    }
}
