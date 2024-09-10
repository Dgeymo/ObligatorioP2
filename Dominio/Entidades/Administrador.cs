namespace Dominio.Entidades
{
    public class Administrador : Usuario
    {
        public Administrador(
           string nombre,
           string apellido,
           string email,
           string password): base(nombre,apellido,email,password)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            _password = password;
        }
        public override string ToString()
        {          
            return $"Id: {Id}\nNombre: {Nombre}\nApellido: {Apellido}\nEmail: {Email}\nTipo: Administrador";         
        }
    }
}
