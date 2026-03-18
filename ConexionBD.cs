using System.Data.SQLite;
using System.IO;

namespace EL_BIBLIOTECARIO
{
    public class ConexionBD
    {
        // El archivo se creará en la carpeta del programa
        private static string cadena = "Data Source=biblioteca.db;Version=3;";

        public static void InicializarBD()
        {
            if (!File.Exists("biblioteca.db"))
            {
                SQLiteConnection.CreateFile("biblioteca.db");
            }

            using (var con = new SQLiteConnection(cadena))
            {
                con.Open();
                // Creamos la tabla con Sinopsis y Ruta de Imagen
                string sql = @"CREATE TABLE IF NOT EXISTS Libros (
                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                Titulo TEXT,
                                Autor TEXT,
                                Editorial TEXT,
                                Sinopsis TEXT,
                                Portada TEXT
                               )";
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
        }

        public static SQLiteConnection GetConexion()
        {
            return new SQLiteConnection(cadena);
        }
    }
}