using Dominio;

namespace ConsolaApp
{
    internal class Program
    {
        static Sistema _sistema = new Sistema();
        static void Main(string[] args)
        {
            try
            {
                _sistema.Precargas();
                _sistema.MostrarPrecargas(); //NO SE DEBE INCLUIR EN PROYECTO FINAL
                                             // Console.WriteLine(_sistema.MostrarUsuario("Diego")); 
                Vistas.MenuInicio(); //MENU DEL PROGRAMA
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
