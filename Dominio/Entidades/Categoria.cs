namespace Dominio.Entidades
{
    public class Categoria
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Categoria(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }


        public override string ToString()
        {
            string mensaje = string.Empty;
            mensaje += $"Categoria: {Nombre.ToUpper()}\nDescripción : {Descripcion}\n";
            return mensaje;
        }

    }
}
