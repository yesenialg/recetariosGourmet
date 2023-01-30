namespace Gourmet;

public interface ISuscritora
{
    Usuario Usuario { get; set; }
    IPerfil Perfil { get; set; }
    public bool Notificaciones { get; set; }

    public bool EnviarNotificacion(Receta receta);
}