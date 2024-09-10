namespace Dominio.Entidades
{
    public class Cliente:Usuario
    {
     public  decimal saldoBilletera {  get; set; }

        public Cliente(
           string nombre,
           string apellido,
           string email,
           string password, 
           decimal Billetera)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            _password = password;
            saldoBilletera = Billetera;
        }

        public override string ToString()
        {
            string mensaje = string.Empty;
            mensaje += $"Id: {Id}\nNombre: {Nombre}\nApellido: {Apellido}\nEmail: {Email}\nCuentaSaldo: {saldoBilletera}";
            return mensaje;
        }
    }
}
