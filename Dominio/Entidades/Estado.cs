namespace Dominio.Entidades
{
    public class Estado
    {
        public int Id { get; set; }
        private static int _ultimoId;
        public string Nombre { get; set; }

        public Estado(string nombre)
        {
            Id = _ultimoId++;
            Nombre = nombre;
        }
        public override string ToString()
        {
            return $"Id: {Id}\nNombre: {Nombre}\n";
        }
    }
}
