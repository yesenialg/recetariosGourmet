using System.Net.Mail;
using System.Net.Mime;
using Gourmet.Perfiles;

namespace Gourmet;

public class UsuarioPerfil
{
    public Usuario Usuario { get; set; }
    public IPerfil Perfil { get; set; }
    public virtual bool Notificar { get; set; }
    private INotificacion sendEmail { get; set; }

    public UsuarioPerfil(Usuario nombre, IPerfil perfil, bool notificaciones, INotificacion sendEmail)
    {
        this.Usuario = nombre;
        this.Perfil = perfil;
        this.Notificar = notificaciones;
        this.sendEmail = sendEmail;
    }
    public void CambiarEstadoNotificaciones() => this.Notificar = !this.Notificar;

    public void EnviarNotificacion(Receta receta) => sendEmail.EnviarNotificacion(receta);
}