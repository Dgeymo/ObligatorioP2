
namespace Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        internal string _password;
        internal static int _ultimoId;

        public string Password
        {
            set { _password = value; }
        }
        public Usuario( string nombre, string apellido, string email, string password)
        {           
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            _password = password;          
        }

        public virtual void Validar()
        {
           //todo:falta Validar
        }
    }
}
