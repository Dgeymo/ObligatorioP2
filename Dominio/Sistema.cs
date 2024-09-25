﻿using Dominio.Entidades;
namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Categoria> _categorias = new List<Categoria>();
        private List<Estado> _estados = new List<Estado>();

        public Usuario BuscarUsuario(string email)
        {
            if (String.IsNullOrEmpty(email)) throw new Exception("No se ha cargado el email en el parametro");
            foreach (Usuario unUsuario in _usuarios)
            {
                if (unUsuario.Email == email)
                {
                    return unUsuario;
                }
            }
            return null!;
        }
        public Categoria BuscarCategoria(string categoria)
        {
            if (String.IsNullOrEmpty(categoria)) throw new Exception("No se ha cargado la categoria en el parametro");
            foreach (Categoria unaCategoria in _categorias)
            {
                if (unaCategoria.Nombre == categoria) return unaCategoria;
            }
            return null!;
        }
        public Articulo BuscarArticulo(int idArticulo)
        {
            if (!int.TryParse(idArticulo.ToString(), out _)) throw new Exception("No se ha pasado un número");
            foreach (Articulo unArticulo in _articulos)
            {
                if (unArticulo.Id == idArticulo) return unArticulo;
            }
            return null!;
        }
        public Subasta BuscarPublicacionSubasta(int idPublicacion)
        {
            if (!int.TryParse(idPublicacion.ToString(), out _)) throw new Exception("ingrese un id valido de publicacion");
            foreach (Publicacion unaPublicacion in _publicaciones)
            {
                if (unaPublicacion.Id == idPublicacion)
                {
                    if (unaPublicacion is not Subasta) throw new Exception("El id ingresado no es una subasta");
                    return (Subasta)unaPublicacion;
                }
            }
            return null!;
        }

        

        public List<Usuario> MostrarUsuarios(bool admin)
        {
            List<Usuario> unaLista = new List<Usuario>();
            
            foreach(Usuario usuario in _usuarios)
            {
                if (usuario is Cliente && !admin)
                {
                    unaLista.Add(usuario);
                }
                else if(usuario is Administrador && admin)
                {
                    unaLista.Add(usuario);
                }
            }
            return unaLista;
        }
        public List<Categoria> MostrarCategorias()
        {
            return _categorias;
        }
        
        public List<Publicacion> ListaPublicaciones(string tipo, Estado estado)
        {
            //if (estado.Equals(Estado.)) throw new Exception("No se ha cargado el estado en el parametro");
            if (string.IsNullOrEmpty(tipo)) throw new Exception("No se ha cargado el tipo en el parametro");
            List<Publicacion> publicaciones = new List<Publicacion>();

            foreach (Publicacion unaPublicacion in _publicaciones) //.nombre == tipo.ToUpper())
            {
                if (tipo.ToUpper() == "TODOS")
                {
                    if (estado == unaPublicacion.EstadoPublicacion)
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                    else if (estado.ToString() == "TODOS")
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                }
                else if (tipo.ToUpper() == "VENTA" && unaPublicacion is Venta)
                {
                    if (estado == unaPublicacion.EstadoPublicacion)
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                    else if (estado.ToString() == "TODOS")
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                }
                else if (tipo.ToUpper() == "SUBASTA" && unaPublicacion is Subasta)
                {
                    if (estado == unaPublicacion.EstadoPublicacion)
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                    else if (estado.ToString() == "TODOS")
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                }
            }
            return publicaciones;
        }

        public List<Articulo> MostrarArticulos(string categoria)
        {
            List <Articulo> resultado = new List<Articulo>();
            if (categoria.ToUpper() == "TODOS")
            {
                foreach (Articulo unArticulo in _articulos) resultado.Add(unArticulo);
            }
            else
            {
                foreach(Articulo unArticulo in _articulos)
                {
                    List<Categoria> categorias = new List<Categoria>();
                    categorias = unArticulo.ObtenerCategorias();
                    foreach (Categoria unaCategoria in categorias)
                    {
                        if (unaCategoria.Nombre == categoria)
                            resultado.Add(unArticulo);
                    }
                }
            }
            return resultado;
        }

        //Bloque de muestra de listas como strings
        public List<string> MostrarCategoriasNombre()
        {
            List<string> listaCategorias = new List<string>();
            for (int i = 0; i < _categorias.Count; i++)
            {
                listaCategorias.Add(_categorias[i].Nombre.ToString());
            }
            return listaCategorias;
        }
        //Bloque de Add en las listas
        public void AgregarArticulo(Articulo nuevoArticulo)
        {
            if (nuevoArticulo == null) throw new Exception("Valor nulo en el parametro de agregar artículo");
            nuevoArticulo.Validar();
            _articulos.Add(nuevoArticulo);
        }
        public void AgregarPublicacion(Publicacion nuevaPublicacion)
        {
            if (nuevaPublicacion == null) throw new Exception("Valor nulo en el parametro publicacion");
            nuevaPublicacion.Validar();
            _publicaciones.Add(nuevaPublicacion);
        }
        public void AgregarCategoria(Categoria nuevaCategoria)
        {
            if (nuevaCategoria == null) throw new Exception("Valor nulo en el parametro de agregar categoría");
            nuevaCategoria.Validar();
            _categorias.Add(nuevaCategoria);
        }
        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            if (nuevoUsuario == null) throw new Exception("Valor nulo en el parametro de agregar usuario");
            nuevoUsuario.Validar();
            if (BuscarUsuario(nuevoUsuario.Email) != null) throw new Exception("El usuario ya existe");
            _usuarios.Add(nuevoUsuario);
        }
        /// <summary>
        /// ESTE METODO NO VA A INCLUIRSE EN EL PROYECTO FINAL. ES A MODO DE VER LOS REGISTROS DE CATEGORIA Y ARTICULOS INGRESADOS
        /// </summary>
        public void MostrarPrecargas()
        {
            for (int i = 0; i < _categorias.Count; i++)
            {
                Console.WriteLine(_categorias[i]);
            }
            for (int i = 0; i < _articulos.Count; i++)
            {
                Console.WriteLine(_articulos[i]);
            }
            for (int i = 0; i < _usuarios.Count; i++)
            {
                Console.WriteLine(_usuarios[i]);
            }
            for (int i = 0; i < _estados.Count; i++)
            {
                Console.WriteLine(_estados[i]);
            }
        }



        //public object Obtener(List<object> lista, Categoria parametro, Categoria valor)
        //{
        //    //if (valor == null || lista == null) throw new ArgumentException("Parámetros inválidos"));

        //    //foreach (var obj in lista)
        //    //{
        //    //    if (obj != null && obj.GetType().GetProperty(parametro) != null &&
        //    //        obj.GetType().GetProperty(parametro).GetValue(obj) == valor)
        //    //    {
        //    //        return obj;
        //    //    }
        //    //}
        //    return null;
        //}
    }
}
