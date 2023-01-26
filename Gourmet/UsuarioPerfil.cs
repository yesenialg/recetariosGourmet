﻿using EnviarCorreoElectronico;
using System.Net.Mail;
using System.Net.Mime;

namespace Gourmet;

public class UsuarioPerfil : ISuscritora
{
    public Usuario Usuario { get; set; }
    public Perfil Perfil { get; set; }
    public bool Notificaciones { get; set; }

    public UsuarioPerfil(Usuario nombre, Perfil perfil, bool notificaciones)
    {
        this.Usuario = nombre;
        this.Perfil = perfil;
        this.Notificaciones = notificaciones;
    }

    bool ISuscritora.EnviarNotificacion(Receta receta)
    {
        try
        {
            GestorCorreo gestor = new();

            gestor.EnviarCorreo(Usuario.Correo,
                                "Nueva Receta!",
                                receta.Titulo);
            return true;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public void ActivarNotificaciones()
    {
        this.Notificaciones = true;
    }
    public void DesactivarNotificaciones()
    {
        this.Notificaciones = false;
    }
}