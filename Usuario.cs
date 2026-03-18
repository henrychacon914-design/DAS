public class Usuario
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Correo { get; set; }
    public string Contraseña { get; set; }
    public string TipoUsuario { get; set; }
    public int Visitas { get; set; }

    public Usuario(string nombre, string apellido, string correo, string contraseña, string tipoUsuario)
    {
        Nombre = nombre;
        Apellido = apellido;
        Correo = correo;
        Contraseña = contraseña;
        TipoUsuario = tipoUsuario;
    }

    public Usuario()
    {
    }
}