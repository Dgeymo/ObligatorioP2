using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        internal void Validar()
        {
           
        }
    }
}
