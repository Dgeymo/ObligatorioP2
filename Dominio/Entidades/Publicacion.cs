namespace Dominio.Entidades
{
    public class Publicacion:Sistema
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
                        bool oferta)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Estado = estado;
            FechaPublicacion = fechaPublicacion;
            Usuario = usuario;
            Tipo = tipo;
            Oferta = oferta;
        }

        public override string ToString()
        {
            string respuesta = string.Empty;
            respuesta = $"Id: {Id}\n" +
                $"Tipo: {Tipo.Nombre}\n" +
                $"Nombre: {Nombre}\n" +
                $"Usuario: {Usuario.Nombre} {Usuario.Apellido}\n" +
                $"Estado: {Estado.Nombre}\n" +
                $"Fecha Publicación: {FechaPublicacion}";
            if (Estado.Nombre == "Finalizado") respuesta += $"\nFecha Finalizado: {FechaFinalizado}";
            return respuesta;
        }

        internal void Validar()
        {
           if(string.IsNullOrEmpty(Nombre) ||
                Estado == null ||
                Usuario == null ||
                Tipo == null ||
                string.IsNullOrEmpty(FechaPublicacion.ToString())||
                string.IsNullOrEmpty(Oferta.ToString())) 
            {
                throw new Exception("Datos incorrectos al intentar ingresar la PUBLICACIÓN.");
            }
        }
    }
}
