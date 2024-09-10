using System.ComponentModel;

namespace Dominio.Entidades
{
    public class Administrador : Usuario
    {
        public Administrador(
           string nombre,
           string apellido,
           string email,
           string password)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            _password = password;
        }

        public override string ToString()
        {
            string mensaje = string.Empty;
            mensaje += $"Id: {Id}\nNombre: {Nombre}\nApellido: {Apellido}\nEmail: {Email}\nRol: {Nombre.GetType()} ";
            return mensaje;
        }
    }
}
