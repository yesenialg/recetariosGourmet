namespace Gourmet;
using Gourmet;

public class Recetario
{
    public string Titulo { get; set; }
    public List<Receta> Recetas { get; set; }
    public List<ISuscritora> UsuariosSuscritos { get; set; }
    public List<Ranking> RankingSuscritos { get; set; }
    
    public Recetario(string titulo, List<Receta> recetas)
    {
        this.Titulo = titulo;
        this.Recetas = recetas;
        this.UsuariosSuscritos = new List<ISuscritora>();
        this.RankingSuscritos = new List<Ranking>();
    }

    public int CantidadRecetas()
    {
        return Recetas.Count;
    }
    
    public void SuscribirUsuario(ISuscritora suscripcion)
    {
        UsuariosSuscritos.Add(suscripcion);
    }

    public bool DesuscribirUsuario(ISuscritora suscripcion)
    {
        var eliminar = from sus in UsuariosSuscritos
                       where sus.Equals(suscripcion)
                       select sus;
        if (eliminar.ToList().Count != 0)
        {
            UsuariosSuscritos.Remove(eliminar.ToList()[0]);
            return true;
        }
        return false;
    }

    public Dictionary<ISuscritora, bool> AgregarReceta(Receta receta)
    {
        Recetas.Add(receta);
        foreach (Ranking i in RankingSuscritos)
        {
            if (i.Activo)
            {
                i.SumarPuntos(receta, 10);
            }
        }
        return VerificarAptos(receta);
    }

    public Dictionary<ISuscritora, bool> VerificarAptos(Receta receta)
    {
        Celiaco celiaco = new("celiaco");
        Carnivoro carnivoro = new("carnivoro");
        Vegano vegano = new("vegano");
        Vegano vegetariano = new("vegetariano");

        var apta = new List<string>();

        if (celiaco.RecetaApta(receta))
            apta.Add(celiaco.Nombre);
        if (carnivoro.RecetaApta(receta))
            apta.Add(carnivoro.Nombre);
        if (vegano.RecetaApta(receta))
            apta.Add(vegano.Nombre);
        if (vegetariano.RecetaApta(receta))
            apta.Add(vegetariano.Nombre);
        return NotificarUsuariosSuscritos(apta, receta);
    }

    public Dictionary<ISuscritora, bool> NotificarUsuariosSuscritos(List<string> apta, Receta receta)
    {
        var correoEnviado = new Dictionary<ISuscritora, bool>();
        foreach (ISuscritora suscrito in UsuariosSuscritos)
        {
            if (apta.Contains(suscrito.Perfil.Nombre) && suscrito.Notificaciones)
            {
                correoEnviado.Add(suscrito, suscrito.EnviarNotificacion(receta));
            }
        }
        return correoEnviado;
    }
    
    public void SuscribirRanking(Ranking suscripcion)
    {
        RankingSuscritos.Add(suscripcion);
    }

    public bool DesuscribirRanking(Ranking suscripcion)
    {
        var eliminar = from sus in RankingSuscritos
                       where sus.Equals(suscripcion)
                       select sus;
        if (eliminar.ToList().Count != 0)
        {
            RankingSuscritos.Remove(eliminar.ToList()[0]);
            return true;
        }
        return false;
    }
}