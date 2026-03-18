using System.Collections.Generic;

namespace EL_BIBLIOTECARIO  
{
    public static class Datos
    {
        public static List<Libro> ListaLibros = new List<Libro>();
        public static List<string> ListaPrestamos = new List<string>();
        public static List<string> ListaUsuarios = new List<string>();

     
    }
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string RutaImagen { get; set; }
        public int Prestamos { get; set; }
    }
}