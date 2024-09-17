namespace Dominio.Entidades
{
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
