namespace Dominio.Entidades
{
    public class Tipo
    {
        public int Id { get; set; }
        private static int _ultimoId;
        public string Nombre { get; set; }
        public Tipo(string nombre)
        {
            Id = _ultimoId++;
            Nombre = nombre;
        }
        public override string ToString()
        {
            return $"Id: {Id}\nNombre: {Nombre}\n";
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new Exception("El TIPO no puede ser vacio o nulo.");
        }
    }
}
