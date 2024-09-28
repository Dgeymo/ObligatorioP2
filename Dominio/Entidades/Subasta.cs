using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Subasta : Publicacion
    {
        private List<Oferta> _ofertas = new List<Oferta>();
        public Subasta(string nombre,
                       Estado estado,
                       Administrador usuario,
                       List<Articulo> articulos,
                       DateTime fechaPublicacion
                     ) : base(nombre, estado, usuario, articulos,fechaPublicacion)
        {
        }

        public List<Oferta> MostrarOfertas()
        {
            return _ofertas;
        }
        public void CargarOferta(Oferta oferta)
        {
            if (oferta == null) throw new Exception("Parametro incorrecto para crear una oferta");
            oferta.Validar();
            _ofertas.Add(oferta);
        }
    }
}
