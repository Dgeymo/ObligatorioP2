
namespace Dominio.Entidades
{
    public class Oferta
    {
        public int Id { get; set; }
        private static int _ultimoId;
        public decimal Precio { get; set; }
        private Usuario _usuario;
        public DateTime Fecha { get; set; }

        public Oferta(Usuario usuario, decimal precio)
        {
            Id = _ultimoId++;
            _usuario = usuario;
            Precio = precio;
            Fecha = DateTime.Now;
        }
        public override string ToString()
        {
            return $"Id Oferta: {Id}\nDatos del Oferente:\n\t" + 
                   $"Nombre: {_usuario.Nombre} {_usuario.Apellido}\n\t" + 
                   $"Email: {_usuario.Email}\nMonto de la puja: ${Precio}\nRealizado el: {Fecha}\n\n";
        }
        public void Validar()
        {
            if (Precio < 0) throw new Exception("El precio no puede ser menor que cero");
        }
    }
}
