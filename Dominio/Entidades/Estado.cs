using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    class Estado
    {
        public int Id { get; set; }
        private static int _ultimoId;
        public string Nombre { get; set; }


        public Estado()
        {
            Id = _ultimoId++;
        }
    }
}
