namespace Dominio.Entidades
{
    public class Venta:Publicacion
    {
        public Venta(string nombre,
                        Estado estado,
                        DateTime fechaPublicacion,
                        Usuario usuario,
                        bool oferta,
                        List<Articulo> articulos): base(nombre,
                         estado,
                         fechaPublicacion,
                         usuario,
                         oferta,
                        articulos)
        {
        }
        public override string ToString()
        {
            string respuesta = string.Empty;
            respuesta = $"Id: {Id}\n" +
                $"Tipo: Venta\n" +
                $"Nombre: {Nombre}\n" +
                $"Usuario: {Usuario.Nombre} {Usuario.Apellido}\n" +
                $"Estado: {Estado.Nombre}\n" +
                $"Fecha Publicación: {FechaPublicacion}\n";
            if (Estado.Nombre == "Finalizado") respuesta += $"Fecha Finalizado: {FechaFinalizado}\n";
            respuesta += $"ARTICULOS\n";
            base.ToString();
            return respuesta;
        }
    }
}
