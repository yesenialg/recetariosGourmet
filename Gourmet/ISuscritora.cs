namespace Gourmet;

public interface ISuscritora
{
    Usuario Usuario { get; set; }
    Perfil Perfil { get; set; }
    public bool Notificaciones { get; set; }

    public bool EnviarNotificacion(Receta receta);
}