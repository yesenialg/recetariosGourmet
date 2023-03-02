using System.Net.Mail;
using System.Net.Mime;

namespace Gourmet;

public class UsuarioPerfil
{
    public Usuario Usuario { get; set; }
    public IPerfil Perfil { get; set; }
    public bool Notificaciones { get; set; }

    private INotificacion sendEmail { get; set; }

    public UsuarioPerfil(Usuario nombre, IPerfil perfil, bool notificaciones, INotificacion sendEmail)
    {
        this.Usuario = nombre;
        this.Perfil = perfil;
        this.Notificaciones = notificaciones;
        this.sendEmail = sendEmail;
    }
    public void CambiarEstadoNotificaciones()
    {
        this.Notificaciones = !this.Notificaciones;
    }

    public bool EnviarNotificacion(Receta receta)
    {
        return sendEmail.EnviarNotificacion(receta);
    }
}