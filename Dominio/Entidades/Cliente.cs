namespace Dominio.Entidades
{
    public class Cliente : Usuario
    {
        public decimal saldoBilletera { get; set; }

        public Cliente(
           string nombre,
           string apellido,
           string email,
           string password,
           decimal Billetera) : base(nombre, apellido, email, password)
        {          
            saldoBilletera = Billetera;
        }
        public override string ToString()
        {
            string mensaje = string.Empty;
            mensaje += $"Id: {Id}\nNombre: {Nombre}\nApellido: {Apellido}\nEmail: {Email}\nCuentaSaldo: {saldoBilletera}\nTipo: Cliente";
            return mensaje;
        }
        public override void Validar()
        {
           //
        }
    }
}
