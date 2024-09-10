namespace Dominio.Entidades
{
    public class Tipo
    {
        public int Id { get; set; }
        private static int _ultimoId;
        public string Nombre { get; set; }



        public Tipo()
        {
            Id = _ultimoId++;
        }
    }
}
