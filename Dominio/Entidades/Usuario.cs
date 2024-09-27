
using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public abstract class Usuario:IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        private string _password;
        private static int _ultimoId;

        public string Password
        {
            set { _password = value; }
        }
        public Usuario( string nombre, string apellido, string email, string password)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            _password = password;           
        }

        public virtual void Validar()
        {
           //todo:falta Validar
        }
        public abstract override string ToString();     
      }
}
