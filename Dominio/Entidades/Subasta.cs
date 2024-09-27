using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Subasta : Publicacion
    {
        private List<Oferta> _ofertas = new List<Oferta>();
        public Subasta(string nombre,
                       Estado estado,
                       Usuario usuario,
                       bool oferta,
                       List<Articulo> articulos,
                       DateTime fechaPublicacion
                     ) : base(nombre, estado, usuario, oferta, articulos,fechaPublicacion)
        {
        }
        public override string ToString()
        {
            string respuesta = base.ToString();
            respuesta += $"Tipo: Subasta\n";
            //if (_ofertas.Count > 0)
            //{
            //    respuesta += "\nOFERTAS:\n";
            //    foreach (Oferta unaOferta in _ofertas)
            //    {
            //        respuesta += unaOferta.ToString();
            //    }
            //} 
            return respuesta;
        }        
        public void CargarOferta(Oferta oferta)
        {
            if (oferta == null) throw new Exception("Parametro incorrecto para crear una oferta");
            oferta.Validar();
            _ofertas.Add(oferta);
        }
    }
}
