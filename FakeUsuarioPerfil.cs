namespace Gourmet;

public class FakeUsuarioPerfil : UsuarioPerfil
{
    public bool EnviarNotificacionLlamado { get; private set; }

    public FakeUsuarioPerfil(Usuario usuario, IPerfil perfil, bool notificar) : base(usuario, perfil, notificar, null)
    {
    }

    public override void EnviarNotificacion(Receta receta)
    {
        EnviarNotificacionLlamado = true;
    }
}