using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Publicacion
    {
        private List<Oferta> _ofertas = new List<Oferta>();
        private List<Articulo> _articulos = new List<Articulo>();

        public int Id { get; set; }
        private static int _ultimoId;
        public string Nombre { get; set; }
        private Estado _estado;
        public DateTime FechaPublicacion { get; set; }
        public DateTime FEchaFinalizado { get; set; }
        private Usuario _usuario;
        private Tipo _tipo;
        public bool Oferta = false;


        public Publicacion()
        {
            Id = _ultimoId++;
        }
        

    }
}
