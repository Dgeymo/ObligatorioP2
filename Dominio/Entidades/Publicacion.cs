namespace Dominio.Entidades
{
    public class Publicacion : Sistema
    {
        private List<Oferta> _ofertas = new List<Oferta>();
        private List<Articulo> _articulos = new List<Articulo>();

        public int Id { get; set; }
        private static int _ultimoId;
        public string Nombre { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaFinalizado { get; set; }
        public Estado Estado { get; set; }
        public Usuario Usuario { get; set; }
        public Tipo Tipo { get; set; }

        public bool Oferta = false;     
        public Publicacion(string nombre,
                        Estado estado,
                        DateTime fechaPublicacion,
                        Usuario usuario,
                        Tipo tipo,
                        bool oferta,
                        List<Articulo> articulos)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Estado = estado;
            FechaPublicacion = fechaPublicacion;
            Usuario = usuario;
            Tipo = tipo;
            Oferta = oferta;
            _articulos = articulos;


        }

        public override string ToString()
        {
            string respuesta = string.Empty;
            respuesta = $"Id: {Id}\n" +
                $"Tipo: {Tipo.Nombre}\n" +
                $"Nombre: {Nombre}\n" +
                $"Usuario: {Usuario.Nombre} {Usuario.Apellido}\n" +
                $"Estado: {Estado.Nombre}\n" +
                $"Fecha Publicación: {FechaPublicacion}\n";
            if (Estado.Nombre == "Finalizado") respuesta += $"Fecha Finalizado: {FechaFinalizado}\n";
            respuesta += $"ARTICULOS\n";
            for (int i = 0; i < _articulos.Count; i++)
            {
                respuesta += $"Id: {_articulos[i].Id} " +
                    $"{_articulos[i].Nombre}\n";
            }
            return respuesta;
        }

        public void AgregarArticuloProducto(Articulo articulo)
        {
            if (articulo != null) _articulos.Add(articulo);
        }

        public void QuitarArticuloProducto(Articulo articulo)
        {
            _articulos.Remove(articulo);
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                 Estado == null ||
                 Usuario == null ||
                 Tipo == null ||
                 string.IsNullOrEmpty(FechaPublicacion.ToString()) ||
                 string.IsNullOrEmpty(Oferta.ToString()))
            {
                throw new Exception("Datos incorrectos al intentar ingresar la PUBLICACIÓN.");
            }
            if (_articulos.Count == 0) throw new Exception("Debe seleccionar al menos un artículo para la publicacion");
        }
    }
}
