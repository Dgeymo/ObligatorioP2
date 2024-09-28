namespace Dominio.Entidades
{
    public class Venta : Publicacion
    {
        public bool Oferta = false;
        public Venta(string nombre,
                        Estado estado,
                        Usuario usuario,
                        bool oferta,
                        List<Articulo> articulos,
                        DateTime fechaPublicacion) : base(nombre,
                                                           estado,
                                                           usuario,
                                                           articulos,
                                                           fechaPublicacion)
        {
            Oferta = oferta;
        }
        public override string ToString()
        {
            string respuesta = base.ToString();
            respuesta += $"Tipo: Venta\n";
            return respuesta;
        }
    }
}
