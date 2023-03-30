namespace Gourmet;

public class Usuario
{
    public string Nombre { get; set; }
    public string Correo { get; set; }

    public Usuario(string nombre, string correo)
    {
        this.Nombre = nombre;
        this.Correo = correo;
    }
}