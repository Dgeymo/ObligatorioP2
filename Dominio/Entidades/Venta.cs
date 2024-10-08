using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Venta : Publicacion, IValidable
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
        public override void Validar()
        {
            base.Validar();
        }
    }
}
