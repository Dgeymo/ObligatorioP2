
namespace Dominio.Entidades
{
    public class Oferta
    {
        public int Id { get; set; }
        private static int _ultimoId;
        public decimal Precio { get; set; }
        private Usuario _usuario;
        public DateTime Fecha { get; set; }
       
           public Oferta(decimal precio, Usuario usuario)
        {
            Id = _ultimoId++;
            Precio = precio;
            _usuario = usuario;
            Fecha = DateTime.Now;
        }
    }
}
