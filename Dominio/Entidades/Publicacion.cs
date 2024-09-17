﻿namespace Dominio.Entidades
{
    public abstract class Publicacion
    {

        private List<Articulo> _articulos = new List<Articulo>();

        public int Id { get; set; }
        private static int _ultimoId;
        public string Nombre { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaFinalizado { get; set; }
        public Estado Estado { get; set; }
        public Usuario Usuario { get; set; }

        public bool Oferta = false;
        public Publicacion(string nombre,
                        Estado estado,
                        Usuario usuario,
                        bool oferta,
                        List<Articulo> articulos)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Estado = estado;
            Usuario = usuario;
            Oferta = oferta;
            _articulos = articulos;
            FechaPublicacion = DateTime.Now;
        }
        public override string ToString()
        {
            decimal precioPublicacion = 0;
            string respuesta = string.Empty;
            respuesta = $"Id: {Id}\n" +
                $"Nombre: {Nombre}\n" +
                $"Usuario: {Usuario.Nombre} {Usuario.Apellido}\n" +
                $"Estado: {Estado.Nombre}\n" +
                $"Fecha Publicación: {FechaPublicacion}\n";
            if (Estado.Nombre == "Finalizado") respuesta += $"Fecha Finalizado: {FechaFinalizado}\n";
            respuesta += $"ARTICULOS:\n";
            for (int i = 0; i < _articulos.Count; i++)
            {
                respuesta += $"Id: {_articulos[i].Id} " +
                    $"{_articulos[i].Nombre} " +
                    $"${_articulos[i].Precio}\n";
                precioPublicacion += _articulos[i].Precio;
            }
            respuesta += $"Total de la publicación: ${precioPublicacion}\n";
            return respuesta;
        }
        public void AgregarArticuloProducto(Articulo articulo)
        {
            if (articulo == null) throw new Exception("Datos incorrectos al intentar agregar Articulos.");
            _articulos.Add(articulo);
        }
        public void QuitarArticuloProducto(Articulo articulo)
        {
            if (articulo == null) throw new Exception("Datos incorrectos al intentar quitar Articulos.");
            _articulos.Remove(articulo);
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                 Estado == null ||
                 Usuario == null ||
                 string.IsNullOrEmpty(FechaPublicacion.ToString()) ||
                 string.IsNullOrEmpty(Oferta.ToString()))
            {
                throw new Exception("Datos incorrectos al intentar ingresar la PUBLICACIÓN.");
            }
            if (_articulos.Count == 0) throw new Exception("Debe seleccionar al menos un artículo para la publicacion");
        }
    }
}
