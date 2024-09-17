namespace Dominio.Entidades
{
    public class Venta : Publicacion
    {
        public Venta(string nombre,
                        Estado estado,                       
                        Usuario usuario,
                        bool oferta,
                        List<Articulo> articulos) : base(nombre,
                         estado,                         
                         usuario,
                         oferta,
                        articulos)
        {
        }
        public override string ToString()
        {
           string respuesta = base.ToString();
            respuesta += $"Tipo: Venta\n";
            return respuesta;
        }
    }
}
