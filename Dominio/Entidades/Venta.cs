namespace Dominio.Entidades
{
    public class Venta : Publicacion
    {
        public bool Oferta {get;set;}
        public Venta(string nombre,
                        Estado estado,
                        Administrador usuario,
                        List<Articulo> articulos,
                        DateTime fechaPublicacion) : base(nombre,
                                                           estado,
                                                           usuario,
                                                           articulos,
                                                           fechaPublicacion)
        {
            Oferta = false;
        }
    }
}
